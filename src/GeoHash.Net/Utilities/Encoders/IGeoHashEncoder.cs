using System.Collections.Generic;
using GeoHash.Net.Models.GeoCoords;
using GeoHash.Net.Utilities.Enums;

namespace GeoHash.Net.Utilities.Encoders
{
    public interface IGeoHashEncoder
    {
        string Encode(double latitude, double longitude, GeoHashPrecision precision = GeoHashPrecision.Level12);

        string Encode(GeoCoordinate geoCoord, GeoHashPrecision precision = GeoHashPrecision.Level12);

        IEnumerable<KeyValuePair<string, string>> Encode(IEnumerable<KeyValuePair<string, GeoCoordinate>> geoCoords, GeoHashPrecision precision = GeoHashPrecision.Level12);

        IEnumerable<string> Encode(IEnumerable<GeoCoordinate> geoCoords, GeoHashPrecision precision = GeoHashPrecision.Level12);
    }
}
