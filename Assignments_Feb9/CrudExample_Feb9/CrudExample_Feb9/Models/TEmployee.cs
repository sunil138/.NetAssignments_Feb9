using System;
using System.Collections.Generic;

namespace CrudExample_Feb9.Models
{
    public partial class TEmployee
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? Address { get; set; }
        public int? Salary { get; set; }
        public int? Age { get; set; }
    }
}
