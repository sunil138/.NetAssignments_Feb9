using System;
using System.Collections.Generic;

namespace StudentCourseCrudMVC_Feb9.Models
{
    public partial class CourseDetail
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public int? Fee { get; set; }
        public string? Result { get; set; }
    }
}
