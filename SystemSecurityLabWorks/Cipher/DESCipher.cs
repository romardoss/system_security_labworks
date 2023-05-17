using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace SystemSecurityLabWorks.Cipher
{
    public class DESCipher : ICipher
    {
        public CipherMode cipherMode;
        public string CipherType;

        public string Encrypt(string input, string key)
        {
            ICryptoTransform encryptor;
            if (CipherType == "DES")
            {
                encryptor = GetDES(key, true);
            }
            else if (CipherType == "3DES")
            {
                encryptor = Get3DES(key, true);
            }
            else if (CipherType == "AES")
            {
                encryptor = GetAES(key, true);
            }
            else throw new ArgumentException("there is no such cipher");

            byte[] data = Encoding.UTF8.GetBytes(input);
            //return Convert.ToBase64String(data);
            if (encryptor != null)
            {
                return Convert.ToBase64String(encryptor.TransformFinalBlock(data, 0, data.Length));
            }
            else return "error";
        }

        public string Decrypt(string input, string key)
        {
            ICryptoTransform decryptor;
            if (CipherType == "DES")
            {
                decryptor = GetDES(key, false);
            }
            else if (CipherType == "3DES")
            {
                decryptor = Get3DES(key, false);
            }
            else if (CipherType == "AES")
            {
                decryptor = GetAES(key, false);
            }
            else throw new ArgumentException("there is no such cipher");

            
            //return Encoding.UTF8.GetString(data);
            if(decryptor != null)
            {
                try
                {
                    byte[] data = Convert.FromBase64String(input);
                    return Encoding.UTF8.GetString(decryptor.TransformFinalBlock(data, 0, data.Length));
                }
                catch
                {
                    MessageBox.Show("damaged input to decrypt");
                }
            }
            return "error";
        }

        private ICryptoTransform GetDES(string key, bool isEncrypt)
        {
            try
            {
                DESCryptoServiceProvider _DES = new DESCryptoServiceProvider
                {
                    Mode = cipherMode,
                    Key = Encoding.UTF8.GetBytes(key),
                    IV = Encoding.UTF8.GetBytes(key),
                };

                if (isEncrypt)
                {
                    return _DES.CreateEncryptor();
                }
                else
                {
                    return _DES.CreateDecryptor();
                }
            }
            catch 
            { 
                MessageBox.Show("key must be 8 byte length");
                MessageBox.Show("Secure key is generated to the clipboard");
                GenerateAndCopySecureKey(8);
                return null;
            }
            
        }

        private ICryptoTransform Get3DES(string key, bool isEncrypt)
        {
            try
            {
                TripleDESCryptoServiceProvider _3DES = new TripleDESCryptoServiceProvider
                {
                    Mode = cipherMode,
                    Key = Encoding.UTF8.GetBytes(key),
                    IV = Encoding.UTF8.GetBytes(key.Substring(0, 8))
                };
                if (isEncrypt)
                {
                    return _3DES.CreateEncryptor();
                }
                else
                {
                    return _3DES.CreateDecryptor();
                }
            }
            catch (Exception e)
            {
                string errMsg1 = "Specified key is a known weak key for 'TripleDES' and cannot be used.";
                string errMsg2 = "Specified key is not a valid size for this algorithm.";
                if (e.Message == errMsg1)
                {
                    MessageBox.Show("This is a weak key");
                }
                else if (e.Message == errMsg2)
                {
                    MessageBox.Show("key must be 16 or 24 byte length");
                }
                MessageBox.Show("Secure key is generated to the clipboard");
                GenerateAndCopySecureKey(24);
                return null;
            }
        }

        private ICryptoTransform GetAES(string key, bool isEncrypt)
        {
            try
            {
                AesCryptoServiceProvider _AES = new AesCryptoServiceProvider
                {
                    Mode = cipherMode,
                    Key = Encoding.UTF8.GetBytes(key),
                    IV = Encoding.UTF8.GetBytes(key.Substring(0, 16))
            };
                if (isEncrypt)
                {
                    return _AES.CreateEncryptor();
                }
                else
                {
                    return _AES.CreateDecryptor();
                }
            }
            catch
            {
                MessageBox.Show("key must be 16 or 24 or 32 byte length");
                MessageBox.Show("Secure key is generated to the clipboard");
                GenerateAndCopySecureKey(32);
                return null;
            }
        }

        private void GenerateAndCopySecureKey (int keyLength)
        {
            AesCryptoServiceProvider alg = new AesCryptoServiceProvider();
            alg.GenerateKey();
            string newKey = Convert.ToBase64String(alg.Key);
            Clipboard.SetText(newKey.Substring(0, keyLength));
        }
    }
}
