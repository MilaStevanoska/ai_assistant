using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCompass.DataContext.Entities
{
    public class UserExport
    {
        public UserExport()
        {
        }
        public UserExport(int id, String jobTitle, String why, String salaryRange, String educationPath, List<String> alternatives)
        {
            Id = id;
            JobTitle = jobTitle;
            Why = why;
            SalaryRange = salaryRange;
            EducationPath = educationPath;
            Alternatives = alternatives;
        }

        [Key]
        public int Id { get; set; }  

        public string JobTitle { get; set; }

        public string Why { get; set; }

        public string SalaryRange { get; set; }

        public string EducationPath { get; set; }

        public List<string> Alternatives { get; set; }
    }
}
