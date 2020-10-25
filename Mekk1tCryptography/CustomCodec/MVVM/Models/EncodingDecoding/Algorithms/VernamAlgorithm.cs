﻿using CustomCodec.MVVM.Models.EncodingDecoding.Interfaces;
using CustomCodec_WPF.MVVM.Models;
using CustomCodec_WPF.MVVM.Models.EncodingDecoding.Alphabets;
using System.Linq;
using System.Text;

namespace CustomCodec.MVVM.Models.EncodingDecoding
{
    public class VernamAlgorithm : ICodec
    {
        private readonly AlgorithmParameters parameters;
        private readonly IAlphabet alphabet;

        private const byte MODULE = 33;

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
            this.parameters = parameters;
            parameters.Mod = MODULE;
            alphabet = new RussianAlphabet();
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
            var sb = new StringBuilder();

            var keyLength = parameters.Key.Length;
            var keyEntriesInMessageTimes = parameters.Message.Length / keyLength;
            var remainingKeyLetters = parameters.Message.Length % keyLength;

            for (int i = 0; i < keyEntriesInMessageTimes; i++)
                sb.Append(parameters.Key);

            if (remainingKeyLetters != 0)
                for (byte i = 0; i < remainingKeyLetters; i++)
                    sb.Append(parameters.Key[i]);

            keyMask = sb.ToString();
        }

        private void NumberTheEncodedMessage()
        {
            encodedMessageNumbered = new byte[parameters.Message.Length];

            for (int i = 0; i < parameters.Message.Length; i++)
            {
                encodedMessageNumbered[i] = alphabet.Alphabet[parameters.Message[i]];
            }
        }
        private void NumberTheMessage()
        {
            messageNumbered = new byte[parameters.Message.Length];

            for (int i = 0; i < parameters.Message.Length; i++)
            {
                messageNumbered[i] = alphabet.Alphabet[parameters.Message[i]];
            }
        }
        private void NumberTheKeyMask()
        {
            keyMaskNumbered = new byte[keyMask.Length];

            for (int i = 0; i < keyMask.Length; i++)
            {
                keyMaskNumbered[i] = alphabet.Alphabet[keyMask[i]];
            }
        }

        private void SubtractByModule()
        {
            subtractByModule = new byte[encodedMessageNumbered.Length];

            for (int i = 0; i < encodedMessageNumbered.Length; i++)
            {
                subtractByModule[i] = FindSubtractByMod(encodedMessageNumbered[i], keyMaskNumbered[i], MODULE);
            }
        }
        private void SumByModule()
        {
            sumByModule = new byte[messageNumbered.Length];

            for (int i = 0; i < messageNumbered.Length; i++)
            {
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
                sb.Append(alphabet.Alphabet.FirstOrDefault(d => d.Value == sumByModule[i]).Key);
            }

            encodedMessage = sb.ToString();
        }
        private void Decrypt()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < subtractByModule.Length; i++)
            {
                sb.Append(alphabet.Alphabet.FirstOrDefault(d => d.Value == subtractByModule[i]).Key);
            }

            decodedMessage = sb.ToString();
        }
    }
}