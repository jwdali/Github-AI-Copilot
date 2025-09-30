using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorZone {
	internal class PrimeGenerator {

		public static List<int> GetPrimes(int minValue, int maxValue) {
			// Sieve of Eratosthenes implementation
			if (maxValue < 2 || minValue > maxValue) return new List<int>();

			bool[] isPrimeArray = new bool[maxValue + 1];
			Array.Fill(isPrimeArray, true);
			isPrimeArray[0] = false;
			isPrimeArray[1] = false;

			int maxPrimeFactor = (int)Math.Sqrt(maxValue);
			for (int primeCandidate = 2; primeCandidate <= maxPrimeFactor; primeCandidate++)
			{
				if (isPrimeArray[primeCandidate])
				{
					for (int multiple = primeCandidate * primeCandidate; multiple <= maxValue; multiple += primeCandidate)
					{
						isPrimeArray[multiple] = false;
					}
				}
			}

			List<int> primeList = new List<int>();
			for (int number = Math.Max(minValue, 2); number <= maxValue; number++)
			{
				if (isPrimeArray[number]) primeList.Add(number);
			}
			return primeList;
		}
	}
}
