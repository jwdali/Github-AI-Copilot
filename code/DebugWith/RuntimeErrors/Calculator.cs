using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuntimeErrors {
	internal class Calculator {
		// Intentionally minimal implementation that throws on divide by zero
		public static int Divide(int a, int b) {
			return a / b;
		}
	}
}
