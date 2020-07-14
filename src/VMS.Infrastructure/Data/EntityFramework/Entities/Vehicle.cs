using System;
using System.Collections.Generic;

namespace VMS.Infrastructure.Data.EntityFramework.Entities
{
    public partial class Vehicle
    {
        public int Id { get; set; }
        public DateTime CreatedDttm { get; set; }
        public double Speed { get; set; }
        public int Type { get; set; }
        public double Mileage { get; set; }

        public virtual VehicleType TypeNavigation { get; set; }
    }
}
