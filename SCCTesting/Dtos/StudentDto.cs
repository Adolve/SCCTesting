using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SCCTesting.Dtos
{
    public class StudentDto
    {
        public string Id { get; set; }
      
        public string FirstNames { get; set; }
   
        public string LastName { get; set; }

        [JsonIgnore]
        public ICollection<StudentTestDto> StudentTests { get; set; }
    }
}
