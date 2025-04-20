using System.ComponentModel;

namespace CareerCompass.Services.Extensions
{
    public static class EnumExtensions
    {
        public static string? GetDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            if (fi != null
                && Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute))
                      is DescriptionAttribute desc)
            {
                return desc.Description;
            }

            return null;
        }
    }
}
