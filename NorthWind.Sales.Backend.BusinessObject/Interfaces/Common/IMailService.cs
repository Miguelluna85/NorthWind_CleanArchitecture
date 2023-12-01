namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Common;
internal interface IMailService
{
    ValueTask SendMailToAdministrator(string subject, string body);
}
