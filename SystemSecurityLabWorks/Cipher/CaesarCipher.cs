using System.Windows;

namespace SystemSecurityLabWorks.Cipher
{
    public class CaesarCipher : ICipher
    {
        public string Encrypt(string input, int key)
        {
            char charKey = (char)key;
            char[] letters = input.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] += charKey;
            }
            return new string(letters);
        }

        public string Encrypt(string input, string key)
        {
            return Encrypt(input, ValidateAndParseKey(key));
        }

        public string Decrypt(string input, int key)
        {
            return Encrypt(input, -key);
        }

        public string Decrypt(string input, string key)
        {
            return Encrypt(input, -ValidateAndParseKey(key));
        }

        public int ValidateAndParseKey(string key)
        {
            if (int.TryParse(key, out int intKey))
            {
                return intKey;
            }
            else
            {  
                char[] keyChar = key.ToCharArray();
                intKey = 0;
                foreach (char c in keyChar)
                {
                    intKey += c;
                }
                return intKey;
            }
        }

        
    }
}
