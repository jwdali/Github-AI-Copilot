namespace VisualizerQuery {
	internal class Program {
		static void Main(string[] args) {
			Console.WriteLine("Visualize and Query");

			TryGreen();
			TrySaturation();

		}

		static void TryGreen() {
			Console.WriteLine("Green Colors Demo:");
			var worker = new WorkWithLists();
			var greens = worker.GetGreenColors();
			foreach (var color in greens)
			{
				Console.WriteLine($"  {color.ColorName}: {color.GreenPercent:P0}");
			}
		}
		static void TrySaturation() {
			Console.WriteLine("SaturatedColors:");
			var worker = new WorkWithLists();
			var colors = worker.GetSat();
			foreach (var color in colors)
			{
				Console.WriteLine($"  {color.ColorName}: {color.HSL.Saturation:P0}");
			}
		}
	}
}
