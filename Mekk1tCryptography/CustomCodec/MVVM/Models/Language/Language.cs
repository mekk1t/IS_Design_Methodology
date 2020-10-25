using System.Linq;
using CustomCodec_WPF.MVVM.Models.EncodingDecoding.Alphabets;
using CustomCodec_WPF.MVVM.Models.Extensions;
using CustomCodec_WPF.MVVM.Models.Language.Enum;

namespace CustomCodec_WPF.MVVM.Models.Language
{
    public static class Language
    {
        public static Languages Define(string content)
        {
            var eng = new EnglishAlphabet().Alphabet;
            var rus = new RussianAlphabet().Alphabet;

            var temp = content
                .Trim()
                .RemoveWhitespace()
                .ToLower();

            if (eng.ContainsKey(temp.First()))
                return Languages.English;
            else if (rus.ContainsKey(temp.First()))
                return Languages.Russian;

            return Languages.Unknown;
        }
    }
}
