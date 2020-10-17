using CustomCodec.MVVM.Models.EncodingDecoding.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCodec_WPF.MVVM.Models.EncodingDecoding
{
    public class SecondAlgorithm : ICodec
    {
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
            throw new NotImplementedException();
        }

        private bool XOR(bool first, bool second)
        {
            if ((first == true && second == false) || (first == false && second == true))
                return true;
            else
                return false;
        }
    }
}
