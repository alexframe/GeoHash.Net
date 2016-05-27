using System.Collections.Generic;
using GeoHash.Net.GeoCoords;
using GeoHash.Net.Utilities.Enums;

namespace GeoHash.Net.Utilities.Encoders
{
    public interface IGeoHashEncoder
    {
        string Encode(double latitude, double longitude, GeoHashPrecision precision = GeoHashPrecision.MaximumPrecision);

        string Encode(GeoCoordinate geoCoord, GeoHashPrecision precision = GeoHashPrecision.MaximumPrecision);

        IEnumerable<KeyValuePair<string, string>> Encode(IEnumerable<KeyValuePair<string, GeoCoordinate>> geoCoords, GeoHashPrecision precision = GeoHashPrecision.MaximumPrecision);

        IEnumerable<string> Encode(IEnumerable<GeoCoordinate> geoCoords, GeoHashPrecision precision = GeoHashPrecision.MaximumPrecision);

        IDictionary<string, string> Encode(IDictionary<string, GeoCoordinate> geoCoords, GeoHashPrecision precision = GeoHashPrecision.MaximumPrecision);
    }
}
