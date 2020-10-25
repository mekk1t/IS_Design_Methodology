using CustomCodec.MVVM.Models.EncodingDecoding.Interfaces;
using CustomCodec_WPF.MVVM.Models;
using CustomCodec_WPF.MVVM.Models.EncodingDecoding.Alphabets;
using CustomCodec_WPF.MVVM.Models.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace CustomCodec.MVVM.Models.EncodingDecoding
{
    public class VernamAlgorithm : ICodec
    {
        private readonly string message;
        private readonly string key;
        private readonly Dictionary<char, byte> alphabet;

        private List<int> whitespaceIndexes = new List<int>();
        private readonly byte MODULE;
        private const byte EMPTY_SPACE_BYTE_VALUE = 255;

        private string keyMask;
        private string encodedMessage;
        private string decodedMessage;

        private byte[] encodedMessageNumbered;
        private byte[] messageNumbered;
        private byte[] keyMaskNumbered;

        private byte[] subtractByModule;
        private byte[] sumByModule;

        public VernamAlgorithm(AlgorithmParameters parameters)
        {
            message = parameters.Message.ToLower();
            key = parameters.Key.ToLower();

            if (parameters.UseRussian)
                alphabet = new RussianAlphabet().Alphabet;
            else
                alphabet = new EnglishAlphabet().Alphabet;

            MODULE = (byte)alphabet.Count;
        }

        public void Decode()
        {
            ImposeKeyOnTheMessage();
            NumberTheEncodedMessage();
            NumberTheKeyMask();
            SubtractByModule();
            Decrypt();
        }
        public void Encode()
        {
            ImposeKeyOnTheMessage();
            NumberTheMessage();
            NumberTheKeyMask();
            SumByModule();
            Encrypt();
        }

        public string GetEncodedMessage()
        {
            return encodedMessage;
        }
        public string GetDecodedMessage()
        {
            return decodedMessage;
        }

        private void ImposeKeyOnTheMessage()
        {
            var temp = message;

            for (int i = 0; i < temp.Length; i++)
            {
                if (char.IsWhiteSpace(temp[i]))
                    whitespaceIndexes.Add(i);
            }

            var sb = new StringBuilder();

            var keyLength = key.Length;
            var keyEntriesInMessageTimes = temp.RemoveWhitespace().Length / keyLength;
            var remainingKeyLetters = temp.RemoveWhitespace().Length % keyLength;

            for (int i = 0; i < keyEntriesInMessageTimes; i++)
                sb.Append(key);

            if (remainingKeyLetters != 0)
                for (byte i = 0; i < remainingKeyLetters; i++)
                    sb.Append(key[i]);

            foreach (var index in whitespaceIndexes)
            {
                sb.Insert(index, ' ');
            }

            keyMask = sb.ToString();
        }

        private void NumberTheEncodedMessage()
        {
            encodedMessageNumbered = new byte[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                if (char.IsWhiteSpace(message[i]))
                    encodedMessageNumbered[i] = 255;
                else
                    encodedMessageNumbered[i] = alphabet[message[i]];
            }
        }
        private void NumberTheMessage()
        {
            messageNumbered = new byte[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                if (char.IsWhiteSpace(message[i]))
                    messageNumbered[i] = 255;
                else
                    messageNumbered[i] = alphabet[message[i]];
            }
        }
        private void NumberTheKeyMask()
        {
            keyMaskNumbered = new byte[keyMask.Length];

            for (int i = 0; i < keyMask.Length; i++)
            {
                if (char.IsWhiteSpace(keyMask[i]))
                    keyMaskNumbered[i] = 255;
                else
                    keyMaskNumbered[i] = alphabet[keyMask[i]];
            }
        }

        private void SubtractByModule()
        {
            subtractByModule = new byte[encodedMessageNumbered.Length];

            for (int i = 0; i < encodedMessageNumbered.Length; i++)
            {
                if (encodedMessageNumbered[i] == EMPTY_SPACE_BYTE_VALUE)
                    subtractByModule[i] = EMPTY_SPACE_BYTE_VALUE;
                else
                    subtractByModule[i] = FindSubtractByMod(encodedMessageNumbered[i], keyMaskNumbered[i], MODULE);
            }
        }
        private void SumByModule()
        {
            sumByModule = new byte[messageNumbered.Length];

            for (int i = 0; i < messageNumbered.Length; i++)
            {
                if (messageNumbered[i] == EMPTY_SPACE_BYTE_VALUE)
                    sumByModule[i] = EMPTY_SPACE_BYTE_VALUE;
                else
                    sumByModule[i] = FindSumByMod(messageNumbered[i], keyMaskNumbered[i], MODULE);
            }
        }

        private byte FindSumByMod(byte x, byte y, byte z)
        {
            if (x + y < z)
                return (byte)(x + y);
            if (x + y > z)
                return (byte)(x + y - z);

            return 0;
        }

        private byte FindSubtractByMod(byte x, byte y, byte z)
        {
            if (x - y > 0 && x - y < z)
                return (byte)(x - y);
            if (x - y < 0)
                return (byte)(x + z - y);

            return 0;
        }

        private void Encrypt()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < sumByModule.Length; i++)
            {
                if (sumByModule[i] == EMPTY_SPACE_BYTE_VALUE)
                    sb.Append(' ');
                else
                    sb.Append(alphabet.First(d => d.Value == sumByModule[i]).Key);
            }

            encodedMessage = sb.ToString();
        }
        private void Decrypt()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < subtractByModule.Length; i++)
            {
                if (subtractByModule[i] == EMPTY_SPACE_BYTE_VALUE)
                    sb.Append(' ');
                else
                    sb.Append(alphabet.First(d => d.Value == subtractByModule[i]).Key);
            }

            decodedMessage = sb.ToString();
        }
    }
}