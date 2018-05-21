using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SCCTesting.Models.Enums;

namespace SCCTesting.Models
{
    public class StudentTest
    {
        [Key, Column(Order = 0)]
        [Required]
        public string StudentId { get; set; }
        public Student Student { get; set; }

        [Key, Column(Order = 1)]
        public int TestId { get; set; }
        public Test Test { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public StudentTestRequest StudentTestRequest { get; set; }
    }
}
