using System;
using System.Collections.Generic;
using System.Text;
using GeoHash.Net.Models.GeoCoords;
using GeoHash.Net.Utilities.Enums;
using GeoHash.Net.Utilities.Helpers;

namespace GeoHash.Net.Utilities.Encoders
{
    public class GeoHashEncoder : IGeoHashEncoder
    {
        private readonly int[] _bits;
        private readonly char[] _base32;

        public GeoHashEncoder() : this(GeoHashHelpers.GetBits(), GeoHashHelpers.GetBase32Chars()) { }

        public GeoHashEncoder(int[] bits, char[] base32Chars)
        {
            _bits = bits;
            _base32 = base32Chars;
        }

        public string Encode(double latitude, double longitude, GeoHashPrecision precision = GeoHashPrecision.Level12)
        {
            if (latitude < -90 || latitude > 90)
                throw new ArgumentOutOfRangeException($"{nameof(latitude)} must be between -90 and 90.");

            if (longitude < -180 || longitude > 180)
                throw new ArgumentOutOfRangeException($"{nameof(longitude)} must be between -180 and 180.");

            double latMin = -90, latMax = 90;
            double lngMin = -180, lngMax = 180;

            var geoHash = new StringBuilder();
            var isEven = true;
            int bit = 0, ch = 0;

            while (geoHash.Length < (int)precision)
            {
                double midPoint;
                if (isEven)
                {
                    midPoint = (lngMin + lngMax) / 2;
                    if (longitude > midPoint)
                    {
                        ch |= _bits[bit];
                        lngMin = midPoint;
                    }
                    else
                    {
                        lngMax = midPoint;
                    }
                }
                else
                {
                    midPoint = (latMin + latMax) / 2;
                    if (latitude > midPoint)
                    {
                        ch |= _bits[bit];
                        latMin = midPoint;
                    }
                    else
                    {
                        latMax = midPoint;
                    }
                }

                isEven = !isEven;

                if (bit < 4)
                {
                    bit++;
                }
                else
                {
                    geoHash.Append(_base32[ch]);
                    bit = 0;
                    ch = 0;
                }
            }

            return geoHash.ToString();
        }

        public string Encode(IGeoCoordinate geoCoord, GeoHashPrecision precision = GeoHashPrecision.Level12)
        {
            if (geoCoord == null)
                throw new ArgumentNullException($"{nameof(geoCoord)} cannot be null.");

            return Encode(geoCoord.Latitude, geoCoord.Longitude, precision);
        }

        public IEnumerable<KeyValuePair<string, string>> Encode(IEnumerable<KeyValuePair<string, IGeoCoordinate>> geoCoords, GeoHashPrecision precision = GeoHashPrecision.Level12)
        {
            foreach (var geoCoord in geoCoords)
            {
                yield return new KeyValuePair<string, string>(geoCoord.Key, Encode(geoCoord.Value, precision));
            }
        }

        public IEnumerable<string> Encode(IEnumerable<IGeoCoordinate> geoCoords, GeoHashPrecision precision = GeoHashPrecision.Level12)
        {
            foreach (var geoCoord in geoCoords)
            {
                yield return Encode(geoCoord);
            }
        }
    }
}
