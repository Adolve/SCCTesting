using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SCCTesting.Models
{
    public class Professor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(80)]
        public string Email { get; set; }

        //public ICollection<ProfessorTermCourse> ProfessorTermCourses { get; set; }
        public ICollection<ProfessorTerm> ProfessorTerms { get; set; }

        
    }
}
