using System;
using System.Collections.Generic;

namespace StudentExampleCrud_Feb9.Models
{
    public partial class TStudent
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? Address { get; set; }
        public int? Age { get; set; }
    }
}
