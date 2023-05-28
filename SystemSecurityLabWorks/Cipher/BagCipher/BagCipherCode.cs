using Org.BouncyCastle.Math;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SystemSecurityLabWorks.Cipher.BagCipher
{
    public class BagCipherCode : ICipher
    {
        public string Encrypt(string input, string key)
        {
            string s = GetBitStringFromMessage(input);
            int[] sequence = key.Split(' ').Select(x => int.Parse(x)).ToArray();
            int[,] matrix = new int[(s.Length / sequence.Length) + 1, sequence.Length];
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    //matrix[i, j] = int.Parse(s.Substring(i * matrix.GetLength(1) + j, 1));
                    //matrix[i, j] = int.Parse(s.Substring(counter++, 1));
                    if(counter < s.Length)
                    {
                        matrix[i, j] = s.ElementAt(counter++) - '0';
                    }
                }
            }

            int[] encryptedMessage = new int[matrix.GetLength(0)];
            for(int i = 0; i < encryptedMessage.Length; i++)
            {
                int sum = 0;
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        sum += sequence[j];
                    }
                }
                encryptedMessage[i] = sum;
            }
            
            //return GetMatrixString(matrix);
            return GetArrayString(encryptedMessage).Trim();
        }

        public string Decrypt(string input, string key)
        {
            string[] splitedKey = key.Split('.');
            int[] privateSequence = splitedKey[0].Split(' ')
                .Select(x => int.Parse(x)).ToArray();
            int m = int.Parse(splitedKey[1]);
            int t = int.Parse(splitedKey[2]);

            BigInteger bigIntegerT = BigInteger.ValueOf(t);
            BigInteger bigIntegerM = BigInteger.ValueOf(m);
            int t1 = bigIntegerT.ModInverse(bigIntegerM).IntValue;

            int[] inputArray = input.Split(' ').Select(x => int.Parse(x)).ToArray();
            for(int i = 0; i < inputArray.Length; i++)
            {
                inputArray[i] = (inputArray[i] * t1) % m;
            }

            int[,] matrix = Knapsack(privateSequence, inputArray);
            string answer = GetMessageFromBitString(matrix);

            return answer.Trim();
            //return t1.ToString() + " " + t;
            //return $"{GetArrayString(privateSequence)}\n{m}\n{t}";
        }

        private int[,] Knapsack(int[] privateSequence, int[] decryptedArray)
        {
            /*int[,] matrix = new int
                [(decryptedArray.Length / privateSequence.Length) + 1, 
                privateSequence.Length];*/
            int[,] matrix = new int [decryptedArray.Length, privateSequence.Length];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int sum = decryptedArray[i];
                for (int j = matrix.GetLength(1)-1; j >= 0; j--)
                {
                    /*if(sum <= 0)
                    {
                        break;
                    }*/
                    if(sum >= privateSequence[j])
                    {
                        matrix[i, j] = 1;
                        sum -= privateSequence[j];
                    }
                    else matrix[i, j] = 0;
                }
                if (sum != 0) throw new Exception("sum not equal 0");
            }
            return matrix;
        }

        private string GetBitStringFromMessage(string message)
        { 
            string cipherBitString = string.Join(
                string.Empty,
                Encoding.UTF8
                .GetBytes(message)
                .Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
            return cipherBitString;
        }

        private string GetMessageFromBitString(int[,] matrix)
        {
            StringBuilder message = new StringBuilder();
            foreach (int i in matrix)
            {
                message.Append(i.ToString());
            }
            string textString = Encoding.UTF8.GetString(
                Regex.Split(message.ToString(), "(.{8})")
                .Where(binary => !string.IsNullOrEmpty(binary))
                .Select(binary => Convert.ToByte(binary, 2))
                .ToArray());
            return textString;
        }

        private string GetMatrixString(int[,] matrix)
        {
            StringBuilder matrixString = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrixString.Append(matrix[i, j] + " ");
                }
                matrixString.AppendLine();
            }
            return matrixString.ToString();
        }

        private string GetArrayString(int[] array)
        {
            StringBuilder arrayString = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                arrayString.Append(array[i].ToString() + " ");
            }
            return arrayString.ToString();
        }
    }
}
