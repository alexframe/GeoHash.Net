namespace GeoHash.Net.Models.GeoCoords
{
    public class GeoCoordinateWithError : IGeoCoordinateWithError
    {
        public double LatitudeError { get; set; }
        public double LongitudeError { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
