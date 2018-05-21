using System.Collections.Generic;
using Newtonsoft.Json;

namespace SCCTesting.Dtos
{
    public class TestDto
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Password { get; set; }

        public string Comment { get; set; }

        public int ProfessorId { get; set; }
        public int TermId { get; set; }
        public int CourseId { get; set; }

        [JsonIgnore]
        public ProfessorTermCourseDto ProfessorTermCourse { get; set; }

        public ICollection<StudentTestDto> StudentTests { get; set; }

    }
}