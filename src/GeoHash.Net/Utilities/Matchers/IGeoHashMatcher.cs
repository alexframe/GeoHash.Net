using System.Collections.Generic;
using GeoHash.Net.GeoCoords;
using GeoHash.Net.Utilities.Enums;

namespace GeoHash.Net.Utilities.Matchers
{
    public interface IGeoHashMatcher<TKey>
    {
        bool IsMatch(GeoCoordinate source, GeoCoordinate comparer, GeoHashPrecision precision);

        bool IsMatch(string source, string comparer, GeoHashPrecision precision);

        IEnumerable<string> GetMatches(string source, IEnumerable<string> comparers, GeoHashPrecision precision);
        IEnumerable<KeyValuePair<TKey, string>> GetMatches(string source, IEnumerable<KeyValuePair<TKey, string>> comparers, GeoHashPrecision precision);
    }
}
