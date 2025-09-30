using System.Diagnostics;

namespace DebugExplain {
	internal class Program {
		static void Main(string[] args) {
			Console.WriteLine("Debug Explain");
			// Also known as 'variable analyze'

			AnalyzeRayPointX();
		//	AnalyzeImmutable();
		//	AnalyzeChain();

		}
		public static void AnalyzeRayPointX() {

			var point = new RayPoint(11, 22, 33);
			point.X += 10;
			point.Y += 30;

			point.Offset(5);

			Console.WriteLine($"RayPoint: {point.X}, {point.Y}, {point.Z}");


			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		public static void AnalyzeImmutable() {

			var iPoint = new ImmutableRayPoint(44.0, 55.0, 66.0);
			iPoint = iPoint.Offset(10.0);
			iPoint = iPoint.SetZ(100.0);
			Console.WriteLine($"ImmutableRayPoint: {iPoint.X}, {iPoint.Y}, {iPoint.Z}");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		public static void AnalyzeChain() {
			//
			// Longer chain of state change calls.
			var point = new RayPoint(5, 10, 15);

			Panner.Pan(point, 7); 
			Zoomer.Zoom(point, 3); 
			

			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}
}
