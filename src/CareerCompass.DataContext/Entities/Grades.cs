using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCompass.DataContext.Entities
{
    [ComplexType]
    public class Grades
    {
        public short? Mathematics { get; set; }

        public short? Biology { get; set; }

        public short? Chemistry { get; set; }

        public short? German { get; set; }

        public short? English { get; set; }

        public short? French { get; set; }

        public short? Geography { get; set; }

        public short? Algebra { get; set; }

        public short? Informatics { get; set; }

        public short? History { get; set; }

        public short? Sport { get; set; }

        public short? Art { get; set; }

        public short? MusicEducation { get; set; }

        public short? LinearAlgebra { get; set; }

        public short? Physics { get; set; }

        public short? Sociology { get; set; }

        public short? ProgrammingLanguages { get; set; }

        public short? Business { get; set; }

        public short? Psychology { get; set; }
    }
}
