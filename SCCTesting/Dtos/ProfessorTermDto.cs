using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SCCTesting.Dtos
{
    public class ProfessorTermDto
    {
        
        public int ProfessorId { get; set; }

        [JsonIgnore]
        public ProfessorDto Professor { get; set; }

        
        public int TermId { get; set; }
        public TermDto Term { get; set; }

        
        public ICollection<ProfessorTermCourseDto> ProfessorTermCourses { get; set; }
    }
}
