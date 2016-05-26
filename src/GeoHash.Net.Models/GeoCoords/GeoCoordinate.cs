namespace GeoHash.Net.Models.GeoCoords
{
    public struct GeoCoordinate
    {
        private readonly double _latitude;
        private readonly double _longitude;

        public double Latitude => _latitude;
        public double Longitude => _longitude;

        public GeoCoordinate(double latitude, double longitude)
        {
            _latitude = latitude;
            _longitude = longitude;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", Latitude, Longitude);
        }

        public override bool Equals(object other)
        {
            return other is GeoCoordinate && Equals((GeoCoordinate)other);
        }

        public override int GetHashCode()
        {
            return Latitude.GetHashCode() ^ Longitude.GetHashCode();
        }

        private bool Equals(GeoCoordinate other)
        {
            return Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude);
        }
    }
}
