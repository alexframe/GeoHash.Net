# GeoHash.Net ![Alt](https://ci.appveyor.com/api/projects/status/github/alexframe/geohash.net?branch=master&svg=true&retina=true "Build status")

### Features ###
Allows you to translate a lat/lng coordinate to a GeoHashed string. This allows you to quickly cluster coordinates within predefined grids.

You can learn more about how to use this [here][1].

### Getting Started ###
Install via [`GeoHash.Net`][2] package on Nuget.

`Install-Package GeoHash.Net`

### Usage ###

####To encode coordinates to geohashes####
```csharp
// Create an encoder.
var encoder = new GeoHashEncoder<string>();

// Encode it into a geohash.
var geoHash = encoder.Encode("-33.916667,151.266667");
```

####To find if a geohash falls within a certain cluster:#####
```csharp
// Create a matcher.
var encoder = new GeoHashMatcher<string>();

// Test for match within 5km.
var isMatch = encoder.IsMatch("r3gx4", "r3gx41tj0g40", GeoHashPrecision.Level5);

// You can also pass in collections of geohahes to test for matches.
var matches = encoder.GetMatches("r3gx4", IEnumerable<string>, GeoHashPrecision.Level5);
```


  [1]: https://www.elastic.co/guide/en/elasticsearch/guide/current/geohashes.html#geohashes
  [2]: https://www.nuget.org/packages/GeoHash.Net