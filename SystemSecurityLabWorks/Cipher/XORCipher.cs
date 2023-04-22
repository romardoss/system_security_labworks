using Spire.Pdf.Exporting.XPS.Schema;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SystemSecurityLabWorks.Cipher
{
    public class XORCipher : ICipher
    {
        private static readonly List<string> KeyToEncryptList = new List<string>();
        private static readonly List<string> KeyToDecryptList = new List<string>();

        public string Encrypt(string input, string key)
        {
            if (CheckCipherNotebook(key, true))
            {
                KeyToEncryptList.Add(key);
                return Cipher(input, key);
            }
            return "This key was already used for encrypting, try another one";
        }

        public string Decrypt(string input, string key)
        {
            if (CheckCipherNotebook(key, false))
            {
                KeyToDecryptList.Add(key);
                return Cipher(input, key);
            }
            return "This key was already used for decrypting, try another one";
        }

        private string Cipher(string input, string key)
        {
            char[] chars = input.ToCharArray();
            byte[] bytes = new byte[chars.Length];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = (byte)chars[i];
            }

            //creating seed random
            Random seed = new Random(GetIntKey(key));
            char[] seedKey = CreateSeedKey(seed, input.Length);

            //xor encryption/decryption
            for (int i = 0; i < chars.Length; i++)
            {
                //chars[i] = (char)(chars[i] ^ seedKey[i]);
                chars[i] ^= seedKey[i];
            }

            return new string(chars);
        }

        private int GetIntKey(string key)
        {
            if (int.TryParse(key, out int intKey))
            {
                return intKey;
            }
            else
            {
                char[] chars = key.ToCharArray();
                int intkey = 0;
                foreach (char c in chars)
                {
                    intkey += c;
                }
                return intkey;
            }
        }

        private char[] CreateSeedKey(Random seed, int inputLength)
        {
            byte[] bytes = new byte[inputLength];
            seed.NextBytes(bytes);
            char[] chars = new char[inputLength];
            for(int i = 0; i < inputLength; i++)
            {
                chars[i] = (char)bytes[i];
            }
            return chars;
        }

        private bool CheckCipherNotebook(string key, bool isEncrypt)
        {
            if(isEncrypt)
            {
                if(KeyToEncryptList.Contains(key))
                {
                    MessageBox.Show("This key was already used for encrypting, try another one");
                    return false;
                }
            }
            else
            {
                if (KeyToDecryptList.Contains(key))
                {
                    MessageBox.Show("This key was already used for decrypting, try another one");
                    return false;
                }
            }
            return true;
        }
    }
}
