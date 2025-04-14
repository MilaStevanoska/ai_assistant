using System.ComponentModel;

namespace CareerCompass.DataContext.Enums
{
    public enum Skills
    {
        [Description("None")]
        None = 0,

        #region Technology & Digital Skills

        [Description("Software Development")]
        SoftwareDev = 1,

        [Description("Data Analysis & Visualization")]
        DataAnalysis = 2,

        [Description("Cybersecurity & Ethical Hacking")]
        Cybersecurity = 3,

        [Description("Graphic Design")]
        GraphicDesign = 4,

        #endregion

        #region Crafts & Artisanal Skills

        [Description("Sewing, Knitting, & Textile Arts")]
        Sewing = 5,

        [Description("Woodworking")]
        Woodworking = 6,

        [Description("Pottery")]
        Pottery = 7,

        [Description("Metalworking")]
        Metalworking = 8,

        #endregion

        #region Creative Arts

        [Description("Photography & Videography")]
        Photography = 9,

        [Description("Painting")]
        Painting = 10,

        [Description("Animation & Motion Graphics")]
        Animation = 11,

        [Description("Music Production")]
        MusicProduction = 12,

        #endregion

        #region Practical & DIY Skills

        [Description("Cooking")]
        Cooking = 13,

        [Description("Gardening")]
        Gardening = 14,

        [Description("Home Improvement")]
        HomeImprovement = 15,

        [Description("Auto Maintenance")]
        AutoMaintenance = 16,

        #endregion

        #region Other Professional/Applied Skills

        [Description("Digital Marketing & Content Creation")]
        DigitalMarketing = 17,

        [Description("Event Planning")]
        EventPlanning = 18,

        [Description("Foreign Language Proficiency")]
        ForeignLanguage = 19,

        [Description("Financial Literacy")]
        FinancialLiteracy = 20

        #endregion
    }
}
