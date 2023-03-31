using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SystemSecurityLabWorks.Cipher.TritemiusCipher
{
    public class LinearCipher : ICipher
    {
        public string Encrypt(string input, int[] key)
        //key = {A, B}
        {
            char[] letters = input.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] += (char)(key[0] * (i + 1) + key[1]);
            }
            return new string(letters);
        }

        public string Encrypt(string input, string key)
        {
            if (ValidateKey(key))
            {
                string[] keys = key.Split();
                int[] intKeys = { int.Parse(keys[0]), int.Parse(keys[1]) };
                return Encrypt(input, intKeys);
            }
            return input;
        }

        public string Decrypt(string input, int[] key)
        {
            int[] newKey = { -key[0], -key[1] };
            return Encrypt(input, newKey);
        }

        public string Decrypt(string input, string key)
        {
            if (ValidateKey(key))
            {
                string[] keys = key.Split();
                int[] intKeys = { int.Parse(keys[0]), int.Parse(keys[1]) };
                return Decrypt(input, intKeys);
            }
            return input;
        }

        public bool ValidateKey(string key)
        {
            string[] keys = key.Split();
            for (int i = 0; i < keys.Length; i++)
            {
                if (int.TryParse(keys[i], out _))
                {
                    continue;
                }
                else
                {
                    MessageBox.Show("Key must be a number");
                    return false;
                }
            }
            return true;
        }
    }
}
