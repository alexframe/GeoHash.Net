using System;
using System.Collections.Generic;
using GeoHash.Net.GeoCoords;

namespace GeoHash.Net.Utilities.Decoders
{
    public interface IGeoHashDecoder<TKey>
    {
        GeoCoordinate Decode(string geoHash);
        Tuple<double, double> DecodeAsTuple(string geoHash);

        IEnumerable<GeoCoordinate> Decode(IEnumerable<string> geoHashes);

        IEnumerable<KeyValuePair<TKey, GeoCoordinate>> Decode(IEnumerable<KeyValuePair<TKey, string>> geoHashes);
        IDictionary<TKey, GeoCoordinate> Decode(IDictionary<TKey, GeoCoordinate> geoHashes);
    }
}
