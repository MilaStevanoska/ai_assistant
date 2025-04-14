using System.ComponentModel;

namespace CareerCompass.DataContext.Enums
{
    public enum CareerGoal
    {
        None = 0,

        #region STEM & Technology

        [Description("Computer Science & Software Engineering")]
        CS_Software,

        [Description("Information Technology & Cybersecurity")]
        IT_Cybersecurity,

        [Description("Electrical, Mechanical, or Civil Engineering")]
        Engineering,

        [Description("Mathematics, Physics, & Chemistry")]
        Math_Physics_Chem,

        [Description("Environmental Science & Earth Studies")]
        EnvironmentalScience,

        #endregion

        #region Health & Life Sciences

        [Description("Medicine & Nursing")]
        Medicine_Nursing,

        [Description("Biomedical Sciences & Biotechnology")]
        BiomedicalSciences,

        [Description("Public Health & Nutrition")]
        PublicHealth,

        [Description("Pharmacy & Dentistry")]
        Pharmacy_Dentistry,

        [Description("Veterinary Science")]
        VeterinaryScience,

        #endregion

        #region Business & Economics

        [Description("Business Administration & Management")]
        BusinessAdmin,

        [Description("Economics, Finance, & Accounting")]
        Economics_Finance,

        [Description("Marketing & Entrepreneurship")]
        Marketing_Entrepreneurship,

        [Description("International Business & Supply Chain Management")]
        IntlBusiness_SupplyChain,

        #endregion

        #region Humanities & Social Sciences

        [Description("History, Philosophy, & Literature")]
        Humanities,

        [Description("Political Science, International Relations, & Law")]
        Political_Science,

        [Description("Psychology, Sociology, & Anthropology")]
        SocialSciences,

        [Description("Languages & Cultural Studies")]
        Languages_CulturalStudies,

        #endregion

        #region Arts, Design & Communication

        [Description("Fine Arts, Visual Arts, & Photography")]
        FineArts,

        [Description("Graphic & Multimedia Design")]
        GraphicDesign,

        [Description("Film Production & Digital Media")]
        Film_DigitalMedia,

        [Description("Music, Dance, & Theatre")]
        Music_Dance_Theatre,

        #endregion

        #region Education & Social Work

        [Description("Education & Teaching")]
        Education_Teaching,

        [Description("Social Work & Community Development")]
        SocialWork,

        [Description("Public Policy & Administration")]
        PublicPolicy_Administration,

        #endregion

        #region Interdisciplinary & Emerging Fields

        [Description("Data Science & Analytics")]
        DataScience_Analytics,

        [Description("Artificial Intelligence & Robotics")]
        AI_Robotics,

        [Description("Sustainable Development & Renewable Energy")]
        SustainableDevelopment_RenewableEnergy

        #endregion
    }
}
