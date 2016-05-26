namespace GeoHash.Net.Models.GeoCoords
{
    public struct GeoCoordinateWithError
    {
        public double Latitude { get; }

        public double Longitude { get; }

        public double LatitudeError { get; }

        public double LongitudeError { get; }

        public GeoCoordinateWithError(double latitude, double longitude, double latitudeError, double longitudeError)
        {
            Latitude = latitude;
            Longitude = longitude;
            LongitudeError = latitudeError;
            LatitudeError = longitudeError;
        }

        public override string ToString()
        {
            return $"{Latitude},{Longitude}";
        }

        public override bool Equals(object other)
        {
            return other is GeoCoordinateWithError && Equals((GeoCoordinateWithError)other);
        }

        public override int GetHashCode()
        {
            return Latitude.GetHashCode() ^ Longitude.GetHashCode() & LatitudeError.GetHashCode() & LongitudeError.GetHashCode();
        }

        private bool Equals(GeoCoordinateWithError other)
        {
            return Latitude.Equals(other.Latitude) 
                && Longitude.Equals(other.Longitude)
                && LatitudeError.Equals(other.LatitudeError) 
                && LongitudeError.Equals(other.LongitudeError);
        }
    }
}
