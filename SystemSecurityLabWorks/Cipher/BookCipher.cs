using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SystemSecurityLabWorks.Cipher
{
    public class BookCipher : ICipher
    {
        public string Encrypt(string input, string key)
        {
            char[,] matrix = CreateMatrixFromPoem(key);
            //return GetStringMatrix(matrix);
            //return GetStringMatrix(FindAllNeededChars(matrix, 'м'));
            char[] chars = input.ToCharArray();
            
            StringBuilder s = new StringBuilder();
            Random rand = new Random();
            foreach (char c in chars)
            {
                if (c == '\n') continue;
                int[,] coordinates = FindAllNeededChars(matrix, c);
                if (coordinates == null)
                {
                    MessageBox.Show($"There are no such letter '{c}' in key, " +
                    $"so it will be missed in encrypted message. " +
                    $"You can add it to the key or choose another word " +
                    $"without this letter");
                    continue;
                }
                int r = rand.Next(0, coordinates.GetLength(0));
                s.Append($"{coordinates[r, 0]}/{coordinates[r, 1]} ");
            }
            return s.ToString();
        }

        public string Decrypt(string input, string key)
        {
            char[,] matrix = CreateMatrixFromPoem(key);

            string[] letters = input.Split();
            StringBuilder s = new StringBuilder();
            foreach (string l in letters)
            {
                if(l == "") continue;
                int i = int.Parse(l.Split('/')[0]);
                int j = int.Parse(l.Split('/')[1]);
                s.Append(matrix[i, j]);
            }
            return s.ToString();
        }

        private char[,] CreateMatrixFromPoem(string poem)
        {
            string[] sentences = poem.Split('\n');
            int width = sentences.Max(x => x.Length);
            int height = sentences.Length;
            char[,] matrix = new char[height, width];
            for(int i = 0; i < height; i++)
            {
                char[] chars = sentences[i].ToCharArray();
                for(int j = 0; j < chars.Length; j++)
                {
                    matrix[i, j] = chars[j];
                }
            }
            return matrix;
        }

        private int[,] FindAllNeededChars(char[,] chars, char letter)
        {
            List<int> iCoordinate = new List<int>();
            List<int> jCoordinate = new List<int>();

            for (int i = 0; i < chars.GetLength(0); i++)
            {
                for(int j = 0; j < chars.GetLength(1); j++)
                {
                    if (letter == chars[i, j])
                    {
                        iCoordinate.Add(i);
                        jCoordinate.Add(j);
                    }
                }
            }

            if (iCoordinate.Count == 0)
            {
                return null;
            }
            int[,] coordinates = new int[iCoordinate.Count, 2];
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                coordinates[i, 0] = iCoordinate[i];
                coordinates[i, 1] = jCoordinate[i];
            }
            return coordinates;
        }

        private string GetStringMatrix<T>(T[,] matrix)
        {
            var s = new StringBuilder();
            //string delimeter = "\t";
            //string delimeter = "|";
            string delimeter = " ";
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    s.Append(matrix[i, j]).Append(delimeter);
                }
                s.AppendLine();
            }
            return s.ToString();
        }
    }
}
