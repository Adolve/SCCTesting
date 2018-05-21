using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SCCTesting.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        [StringLength(80)]
        public string Description { get; set; }

        public ICollection<ProfessorTermCourse> ProfessorTermCourses { get; set; }

        //public List<Test> Tests { get; set; }
    }
}
