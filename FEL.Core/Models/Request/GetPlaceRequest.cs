namespace FEL.Core.Models.Request
{
    public class GetPlaceRequest
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Distance { get; set; }
    }
}