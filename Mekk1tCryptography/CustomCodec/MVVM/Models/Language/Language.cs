using CustomCodec_WPF.MVVM.Models.EncodingDecoding.Alphabets;
using CustomCodec_WPF.MVVM.Models.Language.Enum;

namespace CustomCodec_WPF.MVVM.Models.Language
{
    public static class Language
    {
        public static Languages Define(string content)
        {
            var eng = new EnglishAlphabet().Alphabet;
            var rus = new RussianAlphabet().Alphabet;

            var temp = content.Trim().ToLower();
            int engCount = default;
            int rusCount = default;
            for (int i = 0; i < 5; i++)
            {
                if (rus.ContainsKey(temp[i]))
                    rusCount++;
                if (eng.ContainsKey(temp[i]))
                    engCount++;
            }
            if (rusCount == 4)
                return Languages.Russian;
            else if (engCount == 4)
                return Languages.English;
            else
                return Languages.Unknown;
        }
    }
}
