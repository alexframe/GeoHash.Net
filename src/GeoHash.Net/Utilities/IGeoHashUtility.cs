using GeoHash.Net.Utilities.Decoders;
using GeoHash.Net.Utilities.Encoders;
using GeoHash.Net.Utilities.Matchers;

namespace GeoHash.Net.Utilities
{
    public interface IGeoHashUtility : IGeoHashEncoder, IGeoHashDecoder, IGeoHashMatcher { }
}
