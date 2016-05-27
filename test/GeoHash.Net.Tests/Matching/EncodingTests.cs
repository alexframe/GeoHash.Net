using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using GeoHash.Net.GeoCoords;
using GeoHash.Net.Tests.TestData;
using GeoHash.Net.Utilities.Encoders;
using GeoHash.Net.Utilities.Enums;
using GeoHash.Net.Utilities.Matchers;
using Xunit;

namespace GeoHash.Net.Tests.Matching
{
  public class EncodingTests
  {
    private const double CoogeeLatitude = -33.916667;
    private const double CoogeeLongitude = 151.266667;
    private const string CoogeeGeoHash = "r3gx41tj0g40";

    private IDictionary<Location, GeoCoordinate> _aussieSuburbs;

    public EncodingTests()
    {
      LoadAussieSuburbs();
    }

    [Theory]
    [InlineData(GeoHashPrecision.Level5, 4)]
    public void EncodesAsExpected(GeoHashPrecision precision, int expectedMatches)
    {
      var encoder = new GeoHashEncoder<Location>();
      var matcher = new GeoHashMatcher<Location>();

      var geoHashedCities = encoder.Encode(_aussieSuburbs);
      var actualMatches = matcher.GetMatches(CoogeeGeoHash, geoHashedCities, precision).Count();

      Assert.Equal(actualMatches, expectedMatches);
    }

    private void LoadAussieSuburbs()
    {
      using (var csvFile = File.OpenText(@"TestData\auscitiespop.txt"))
      {
        using (var csv = new CsvReader(csvFile))
        {
          var cities = csv.GetRecords<Location>().ToDictionary(x => x, x => new GeoCoordinate(x.Latitude, x.Longitude));
          _aussieSuburbs = cities;
        }
      }
    }
  }
}
