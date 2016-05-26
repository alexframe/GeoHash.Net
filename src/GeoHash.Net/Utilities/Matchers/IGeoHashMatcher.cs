using System.Collections.Generic;
using GeoHash.Net.GeoCoords;
using GeoHash.Net.Utilities.Enums;

namespace GeoHash.Net.Utilities.Matchers
{
    public interface IGeoHashMatcher
    {
        bool IsMatch(GeoCoordinate source, GeoCoordinate comparer, GeoHashPrecision precision);

        bool IsMatch(string source, string comparer, GeoHashPrecision precision);

        IEnumerable<string> GetMatches(string source, IEnumerable<string> comparers, GeoHashPrecision precision);
        IEnumerable<KeyValuePair<string, string>> GetMatches(string source, IEnumerable<KeyValuePair<string, string>> comparers, GeoHashPrecision precision);
    }
}
