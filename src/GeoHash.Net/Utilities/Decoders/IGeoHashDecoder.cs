using System;
using GeoHash.Net.Models.GeoCoords;

namespace GeoHash.Net.Utilities.Decoders
{
    public interface IGeoHashDecoder
    {
        GeoCoordinate Decode(string geoHash);
        Tuple<double, double> DecodeAsTuple(string geoHash);
    }
}
