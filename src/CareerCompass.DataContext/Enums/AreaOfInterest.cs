using System.ComponentModel;

namespace CareerCompass.DataContext.Enums
{
    public enum AreaOfInterest
    {
        None = 0,

        [Description("STEM & Technology")]
        STEM_Technology,

        [Description("Health & Life Sciences")]
        Health_LifeSciences,

        [Description("Business & Economics")]
        Business_Economics,

        [Description("Humanities & Social Sciences")]
        Humanities_Social_Sciences,

        [Description("Arts, Design & Communication")]
        Arts_Design_Communication,

        [Description("Education & Social Work")]
        Education_Social_Work,

        [Description("Interdisciplinary & Emerging Fields")]
        Interdisciplinary_Emerging_Fields
    }
}
