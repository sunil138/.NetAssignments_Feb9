using System;
using System.Collections.Generic;

namespace VehicleCrudWebAPI_Feb9.Models
{
    public partial class VehicleDetail
    {
        public int VehicleId { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }
        public int? Model { get; set; }
        public string? VehicleType { get; set; }
    }
}
