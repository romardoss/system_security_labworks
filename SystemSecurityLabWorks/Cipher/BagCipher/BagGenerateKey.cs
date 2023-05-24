using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Media3D;
using Org.BouncyCastle;
using Org.BouncyCastle.Math;

namespace SystemSecurityLabWorks.Cipher.BagCipher
{
    public class BagGenerateKey
    {
        private int _keySize;

        public int KeySize { 
            get
            {
                if (_keySize <= 0)
                {
                    return 5;
                }
                return _keySize;
            }
            set 
            {
                _keySize = value;
            }
        }
        public int[] PrivateSequence { get; private set; }
        public int[] PublicSequence { get; private set; }
        public int M { get; private set; }
        public int T { get; private set; }

        private int[] GeneratePrivateSequence()
        {
            PrivateSequence = new int[KeySize];
            Random random = new Random();
            int min = 1;
            int max = 100;

            for (int i = 0; i < KeySize; i++) 
            {
                PrivateSequence[i] = random.Next(min, max);
                min = PrivateSequence.Sum(x => x) + 1;
                max = min + 100;
            }
            return PrivateSequence;
        }

        public string GetStringOfSequence(int[] sequence)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < KeySize; i++)
            {
                stringBuilder.Append(sequence[i].ToString() + " ");
            }
            return stringBuilder.ToString().Trim();
        }

        private int GenerateM()
        {
            int sum = PrivateSequence.Sum(x => x);
            Random random = new Random();
            sum += random.Next(10000);
            M = sum;
            return sum;
        }

        private int GenerateT()
        { 
            int m = M;
            Random random = new Random();
            int t = random.Next(m);
            while (Gcd(m, t) != 1)
            {
                t = random.Next(m);
            }
            T = t; 
            return T;
        }

        private int Gcd(int a, int b)
        {
            for (int i = b; i > 1; i--)
            {
                if(a % i == 0 && b % i == 0)
                {
                    return i;
                }
            }
            return 1;
        }

        private int[] GeneratePublicSequence()
        {
            PublicSequence = new int[KeySize];

            for (int i = 0; i < KeySize; i++)
            {
                PublicSequence[i] = (PrivateSequence[i] * T) % M;
            }
            return PublicSequence;
        }

        public void GenerateKey()
        {
            GeneratePrivateSequence();
            GenerateM();
            GenerateT();
            GeneratePublicSequence();
        }
    }
}
