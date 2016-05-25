using System;
using System.Collections.Generic;
using GeoHash.Net.Models.GeoCoords;
using GeoHash.Net.Utilities.Encoders;
using GeoHash.Net.Utilities.Enums;

namespace GeoHash.Net.Utilities.Matchers
{
    public class GeoHashMatcher : IGeoHashMatcher
    {
        private readonly IGeoHashEncoder _encoder;


        public GeoHashMatcher() : this(new GeoHashEncoder()) { }

        public GeoHashMatcher(IGeoHashEncoder encoder)
        {
            _encoder = encoder;
        }

        public bool IsMatch(IGeoCoordinate source, IGeoCoordinate comparer, GeoHashPrecision precision)
        {
            var sourceGeoHash = _encoder.Encode(source);
            var comparerGeoHash = _encoder.Encode(comparer);

            return IsMatch(sourceGeoHash, comparerGeoHash, precision);
        }

        public bool IsMatch(string source, string comparer, GeoHashPrecision precision)
        {
            if (source.Length < (int)precision)
                throw new ArgumentOutOfRangeException($"{nameof(source)} should be greater than or equal to {nameof(precision)}.");

            if (comparer.Length < (int)precision)
                throw new ArgumentOutOfRangeException($"{nameof(comparer)} should be greater than or equal to {nameof(precision)}.");

            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(comparer))
                throw new ArgumentOutOfRangeException($"{nameof(source)} and {nameof(comparer)} cannot be null.");

            if (source.Length < 1 || source.Length > 12 || comparer.Length < 1 || comparer.Length > 12)
                throw new ArgumentOutOfRangeException($"{nameof(source)} and {nameof(comparer)} must have a length between 1 and 12.");


            /* 
             * If the source length is greater than the precision, we'll truncate it
             * so that we can do a "StartsWith" to determine if it's a match.
             */
            if (source.Length > (int)precision)
                source = source.Substring(0, (int)precision);

            return comparer.StartsWith(source);
        }

        public IEnumerable<string> GetMatches(string source, IEnumerable<string> comparers, GeoHashPrecision precision)
        {
            if (comparers == null)
                throw new ArgumentNullException($"{nameof(comparers)} cannot be null.");

            source = source.Substring(0, (int)precision);

            foreach (var comparer in comparers)
            {
                if (IsMatch(source, comparer, precision))
                    yield return comparer;
            }
        }

        public IEnumerable<KeyValuePair<string, string>> GetMatches(string source, IEnumerable<KeyValuePair<string, string>> comparers, GeoHashPrecision precision)
        {
            if (comparers == null)
                throw new ArgumentNullException($"{nameof(comparers)} cannot be null.");

            source = source.Substring(0, (int) precision);

            foreach (var comparer in comparers)
            {
                if (IsMatch(source, comparer.Value, precision))
                    yield return comparer;
            }
        }
    }
}
