using System;
using VMS.Domain.SeedWork;

namespace VMS.Domain.Aggregates.VehicleAggregate
{
    public class Kilometres : ValueObject
    {
        private float kilometres = 0.0f;

        public Kilometres(float kilometres)
        {
            this.kilometres = kilometres;
        }

        public void UpdateMileage(float kilometres)
        {
            if (kilometres < this.kilometres) throw new InvalidOperationException("The new mileage entered is smaller than the current mileage.");

            this.kilometres = kilometres;
        }

        public static implicit operator float(Kilometres kilometres)
        {
            return kilometres.kilometres;
        }

        public static implicit operator Kilometres(float kilometres)
        {
            return new Kilometres(kilometres);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj is float single ? single == kilometres : ((Kilometres)obj).kilometres == kilometres;
        }
    }
}
