using System.Collections.Generic;
using GeoHash.Net.GeoCoords;
using GeoHash.Net.Utilities.Enums;

namespace GeoHash.Net.Utilities.Encoders
{
    public interface IGeoHashEncoder<TKey>
    {
        string Encode(double latitude, double longitude, GeoHashPrecision precision = GeoHashPrecision.MaximumPrecision);

        string Encode(GeoCoordinate geoCoord, GeoHashPrecision precision = GeoHashPrecision.MaximumPrecision);

        IEnumerable<KeyValuePair<TKey, string>> Encode(IEnumerable<KeyValuePair<TKey, GeoCoordinate>> geoCoords, GeoHashPrecision precision = GeoHashPrecision.MaximumPrecision);

        IEnumerable<string> Encode(IEnumerable<GeoCoordinate> geoCoords, GeoHashPrecision precision = GeoHashPrecision.MaximumPrecision);

        IDictionary<TKey, string> Encode(IDictionary<TKey, GeoCoordinate> geoCoords, GeoHashPrecision precision = GeoHashPrecision.MaximumPrecision);
    }
}
