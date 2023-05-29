using System.Security.Cryptography;
using System.Windows;
using SystemSecurityLabWorks.Cipher.BagCipher;
using SystemSecurityLabWorks.Cipher.TritemiusCipher;

namespace SystemSecurityLabWorks.Cipher
{
    public class CipherManager
    {
        public static string[] ciphers = {"Caesar", 
            "Tritemius (linear)", 
            "Tritemius (squaire)",
            "Tritemius (slogan)",
            "XOR",
            "Book",
            "DES (CBC)",
            "DES (ECB)",
            "DES (CFB)",
            "3-DES (CBC)",
            "3-DES (ECB)",
            "3-DES (CFB)",
            "AES (CBC)",
            "AES (ECB)",
            "AES (CFB)",
            "Bag",
            "RSA",
        };
        public static MainWindow mainWindow;

        public static string Encrypt(string input, string key, string cipher)
        {
            DESCipher des;
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

                case "XOR":
                    var xor = new XORCipher();
                    return xor.Encrypt(input, key);

                case "Book":
                    var book = new BookCipher();
                    return book.Encrypt(input, key);

                case "DES (CBC)":
                    des = new DESCipher
                    {
                        CipherType = "DES",
                        cipherMode = CipherMode.CBC
                    };
                    return des.Encrypt(input, key);

                case "DES (ECB)":
                    des = new DESCipher
                    {
                        CipherType = "DES",
                        cipherMode = CipherMode.ECB
                    };
                    return des.Encrypt(input, key);

                case "DES (CFB)":
                    des = new DESCipher
                    {
                        CipherType = "DES",
                        cipherMode = CipherMode.CFB
                    };
                    return des.Encrypt(input, key);

                    case "3-DES (CBC)":
                    des = new DESCipher
                    {
                        CipherType = "3DES",
                        cipherMode = CipherMode.CBC
                    };
                    return des.Encrypt(input, key);

                case "3-DES (ECB)":
                    des = new DESCipher
                    {
                        CipherType = "3DES",
                        cipherMode = CipherMode.ECB
                    };
                    return des.Encrypt(input, key);

                case "3-DES (CFB)":
                    des = new DESCipher
                    {
                        CipherType = "3DES",
                        cipherMode = CipherMode.CFB
                    };
                    return des.Encrypt(input, key);

                case "AES (CBC)":
                    des = new DESCipher
                    {
                        CipherType = "AES",
                        cipherMode = CipherMode.CBC
                    };
                    return des.Encrypt(input, key);

                case "AES (ECB)":
                    des = new DESCipher
                    {
                        CipherType = "AES",
                        cipherMode = CipherMode.ECB
                    };
                    return des.Encrypt(input, key);

                case "AES (CFB)":
                    des = new DESCipher
                    {
                        CipherType = "AES",
                        cipherMode = CipherMode.CFB
                    };
                    return des.Encrypt(input, key);

                case "Bag":
                    BagCipherCode bag = new BagCipherCode();
                    return bag.Encrypt(input, key);

                case "RSA":
                    return RSACipher.Encrypt(input, key);

                default: 
                    MessageBox.Show("Wrong cipher chosen");
                    return "Wrong cipher chosen";
            }
        }

        public static string Decrypt(string input, string key, string cipher)
        {
            DESCipher des;
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

                case "XOR":
                    var xor = new XORCipher();
                    return xor.Decrypt(input, key);

                case "Book":
                    var book = new BookCipher();
                    return book.Decrypt(input, key);

                case "DES (CBC)":
                    des = new DESCipher
                    {
                        CipherType = "DES",
                        cipherMode = CipherMode.CBC
                    };
                    return des.Decrypt(input, key);

                case "DES (ECB)":
                    des = new DESCipher
                    {
                        CipherType = "DES",
                        cipherMode = CipherMode.ECB
                    };
                    return des.Decrypt(input, key);

                case "DES (CFB)":
                    des = new DESCipher
                    {
                        CipherType = "DES",
                        cipherMode = CipherMode.CFB
                    };
                    return des.Decrypt(input, key);

                case "3-DES (CBC)":
                    des = new DESCipher
                    {
                        CipherType = "3DES",
                        cipherMode = CipherMode.CBC
                    };
                    return des.Decrypt(input, key);

                case "3-DES (ECB)":
                    des = new DESCipher
                    {
                        CipherType = "3DES",
                        cipherMode = CipherMode.ECB
                    };
                    return des.Decrypt(input, key);

                case "3-DES (CFB)":
                    des = new DESCipher
                    {
                        CipherType = "3DES",
                        cipherMode = CipherMode.CFB
                    };
                    return des.Decrypt(input, key);

                case "AES (CBC)":
                    des = new DESCipher
                    {
                        CipherType = "AES",
                        cipherMode = CipherMode.CBC
                    };
                    return des.Decrypt(input, key);

                case "AES (ECB)":
                    des = new DESCipher
                    {
                        CipherType = "AES",
                        cipherMode = CipherMode.ECB
                    };
                    return des.Decrypt(input, key);

                case "AES (CFB)":
                    des = new DESCipher
                    {
                        CipherType = "AES",
                        cipherMode = CipherMode.CFB
                    };
                    return des.Decrypt(input, key);

                case "Bag":
                    BagCipherCode bag = new BagCipherCode();
                    return bag.Decrypt(input, key);

                case "RSA":
                    return RSACipher.Decrypt(input, key);

                default:
                    MessageBox.Show("Wrong cipher chosen");
                    return "Wrong cipher chosen";
            }
        }
    }
}
