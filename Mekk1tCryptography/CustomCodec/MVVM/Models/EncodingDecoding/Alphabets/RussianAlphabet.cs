using System.Collections.Generic;

namespace CustomCodec_WPF.MVVM.Models.EncodingDecoding.Alphabets
{
    public class RussianAlphabet : IAlphabet
    {
        public char[] Letters => new char[33]
        {
            'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з','и', 'й', 'к','л','м','н','о','п','р','с','т','у','ф','х','ц','ч','ш','щ','ъ','ы','ь','э','ю','я'
        };
        public char[] SpecialSymbols => new char[6]
        {
            '!', ',', '.', '?', ':', '-'
        };

        public Dictionary<char, byte> Alphabet { get; private set; }

        public RussianAlphabet()
        {
            InitializeAlphabet();
        }

        private void InitializeAlphabet()
        {
            Alphabet = new Dictionary<char, byte>();

            for (byte i = 0; i < Letters.Length; i++)
                Alphabet.Add(Letters[i], i);

            var alphabetLastIndex = Alphabet.Count;

            for (int i = 0; i < SpecialSymbols.Length; i++)
            {
                Alphabet.Add(SpecialSymbols[i], (byte)alphabetLastIndex);
                alphabetLastIndex++;
            }
        }
    }
}
