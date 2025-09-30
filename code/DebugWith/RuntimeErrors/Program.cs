

namespace RuntimeErrors {
	internal class Program {
		static void Main(string[] args) {
			Console.WriteLine("Runtime Errors!");

			ShowMenu();
			// TryCalculator();
			// TryDataProcess();


		}
		

		internal static void ShowMenu() {
			Console.WriteLine("Book List Exception Scenario:");
			while (true)
			{
				Console.WriteLine();
				Console.Write("Pick a number between 1 and 10 (or type 'exit' to quit): ");
				var ordinalInput = Console.ReadLine();
				if (ordinalInput?.Trim().ToLower() == "exit")
					break;
				int ordinal = 0;
				if (int.TryParse(ordinalInput, out ordinal))
				{
					TryBookList(ordinal);
				}
				else
				{
					Console.WriteLine("Invalid input. Please enter a number or 'exit'.");
				}
			}
		}
		
		internal static void TryBookList(int ordinal) {
			
			var books = new List<Book> {
				new Book("C# in Depth", 45.99m),
				new Book("Pro .NET 8", 39.99m),
				new Book("Clean Code", 42.50m),
				new Book("The Pragmatic Programmer", 38.00m),
				new Book("Design Patterns", 50.00m)
			};
			Book selectedBook = books[ordinal - 1];
			Console.BackgroundColor = ConsoleColor.DarkBlue;
			Console.WriteLine($"  Book: {selectedBook.BookTitle}, Price: {selectedBook.Price:C}");
			Console.ResetColor();
		}
		internal static void TryCalculator() {
			System.Console.WriteLine("Runtime scenario: divide by input");
			var result = Calculator.Divide(10, 0); // runtime error when denominator is zero
			System.Console.WriteLine($"Result: {result}");

		}
		internal static void TryDataProcess() {
			Console.WriteLine("Exception scenario: process data");
			var processor = new DataProcessor();
			// Intentionally pass null to trigger NullReferenceException
			Console.WriteLine($"Sum of positives: {processor.SumPositive(null)}");
		}

	}
}
