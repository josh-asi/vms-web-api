namespace VMS.Application.DTOs.Vehicle
{
    public sealed class VehicleDTO
    {
        public int Id { get; set; }
        public double Speed { get; set; }
        public double Mileage { get; set; }
        public string Type { get; set; }
        //public Location Location { get; set; }

        public VehicleDTO() { }

        public VehicleDTO(int id, double speed, double mileage, string type)
        {
            Id = id;
            Speed = speed;
            Mileage = mileage;
            Type = type;
        }
    }
}
