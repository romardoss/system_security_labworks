using System.Windows;
using SystemSecurityLabWorks.Cipher.TritemiusCipher;

namespace SystemSecurityLabWorks.Cipher
{
    public class CipherManager
    {
        public static string Encrypt(string input, string key)
        {
            string[] keys = key.Split();
            bool isAllNumbers = true;
            for (int i = 0; i < keys.Length; i++)
            {
                if (!int.TryParse(keys[i], out _))
                {
                    isAllNumbers = false;
                }
            }
            if (!isAllNumbers)
            {
                var gaslo = new SloganCipher();
                return gaslo.Encrypt(input, key);
            }
            switch (keys.Length)
            {
                case 1:
                    {
                        var caesar = new CaesarCipher();
                        return caesar.Encrypt(input, key);
                    }
                case 2:
                    {
                        var linear = new LinearCipher();
                        return linear.Encrypt(input, key);
                    }
                case 3:
                    {
                        var nonelinear = new NonLinearCipher();
                        return nonelinear.Encrypt(input, key);
                    }
                default:
                    {
                        MessageBox.Show("Invalid key");
                        return input;
                    }
            }
        }

        public static string Decrypt(string input, string key)
        {
            string[] keys = key.Split();
            bool isAllNumbers = true;
            for (int i = 0; i < keys.Length; i++)
            {
                if (!int.TryParse(keys[i], out _))
                {
                    isAllNumbers = false;
                }
            }
            if (!isAllNumbers)
            {
                var gaslo = new SloganCipher();
                return gaslo.Decrypt(input, key);
            }
            switch (keys.Length)
            {
                case 1:
                    {
                        var caesar = new CaesarCipher();
                        return caesar.Decrypt(input, key);
                    }
                case 2:
                    {
                        var linear = new LinearCipher();
                        return linear.Decrypt(input, key);
                    }
                case 3:
                    {
                        var nonelinear = new NonLinearCipher();
                        return nonelinear.Decrypt(input, key);
                    }
                default:
                    {
                        MessageBox.Show("Invalid key");
                        return input;
                    }
            }
        }
    }
}
