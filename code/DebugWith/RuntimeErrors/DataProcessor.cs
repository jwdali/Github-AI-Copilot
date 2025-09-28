using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuntimeErrors {
	internal class DataProcessor {
		// Bug: will throw NullReferenceException when items is null
		public int SumPositive(List<int> items) {
			int sum = 0;
			foreach (var x in items) // Exception thrown here when items == null
			{
				if (x > 0) sum += x;
			}
			return sum;
		}
	}
}
