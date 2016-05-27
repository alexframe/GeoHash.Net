using System;
using System.Collections.Generic;
using System.Linq;
using GeoHash.Net.GeoCoords;
using GeoHash.Net.Utilities.Helpers;

namespace GeoHash.Net.Utilities.Decoders
{
    public class GeoHashDecoder<TKey> : BaseDecoder, IGeoHashDecoder<TKey>
    {
        public GeoHashDecoder() : this(GeoHashHelpers.GetBits(), GeoHashHelpers.GetDecodeMap()) { }

        public GeoHashDecoder(int[] bits, IReadOnlyDictionary<char, int> decodeMap) : base(bits, decodeMap) { }

        public Tuple<double, double> DecodeAsTuple(string geoHash)
        {
            var decoded = Decode(geoHash);
            return Tuple.Create(decoded.Latitude, decoded.Longitude);
        }

        public IEnumerable<GeoCoordinate> Decode(IEnumerable<string> geoHashes)
        {
            return geoHashes.AsParallel().Select(Decode);
        }

        public IEnumerable<KeyValuePair<TKey, GeoCoordinate>> Decode(IEnumerable<KeyValuePair<TKey, string>> geoHashes)
        {
            return geoHashes.AsParallel().Select(geoHash => new KeyValuePair<TKey, GeoCoordinate>(geoHash.Key, Decode(geoHash.Value)));
        }

        public IDictionary<TKey, GeoCoordinate> Decode(IDictionary<TKey, GeoCoordinate> geoHashes)
        {
            var kvp = geoHashes.Cast<KeyValuePair<TKey, string>>();
            return Decode(kvp).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
