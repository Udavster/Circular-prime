using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularPrime {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Started finding circular prime numbers");
            int[] cPrime = CircularPrime.Find(1000000);
            Console.WriteLine("Done");
            for (int i = 0; i < cPrime.Length; i++) {
                Console.Write("{0}\t", cPrime[i]);
                if ((i+1) % 10 == 0) {
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\n\nNumber of circular prime numbers: {0}", cPrime.Length);
            Console.ReadLine();
        }
    }
    class CircularPrime {
        public static int[] Find(UInt32 searchUntilNum) {
            List<int> prime = GetPrimeList(searchUntilNum);
            List<string> sPrime = prime.ConvertAll<string>(delegate(int i) { return i.ToString(); });
            List<string> sCircularPrime = new List<string>();
            foreach (string sNum in sPrime) {
                if (sNum.Length < 2) {
                    sCircularPrime.Add(sNum);
                    continue;
                }
                if ((sNum.Contains("2")) || (sNum.Contains("4")) || (sNum.Contains("6")) || (sNum.Contains("8"))
                    || (sNum.Contains("0"))) {
                    continue;
                }
                if (checkIfCircular(sNum, sPrime)) {
                    sCircularPrime.Add(sNum);
                } 
            }
            return sCircularPrime.ConvertAll<int>(delegate(string str) { return Int32.Parse(str); }).ToArray();
        }
        private static bool checkIfCircular(string sNum, List<string> list) {
            for (int i = 0; i < sNum.Length; i++) {
                sNum = sNum[sNum.Length - 1] + sNum.Substring(0, sNum.Length - 1);
                if (!list.Contains(sNum)) {
                    return false;
                }     
            }
            return true;
        }
        // Sieve of Eratosthenes
        private static List<int> GetPrimeList(UInt32 searchUntilNum) {
            bool[] num = new bool[searchUntilNum + 1];
            //added one extra bool to array - 0 to make code more readable -
            //we can use i and j without -1 each time
            List<int> prime = new List<int>();
            double upperLimit = Math.Pow(searchUntilNum, 0.5);
            num[1] = true; //1 is not prime number (https://en.wikipedia.org/wiki/Prime_number)
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
