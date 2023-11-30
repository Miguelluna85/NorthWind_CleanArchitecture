﻿namespace NorthWind.Sales.Frontend.WebApiGateways;
internal class ExceptionDelegatingHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var Response = await base.SendAsync(request, cancellationToken);

        if (!Response.IsSuccessStatusCode)
        {
            string ErrorMessage = await Response.Content.ReadAsStringAsync();
            string Source = null;
            string Message = null;
            IEnumerable<ValidationError> Errors = null;
            bool IsValidProblemDetails = false;

            try
            {
                var ContentType = Response.Content.Headers.ContentType.MediaType;
                var JsonResponse = JsonSerializer.Deserialize<JsonElement>(ErrorMessage);

                if (ContentType == "application/problem+json" &&
                   TryGetProperty(JsonResponse, "instance",
                    out JsonElement InstanceValue))
                {

                    string Value = InstanceValue.ToString();
                    if (Value.ToLower().StartsWith("problemdetails/"))
                    {
                        Source = Value;
                        if (TryGetProperty(JsonResponse, "title",
                            out var TitleValue))
                        {
                            Message = TitleValue.ToString();
                        }

                        if (TryGetProperty(JsonResponse, "detail",
                            out var DetailValue))
                        {
                            Message = $"{Message} {DetailValue}";
                        }
                        if (TryGetProperty(JsonResponse, "errors",
                            out JsonElement ErrorsValue))
                        {
                            Errors = JsonSerializer
                                .Deserialize<IEnumerable<ValidationError>>(
                                ErrorsValue);
                        }

                        IsValidProblemDetails = true;
                    }
                }
            }
            catch { }

            if (!IsValidProblemDetails)
            {
                Message = ErrorMessage;
                Source = null;
                Errors = null;
            }


            var Ex = new HttpRequestException(Message, null,
                Response.StatusCode);
            Ex.Source = Source;

            if (Errors != null) Ex.Data.Add("Errors", Errors);

            throw Ex;
        }

        return Response;
    }


    bool TryGetProperty(JsonElement element, string propertyName,
        out JsonElement value)
    {
        bool Found = false;
        value = default;

        var Property = element.EnumerateObject()
            .FirstOrDefault(e => string.Compare(e.Name,
            propertyName, StringComparison.OrdinalIgnoreCase) == 0);

        if (Property.Value.ValueKind != JsonValueKind.Undefined)
        {
            value = Property.Value;
            Found = true;
        }

        return Found;
    }
}

