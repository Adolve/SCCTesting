using System.Collections.Generic;
using Newtonsoft.Json;

namespace SCCTesting.Dtos
{
    public class ProfessorTermCourseDto
    {

        public int ProfessorId { get; set; }
        public int TermId { get; set; }
        [JsonIgnore]
        public ProfessorTermDto ProfessorTerm { get; set; }


        public int CourseId { get; set; }

        public CourseDto Course { get; set; }

        public ICollection<TestDto> Tests { get; set; }
    }
}