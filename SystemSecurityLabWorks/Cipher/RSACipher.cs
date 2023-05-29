using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SystemSecurityLabWorks.Cipher
{
    public class RSACipher
    {
        private static RSACryptoServiceProvider Rsa;
        public static string PublicKey;
        public static string PrivateKey;

        public static string Encrypt(string input, string key)
        {
            Rsa.FromXmlString(key);
            byte[] byteToEncrypt = Encoding.Unicode.GetBytes(input);
            byte[] EncryptBytes = Rsa.Encrypt(byteToEncrypt, false);
            return string.Join(" ", EncryptBytes.Select(x => x.ToString()).ToArray()).Trim();
        }

        public static string Decrypt(string input, string key)
        {
            Rsa.FromXmlString(key);
            byte[] EncryptBytes = input.Split(' ').Select(x => byte.Parse(x)).ToArray();
            byte[] DecryptBytes = Rsa.Decrypt(EncryptBytes, false);
            string decryptString = Encoding.Unicode.GetString(DecryptBytes);
            return decryptString;
        }

        public static void GenerateKeys()
        {
            CspParameters cp = new CspParameters();
            Rsa = new RSACryptoServiceProvider(cp);
            PublicKey = Rsa.ToXmlString(false);
            PrivateKey = Rsa.ToXmlString(true);
        }
    }
}
