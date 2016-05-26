using System;
using System.Collections.Generic;
using GeoHash.Net.Models.GeoCoords;
using GeoHash.Net.Utilities.Decoders;
using GeoHash.Net.Utilities.Encoders;
using GeoHash.Net.Utilities.Enums;
using GeoHash.Net.Utilities.Matchers;

namespace GeoHash.Net.Utilities
{
    public class GeoHashUtility : IGeoHashUtility
    {
        private readonly IGeoHashEncoder _encoder;
        private readonly IGeoHashDecoder _decoder;
        private readonly IGeoHashMatcher _matcher;

        public GeoHashUtility() : this(new GeoHashEncoder(), new GeoHashDecoder(), new GeoHashMatcher()) { }

        public GeoHashUtility(IGeoHashEncoder encoder, IGeoHashDecoder decoder, IGeoHashMatcher matcher)
        {
            _encoder = encoder;
            _decoder = decoder;
            _matcher = matcher;
        }

        public string Encode(double latitude, double longitude, GeoHashPrecision precision = GeoHashPrecision.Level12)
        {
            return _encoder.Encode(latitude, longitude, precision);
        }

        public string Encode(GeoCoordinate geoCoord, GeoHashPrecision precision = GeoHashPrecision.Level12)
        {
            return _encoder.Encode(geoCoord, precision);
        }

        public IEnumerable<KeyValuePair<string, string>> Encode(IEnumerable<KeyValuePair<string, GeoCoordinate>> geoCoords, GeoHashPrecision precision = GeoHashPrecision.Level12)
        {
            return _encoder.Encode(geoCoords, precision);
        }

        public IEnumerable<string> Encode(IEnumerable<GeoCoordinate> geoCoords, GeoHashPrecision precision = GeoHashPrecision.Level12)
        {
            return _encoder.Encode(geoCoords);
        }

        public GeoCoordinate Decode(string geoHash)
        {
            return _decoder.Decode(geoHash);
        }

        public Tuple<double, double> DecodeAsTuple(string geoHash)
        {
            return _decoder.DecodeAsTuple(geoHash);
        }

        public bool IsMatch(GeoCoordinate source, GeoCoordinate comparer, GeoHashPrecision precision)
        {
            return _matcher.IsMatch(source, comparer, precision);
        }

        public bool IsMatch(string source, string comparer, GeoHashPrecision precision)
        {
            return _matcher.IsMatch(source, comparer, precision);
        }

        public IEnumerable<string> GetMatches(string source, IEnumerable<string> comparers, GeoHashPrecision precision)
        {
            return _matcher.GetMatches(source, comparers, precision);
        }

        public IEnumerable<KeyValuePair<string, string>> GetMatches(string source, IEnumerable<KeyValuePair<string, string>> comparers, GeoHashPrecision precision)
        {
            return _matcher.GetMatches(source, comparers, precision);
        }
    }
}
