namespace SimpleConsole {

	internal class Program {

		private static async Task Main(string[] args) {
			Console.WriteLine("Hello, World!");

			Console.WriteLine(await ShowIntellicode.GetWeather());
		}

	}
}