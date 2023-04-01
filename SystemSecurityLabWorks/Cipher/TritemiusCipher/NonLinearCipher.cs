using System;
using System.Windows;

namespace SystemSecurityLabWorks.Cipher.TritemiusCipher
{
    public class NonLinearCipher : ICipher
    {
        public string Encrypt(string input, int[] key)
        {
            char[] letters = input.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] += (char)(key[0] * Math.Pow(i + 1, 2) +
                   key[1] * (i + 1) + key[2]);
            }
            return new string(letters);
        }

        public string Encrypt(string input, string key)
        {
            if (ValidateKey(key))
            {
                string[] keys = key.Split();
                int[] intKeys = { int.Parse(keys[0]), int.Parse(keys[1]),
                int.Parse(keys[2]) };
                return Encrypt(input, intKeys);
            }
            return input;
        }

        public string Decrypt(string input, int[] key)
        {
            int[] newKey = { -key[0], -key[1], -key[2] };
            return Encrypt(input, newKey);
        }

        public string Decrypt(string input, string key)
        {
            if (ValidateKey(key))
            {
                string[] keys = key.Split();
                int[] intKeys = { int.Parse(keys[0]), int.Parse(keys[1]),
                int.Parse(keys[2]) };
                return Decrypt(input, intKeys);
            }
            return input;
        }

        public bool ValidateKey(string key)
        {
            string[] keys = key.Split();
            if (keys.Length != 3)
            {
                MessageBox.Show("Key must contain only three numbers");
                return false;
            }
            for (int i = 0; i < keys.Length; i++)
            {
                if (int.TryParse(keys[i], out _))
                {
                    continue;
                }
                else
                {
                    MessageBox.Show("Key must containt only three numbers");
                    return false;
                }
            }
            return true;
        }
    }
}
