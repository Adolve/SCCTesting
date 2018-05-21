using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SCCTesting.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<ProfessorTermCourseDto> ProfessorTermCourses { get; set; }

        
    }
}
