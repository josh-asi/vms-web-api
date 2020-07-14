namespace VMS.Api.UseCases.AddVehicle
{
    public sealed class AddVehicleRequest
    {
        public int Type { get; set; }
        public double Speed { get; set; }
        public double Mileage { get; set; }
    }
}
