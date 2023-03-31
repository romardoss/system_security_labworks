﻿using System.Windows;
using SystemSecurityLabWorks.Cipher.TritemiusCipher;

namespace SystemSecurityLabWorks.Cipher
{
    public class CipherManager
    {
        public static string[] ciphers = {"Caesar", 
            "Tritemius (linear)", 
            "Tritemius (squaire)",
            "Tritemius (slogan)", 
        };

        public static string Encrypt(string input, string key, string cipher)
        {
            switch (cipher)
            {
                case "Caesar":
                    var caesar = new CaesarCipher();
                    return caesar.Encrypt(input, key);

                case "Tritemius (linear)":
                    var tritemius1 = new LinearCipher();
                    return tritemius1.Encrypt(input, key);

                case "Tritemius (squaire)":
                    var tritemius2 = new NonLinearCipher();
                    return tritemius2.Encrypt(input, key);

                case "Tritemius (slogan)":
                    var tritemius3 = new SloganCipher();
                    return tritemius3.Encrypt(input, key);

                default: 
                    MessageBox.Show("Wrong cipher chosen");
                    return "Wrong cipher chosen";
            }
        }

        public static string Decrypt(string input, string key, string cipher)
        {
            switch (cipher)
            {
                case "Caesar":
                    var caesar = new CaesarCipher();
                    return caesar.Decrypt(input, key);

                case "Tritemius (linear)":
                    var tritemius1 = new LinearCipher();
                    return tritemius1.Decrypt(input, key);

                case "Tritemius (squaire)":
                    var tritemius2 = new NonLinearCipher();
                    return tritemius2.Decrypt(input, key);

                case "Tritemius (slogan)":
                    var tritemius3 = new SloganCipher();
                    return tritemius3.Decrypt(input, key);

                default:
                    MessageBox.Show("Wrong cipher chosen");
                    return "Wrong cipher chosen";
            }
        }
    }
}
