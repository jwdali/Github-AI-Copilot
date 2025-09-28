namespace ErrorZone.RuntimeBehavior {
	internal class BuggyMath {
		internal double FutureValue(double principal, double rate, int years) {
			double value = principal;
			for (int i = 0; i < years; i++)
				value = value + rate;
			return value;
		}
	}
}
