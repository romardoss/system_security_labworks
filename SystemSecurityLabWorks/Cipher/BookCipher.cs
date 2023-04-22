using System;

namespace SystemSecurityLabWorks.Cipher
{
    public class BookCipher : ICipher
    {
        public string Encrypt(string input, string key)
        {
            return FindTheLongestRowInPoem(key).ToString();
            throw new NotImplementedException();
        }

        public string Decrypt(string input, string key)
        {
            throw new NotImplementedException();
        }

        private char[][] CreateMatrixFromPoem(string poem)
        {
            throw new NotImplementedException();
        }

        private int FindTheLongestRowInPoem(string poem)
        {
            int max = 0;
            for(int i = 0; i < poem.Length;)
            {
                int counter = 0;
                while (i+1 < poem.Length & poem[i] != '\n')
                {
                    counter++;
                    i++;
                }
                i++;
                if(counter > max)
                {
                    max = counter;
                }
            }
            return max;
        }

        private int[][] FindAllNeededChars(string poem)
        {
            throw new NotImplementedException();
        }
    }
}
