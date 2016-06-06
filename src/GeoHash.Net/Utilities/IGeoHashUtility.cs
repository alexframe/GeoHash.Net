using GeoHash.Net.Utilities.Decoders;
using GeoHash.Net.Utilities.Encoders;
using GeoHash.Net.Utilities.Matchers;

namespace GeoHash.Net.Utilities
{
    public interface IGeoHashUtility<TKey>
    {
        IGeoHashEncoder<TKey> Encoder { get; }
        IGeoHashDecoder<TKey> Decoder { get; }
        IGeoHashMatcher<TKey> Matcher { get; }
    }
}
