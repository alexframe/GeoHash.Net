using GeoHash.Net.Utilities.Encoders;
using GeoHash.Net.Utilities.Enums;
using Xunit;

namespace GeoHash.Net.Tests.Encoding
{
    public class EncodingTests
    {
        private const double BuckingHamPalaceLatitude = 51.501568;
        private const double BuckingHamPalaceLongitude = -0.141257;
        private const string BuckingHamPalaceGeoHash = "gcpuuz94kkp5";

        [Theory]
        [InlineData(BuckingHamPalaceLatitude, BuckingHamPalaceLongitude, GeoHashPrecision.Level1)]
        [InlineData(BuckingHamPalaceLatitude, BuckingHamPalaceLongitude, GeoHashPrecision.Level2)]
        [InlineData(BuckingHamPalaceLatitude, BuckingHamPalaceLongitude, GeoHashPrecision.Level3)]
        [InlineData(BuckingHamPalaceLatitude, BuckingHamPalaceLongitude, GeoHashPrecision.Level4)]
        [InlineData(BuckingHamPalaceLatitude, BuckingHamPalaceLongitude, GeoHashPrecision.Level5)]
        [InlineData(BuckingHamPalaceLatitude, BuckingHamPalaceLongitude, GeoHashPrecision.Level6)]
        [InlineData(BuckingHamPalaceLatitude, BuckingHamPalaceLongitude, GeoHashPrecision.Level7)]
        [InlineData(BuckingHamPalaceLatitude, BuckingHamPalaceLongitude, GeoHashPrecision.Level8)]
        [InlineData(BuckingHamPalaceLatitude, BuckingHamPalaceLongitude, GeoHashPrecision.Level9)]
        [InlineData(BuckingHamPalaceLatitude, BuckingHamPalaceLongitude, GeoHashPrecision.Level10)]
        [InlineData(BuckingHamPalaceLatitude, BuckingHamPalaceLongitude, GeoHashPrecision.Level11)]
        [InlineData(BuckingHamPalaceLatitude, BuckingHamPalaceLongitude, GeoHashPrecision.Level12)]
        public void EncodesAsExpected(double lat, double lng, GeoHashPrecision precision)
        {
            var expectedOutput = BuckingHamPalaceGeoHash.Substring(0, (int)precision);

            var encoder = new GeoHashEncoder<string>();
            var encoded = encoder.Encode(lat, lng, precision);
            
            Assert.Equal(encoded, expectedOutput);
        }
    }
}
