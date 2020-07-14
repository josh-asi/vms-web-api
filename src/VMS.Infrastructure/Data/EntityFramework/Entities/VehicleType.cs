using System;
using System.Collections.Generic;

namespace VMS.Infrastructure.Data.EntityFramework.Entities
{
    public partial class VehicleType
    {
        public VehicleType()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
