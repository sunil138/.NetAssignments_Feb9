﻿using System;
using System.Collections.Generic;

namespace EmpCrud_MVC_Feb9.Models
{
    public partial class TEmployee
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? Age { get; set; }
        public int? Salary { get; set; }
        public string? Designation { get; set; }
    }
}
