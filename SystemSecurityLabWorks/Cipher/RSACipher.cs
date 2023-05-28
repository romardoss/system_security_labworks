using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;

namespace SystemSecurityLabWorks.Cipher
{
    public class RSACipher : ICipher
    {
        private static RSACryptoServiceProvider Rsa;

        public static string PublicKey 
        { 
            get
            {
                if(Rsa == null)
                {
                    GenerateKeys();
                }
                return Rsa.ToXmlString(false);
            }
            private set { }
        }
        public static string PrivateKey
        {
            get
            {
                if (Rsa == null)
                {
                    GenerateKeys();
                }
                return Rsa.ToXmlString(true);
            }
            private set { }
        }


        public string Encrypt(string input, string key)
        {
            Rsa = new RSACryptoServiceProvider();
            Rsa.FromXmlString(key);
            byte[] byteToEncrypt = Encoding.Unicode.GetBytes(input);
            byte[] EncryptBytes = Rsa.Encrypt(byteToEncrypt, false);
            string answer = Encoding.Unicode.GetString(EncryptBytes);
            return answer;
        }

        public string Decrypt(string input, string key)
        {
            byte[] EncryptBytes = Encoding.Unicode.GetBytes(input);
            byte[] DecryptBytes = Rsa.Decrypt(EncryptBytes, false);
            string decryptString = Encoding.Unicode.GetString(DecryptBytes);
            return decryptString;
        }

        public static void GenerateKeys()
        {
            CspParameters cp = new CspParameters();
            Rsa = new RSACryptoServiceProvider(cp);
            //string publicKey = Rsa.ToXmlString(false);
            //MessageBox.Show($"Public key is {publicKey}");
        }
    }
}
