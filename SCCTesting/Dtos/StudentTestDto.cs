using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SCCTesting.Models.Enums;

namespace SCCTesting.Dtos
{
    public class StudentTestDto
    {

        public string StudentId { get; set; }
        public StudentDto Student { get; set; }

        public int TestId { get; set; }
        [JsonIgnore]
        public TestDto Test { get; set; }

        public DateTime Date { get; set; }

        public StudentTestRequest StudentTestRequest { get; set; }
    }
}
