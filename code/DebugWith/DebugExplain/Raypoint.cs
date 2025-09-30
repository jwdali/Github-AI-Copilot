namespace DebugExplain {
	public class RayPoint {
		public double X { get; set; }
		public double Y { get; set; }
		public double Z { get; set; }

		public RayPoint(double x, double y, double z) {
			X = x;
			Y = y;
			Z = z;
		}

		public void Offset(double value) {
			X += value;
			Y += value;
			Z += value;
		}
	}
}
