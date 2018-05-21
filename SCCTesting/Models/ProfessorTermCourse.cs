using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCCTesting.Models
{
    public class ProfessorTermCourse
    {
        [Column(Order = 0)]
        public int ProfessorId { get; set; }
        [Column(Order = 1)]
        public int TermId { get; set; }
        public ProfessorTerm ProfessorTerm { get; set; }

        [Column(Order = 2)]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<Test> Tests { get; set; }

    }
}
