using System;
using System.Collections.Generic;

namespace SunilStudent_Feb9.Models
{
    public partial class StudentDetail
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentAddress { get; set; }
        public int? StudentAge { get; set; }
        public int? CourseId { get; set; }

        public virtual CourseDetail? Course { get; set; }
    }
}
