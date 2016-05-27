using System;
using System.Collections.Generic;
using GeoHash.Net.GeoCoords;
using GeoHash.Net.Utilities.Helpers;

namespace GeoHash.Net.Utilities.Decoders
{
    public abstract class BaseDecoder
    {
        private readonly int[] _bits;
        private readonly IReadOnlyDictionary<char, int> _decodeMap;

        public BaseDecoder() : this(GeoHashHelpers.GetBits(), GeoHashHelpers.GetDecodeMap()) { }

        public BaseDecoder(int[] bits, IReadOnlyDictionary<char, int> decodeMap)
        {
            _bits = bits;
            _decodeMap = decodeMap;
        }

        private GeoCoordinateWithError DecodeExactly(string geohash)
        {
            double latMin = -90, latMax = 90;
            double lngMin = -180, lngMax = 180;

            var latErr = 90.0;
            var lngError = 180.0;
            var isEven = true;
            var size = geohash.Length;
            var bitsSize = _bits.Length;
            for (var i = 0; i < size; i++)
            {
                var cd = _decodeMap[geohash[i]];

                for (var j = 0; j < bitsSize; j++)
                {
                    var mask = _bits[j];
                    if (isEven)
                    {
                        lngError /= 2;
                        if ((cd & mask) != 0)
                        {
                            lngMin = (lngMin + lngMax) / 2;
                        }
                        else
                        {
                            lngMax = (lngMin + lngMax) / 2;
                        }
                    }
                    else
                    {
                        latErr /= 2;

                        if ((cd & mask) != 0)
                        {
                            latMin = (latMin + latMax) / 2;
                        }
                        else
                        {
                            latMax = (latMin + latMax) / 2;
                        }
                    }
                    isEven = !isEven;
                }
            }

            var latitude = (latMin + latMax) / 2;
            var longitude = (lngMin + lngMax) / 2;

            return new GeoCoordinateWithError(latitude, longitude, latErr, lngError);
        }

        public GeoCoordinate Decode(string geoHash)
        {
            var decodedCoords = DecodeExactly(geoHash);

            var latPrecision = Math.Max(1, Math.Round(-Math.Log10(decodedCoords.LatitudeError))) - 1;
            var lngPrecision = Math.Max(1, Math.Round(-Math.Log10(decodedCoords.LongitudeError))) - 1;

            var lat = GetPrecision(decodedCoords.Latitude, latPrecision);
            var lng = GetPrecision(decodedCoords.Longitude, lngPrecision);

            return new GeoCoordinate(lat, lng);
        }

        private static double GetPrecision(double x, double precision)
        {
            var @base = Math.Pow(10, -precision);
            var diff = x % @base;
            return x - diff;
        }
    }
}
