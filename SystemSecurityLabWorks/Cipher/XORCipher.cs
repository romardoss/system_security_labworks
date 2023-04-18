using System;

namespace SystemSecurityLabWorks.Cipher
{
    public class XORCipher : ICipher
    {
        public string Encrypt(string input, string key)
        {
            return Cipher(input, key);
        }

        public string Decrypt(string input, string key)
        {
            return Cipher(input, key); 
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
    }
}
