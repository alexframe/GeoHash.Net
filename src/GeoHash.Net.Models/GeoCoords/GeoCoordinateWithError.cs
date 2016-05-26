namespace GeoHash.Net.Models.GeoCoords
{
    public struct GeoCoordinateWithError
    {

        private readonly double _latitude;
        private readonly double _longitude;
        private readonly double _latitudeError;
        private readonly double _longitudeError;

        public double Latitude => _latitude;
        public double Longitude => _longitude;

        public double LatitudeError => _longitudeError;
        public double LongitudeError => _latitudeError;

        public GeoCoordinateWithError(double latitude, double longitude, double latitudeError, double longitudeError)
        {
            _latitude = latitude;
            _longitude = longitude;
            _latitudeError = latitudeError;
            _longitudeError = longitudeError;
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
            return Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude)
                && LatitudeError.Equals(other.LatitudeError) && LongitudeError.Equals(other.LongitudeError);
        }
    }
}
