using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularPrime {
    class Program {
        static void Main(string[] args) {
            CircularPrime.FindPrimeList(100);
            if ("abc".Contains("a")) Console.WriteLine("a");

            Console.ReadLine();
        }
    }
    class CircularPrime {
        public static int[] Find(int searchUntilNum) {
            List<int> prime = FindPrimeList(searchUntilNum);
            List<int> circularPrime = new List<int>();
            foreach (int num in prime) {
                if (num < 10) {
                    circularPrime.Add(num);
                }
                string sNum = num.ToString();
                if ((sNum.Contains("2")) || (sNum.Contains("4")) || (sNum.Contains("6")) || (sNum.Contains("8"))
                    || (sNum.Contains("0"))) {
                    continue;
                }

            }
            return null;
        }
        // Sieve of Eratosthenes
        public static List<int> FindPrimeList(int searchUntilNum) {
            bool[] num = new bool[searchUntilNum + 1];
            //added one extra bool to array - 0 to make code more readable -
            //we can use i and j without -1 each time
            List<int> prime = new List<int>();
            double upperLimit = Math.Pow(searchUntilNum, 0.5);
            for (int i = 2; i < upperLimit; i++) {
                if (num[i]) continue;
                for (int j = i * i; j <= searchUntilNum; j += i) {
                    if (j % i == 0) num[j] = true;
                }
            }
            for (int i = 1; i < num.Length; i++) {
                if (num[i]) continue;
                prime.Add(i);
            }
            return prime;
        }
    }
}
