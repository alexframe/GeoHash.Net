using System;
using System.Collections.Generic;
using System.Linq;
using GeoHash.Net.GeoCoords;
using GeoHash.Net.Utilities.Encoders;
using GeoHash.Net.Utilities.Enums;

namespace GeoHash.Net.Utilities.Matchers
{
    public class GeoHashMatcher<TKey> : IGeoHashMatcher<TKey>
    {
        private readonly IGeoHashEncoder<TKey> _encoder;


        public GeoHashMatcher() : this(new GeoHashEncoder<TKey>()) { }

        public GeoHashMatcher(IGeoHashEncoder<TKey> encoder)
        {
            _encoder = encoder;
        }

        public bool IsMatch(GeoCoordinate source, GeoCoordinate comparer, GeoHashPrecision precision)
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

            if (source.Length < (int) GeoHashPrecision.MinimumPrecision
                || source.Length > (int) GeoHashPrecision.MaximumPrecision
                || comparer.Length < (int) GeoHashPrecision.MinimumPrecision
                || comparer.Length > (int) GeoHashPrecision.MaximumPrecision)
            {
                throw new ArgumentOutOfRangeException(
                    $"{nameof(source)} and {nameof(comparer)} must have a length between 1 and 12.");
            }


            /* 
             * If the source length is greater than the precision, we'll truncate it 
             * so that we can do a "StartsWith" to determine if it's a match.
             */
            if (source.Length > (int)precision)
                source = source.Substring(0, (int)precision);

            return comparer.StartsWith(source, StringComparison.OrdinalIgnoreCase);
        }

        public IEnumerable<string> GetMatches(string source, IEnumerable<string> comparers, GeoHashPrecision precision)
        {
            if (comparers == null)
                throw new ArgumentNullException($"{nameof(comparers)} cannot be null.");

            source = source.Substring(0, (int)precision);

            return comparers.AsParallel().Where(x => IsMatch(source, x, precision));
        }

        public IEnumerable<KeyValuePair<TKey, string>> GetMatches(string source, IEnumerable<KeyValuePair<TKey, string>> comparers, GeoHashPrecision precision)
        {
            if (comparers == null)
                throw new ArgumentNullException($"{nameof(comparers)} cannot be null.");

            source = source.Substring(0, (int)precision);

            return comparers.AsParallel().Where(x => IsMatch(source, x.Value, precision));
        }
    }
}
