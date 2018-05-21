using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCCTesting.Models
{
    public class ProfessorTerm
    {
        [Column(Order = 0)]
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        [Column(Order = 1)]
        public int TermId { get; set; }
        public Term Term { get; set; }

        public ICollection<ProfessorTermCourse> ProfessorTermCourses { get; set; }
    }
}
