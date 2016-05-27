using System.Collections.Generic;
using System.Linq;
using GeoHash.Net.GeoCoords;
using GeoHash.Net.Utilities.Enums;
using GeoHash.Net.Utilities.Helpers;

namespace GeoHash.Net.Utilities.Encoders
{
    public class GeoHashEncoder<TKey> : BaseEncoder, IGeoHashEncoder<TKey>
    {
        public GeoHashEncoder() : this(GeoHashHelpers.GetBits(), GeoHashHelpers.GetBase32Chars()) { }

        public GeoHashEncoder(int[] bits, char[] base32Chars) : base(bits, base32Chars) { }

        public string Encode(GeoCoordinate geoCoord, GeoHashPrecision precision = GeoHashPrecision.MaximumPrecision)
        {
            return Encode(geoCoord.Latitude, geoCoord.Longitude, precision);
        }

        public IEnumerable<KeyValuePair<TKey, string>> Encode(IEnumerable<KeyValuePair<TKey, GeoCoordinate>> geoCoords, GeoHashPrecision precision = GeoHashPrecision.MaximumPrecision)
        {
            return geoCoords.AsParallel().Select(geoCoord => new KeyValuePair<TKey, string>(geoCoord.Key, Encode(geoCoord.Value, precision)));
        }

        public IDictionary<TKey, string> Encode(IDictionary<TKey, GeoCoordinate> geoCoords, GeoHashPrecision precision = GeoHashPrecision.MaximumPrecision)
        {
            var kvp = geoCoords.Cast<KeyValuePair<TKey, GeoCoordinate>>();
            return Encode(kvp, precision).ToDictionary(x => x.Key, x => x.Value);
        }

        public IEnumerable<string> Encode(IEnumerable<GeoCoordinate> geoCoords, GeoHashPrecision precision = GeoHashPrecision.MaximumPrecision)
        {
            return geoCoords.AsParallel().Select(geoCoord => Encode(geoCoord, precision));
        }
    }
}
