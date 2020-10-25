using System.Linq;

namespace CustomCodec_WPF.MVVM.Models.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveWhitespace(this string str)
        {
            return new string(str.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}