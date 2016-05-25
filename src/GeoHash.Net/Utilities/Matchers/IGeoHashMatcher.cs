using System.Collections.Generic;
using GeoHash.Net.Models.GeoCoords;
using GeoHash.Net.Utilities.Enums;

namespace GeoHash.Net.Utilities.Matchers
{
    public interface IGeoHashMatcher
    {
        bool IsMatch(IGeoCoordinate source, IGeoCoordinate comparer, GeoHashPrecision precision);

        bool IsMatch(string source, string comparer, GeoHashPrecision precision);

        IEnumerable<string> GetMatches(string source, IEnumerable<string> comparers, GeoHashPrecision precision);
        IEnumerable<KeyValuePair<string, string>> GetMatches(string source, IEnumerable<KeyValuePair<string, string>> comparers, GeoHashPrecision precision);
    }
}
