using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GeoHash.Net.Utilities.Helpers
{
    internal static class GeoHashHelpers
    {
        internal static int[] GetBits()
        {
            return new[] { 16, 8, 4, 2, 1 };
        }

        internal static char[] GetBase32Chars()
        {
            return new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'm', 'n', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        }

        internal static IReadOnlyDictionary<char, int> GetDecodeMap(char[] base32Chars = null)
        {
            var decodeMap = new Dictionary<char, int>();
            base32Chars = base32Chars ?? GetBase32Chars();

            var size = base32Chars.Length;
            for (var i = 0; i < size; i++)
            {
                decodeMap[base32Chars[i]] = i;
            }

            return new ReadOnlyDictionary<char, int>(decodeMap);
        }
    }
}
