﻿namespace NorthWind.Sales.Backend.EFCore.Options
{
    public class DBOptions
    {
        public const string SectionKey = nameof(DBOptions);
        public string ConnectionString {  get; set; }
    }
}
