namespace GeoHash.Net.Models.GeoCoords
{
    public interface IGeoCoordinateWithError : IGeoCoordinate
    {
        double LatitudeError { get; set; }
        double LongitudeError { get; set; }
    }
}
