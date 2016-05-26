namespace GeoHash.Net.GeoCoords
{
    public struct GeoCoordinate
    {
        public double Latitude { get; }

        public double Longitude { get; }

        public GeoCoordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            return $"{Latitude},{Longitude}";
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
            return Latitude.Equals(other.Latitude) 
                && Longitude.Equals(other.Longitude);
        }
    }
}
