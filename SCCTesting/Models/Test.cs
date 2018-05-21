using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SCCTesting.Models
{
    public class Test
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Number { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [StringLength(255)]
        public string Comment { get; set; }

        public int ProfessorId { get; set; }
        public int TermId { get; set; }
        public int CourseId { get; set; }

        public ProfessorTermCourse ProfessorTermCourse { get; set; }

        public ICollection<StudentTest> StudentTests { get; set; }
    }
}
