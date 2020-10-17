﻿using System.Collections.Generic;

namespace CustomCodec_WPF.MVVM.Models.EncodingDecoding.Alphabets
{
    public class EnglishAlphabet : IAlphabet
    {
        public char[] Letters => new char[26]
        {
            'а', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k','l','m', 'n','o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
        };
        public Dictionary<char, byte> Alphabet { get; private set; }

        public EnglishAlphabet()
        {
            InitializeAlphabet();
        }

        private void InitializeAlphabet()
        {
            Alphabet = new Dictionary<char, byte>();

            for (byte i = 0; i < Letters.Length; i++)
                Alphabet.Add(Letters[i], i);
        }
    }
}
