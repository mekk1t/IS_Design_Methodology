using CustomCodec.MVVM.Models.EncodingDecoding.Interfaces;
using CustomCodec_WPF.MVVM.Models.EncodingDecoding.Alphabets;
using System;

namespace CustomCodec.MVVM.Models.EncodingDecoding
{
    public class VernamAlgorithm : ICodec
    {
        private string message;
        private readonly IAlphabet alphabet;

        public VernamAlgorithm(string message)
        {
            this.message = message;
        }

        public void Decode()
        {
            throw new NotImplementedException();
        }

        public void Encode()
        {
            throw new NotImplementedException();
        }

        public string GetMessage()
        {
            var temp = message;
            message = default;
            return temp;
        }
    }
}
