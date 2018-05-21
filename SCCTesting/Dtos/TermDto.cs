using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SCCTesting.Dtos
{
    public class TermDto
    {
        public int Id { get; set; }
        
        public string Semester { get; set; }

        public bool IsCurrent { get; set; }

        [JsonIgnore]
        public ICollection<ProfessorTermDto> ProfessorTerms { get; set; }
    }
}
