namespace CareerCompass.DataContext.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CareerCompass.DataContext.Enums;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

    public class AreaOfInterestConverter : ValueConverter<IEnumerable<AreaOfInterest>, string>
    {
        private static readonly char[] separator = [','];

        public AreaOfInterestConverter()
            : base(
                areasOfInterest => ConvertToString(areasOfInterest),
                value => ConvertToList(value))
        { }

        private static string ConvertToString(IEnumerable<AreaOfInterest> areasOfInterest)
        {
            if (areasOfInterest is null || !areasOfInterest.Any())
            {
                return string.Empty;
            }

            return string.Join(",", areasOfInterest.Select(s => ((int)s).ToString()));
        }

        private static List<AreaOfInterest> ConvertToList(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return [];
            }

            return value
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => (AreaOfInterest)int.Parse(s))
                .ToList();
        }
    }
}
