using System.Collections.Generic;

namespace CustomCodec_WPF.MVVM.Models.EncodingDecoding.Alphabets
{
    public interface IAlphabet
    {
        char[] Letters { get; }
        Dictionary<char, byte> Alphabet { get; }
    }
}