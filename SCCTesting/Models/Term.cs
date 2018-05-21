using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SCCTesting.Models
{
    public class Term
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Semester { get; set; }

        public bool IsCurrent { get; set; }


        //public ICollection<ProfessorTermCourse> ProfessorTermCourses { get; set; }
        //public ICollection<Course> Courses { get; set; }
        
        public ICollection<ProfessorTerm> ProfessorTerms { get; set; }
    }
}
