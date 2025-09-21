namespace OlderLib {

	internal class FixThese {

		public void SaveData(string path, byte[] data) {
			// use /fix slash command
			var stream = new FileStream(path, FileMode.Create);
			stream.Write(data, 0, data.Length);
		}

		public void ProcessUser(User user) {
			// This will throw error if user is null
			Console.WriteLine(user.Name.ToUpper());
		}
		public string FormatPrice(decimal amount) {
			return "Price: " + amount + " USD";
		}
	}



}
