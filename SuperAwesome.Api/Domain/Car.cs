namespace SuperAwesome.Api.Domain
{
    public class Car : BaseDomain<int>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public double Mileage { get; set; }
        public string Plate { get; set; }
    }
}