using GeoHash.Net.Utilities.Decoders;
using GeoHash.Net.Utilities.Encoders;
using GeoHash.Net.Utilities.Matchers;

namespace GeoHash.Net.Utilities
{
    public class GeoHashUtility<TKey> : IGeoHashUtility<TKey>
    {
        public IGeoHashEncoder<TKey> Encoder { get; }
        public IGeoHashDecoder<TKey> Decoder { get; }
        public IGeoHashMatcher<TKey> Matcher { get; }

        public GeoHashUtility() : this(new GeoHashEncoder<TKey>(), new GeoHashDecoder<TKey>(), new GeoHashMatcher<TKey>()) { }

        public GeoHashUtility(IGeoHashEncoder<TKey> encoder, IGeoHashDecoder<TKey> decoder, IGeoHashMatcher<TKey> matcher)
        {
            Encoder = encoder;
            Decoder = decoder;
            Matcher = matcher;
        }
    }
}
