using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCompass.DataContext.Converters
{
    public class AlternativesConverter : ValueConverter<List<string>, string>
    {
        private static readonly char[] separator = [','];

        public AlternativesConverter() 
            : base(
            list => ConvertToString(list),       
            value => ConvertToList(value)
            )         
        { }

        private static string ConvertToString(List<string> list)
        {
            return list == null ? string.Empty : string.Join(",", list);
        }

        private static List<string> ConvertToList(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? new List<string>() : value.Split(separator).ToList();
        }
    }
}
