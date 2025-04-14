namespace CareerCompass.DataContext.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CareerCompass.DataContext.Enums;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

    public class SkillsConverter : ValueConverter<IEnumerable<Skills>, string>
    {
        private static readonly char[] separator = [','];

        public SkillsConverter()
            : base(
                skills => ConvertToString(skills),
                value => ConvertToList(value))
        { }

        private static string ConvertToString(IEnumerable<Skills> skills)
        {
            if (skills is null || !skills.Any())
            {
                return string.Empty;
            }

            return string.Join(",", skills.Select(s => ((int)s).ToString()));
        }

        private static List<Skills> ConvertToList(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return [];
            }

            return value
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => (Skills)int.Parse(s))
                .ToList();
        }
    }
}
