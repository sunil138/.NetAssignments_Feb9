using System;
using System.Collections.Generic;

namespace StudentCrudMVC_Feb9.Models
{
    public partial class StudentDetail
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }
        public int? CourseId { get; set; }
    }
}
