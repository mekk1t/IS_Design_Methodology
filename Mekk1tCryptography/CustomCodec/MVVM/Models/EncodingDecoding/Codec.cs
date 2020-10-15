using CustomCodec.MVVM.Models.EncodingDecoding.Interfaces;
using System;

namespace CustomCodec.MVVM.Models.EncodingDecoding
{
    public class Codec : ICodec
    {
        private string message;

        public Codec(string message)
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
