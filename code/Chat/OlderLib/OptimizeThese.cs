namespace OlderLib {
	internal class OptimizeThese {

		public int CalculateSum(int[] items) {
			// use /optimize slash command
			int sum = 0;
			for (int i = 0; i < items.Length; i++)
			{
				sum += items[i];
			}
			return sum;
		}

		public List<User> GetActiveUsers(List<User> users) {
			// use /optimize slash command
			var result = new List<User>();
			foreach (var u in users)
			{
				if (u.IsActive)
				{
					result.Add(u);
				}
			}
			return result;
		}

		public void MessageExample() {
			var contents = new List<string> { "One", "Two", "Three" };
			var messages = new List<Message>();

			for (int i = 0; i < contents.Count; i++)
			{
				var msg = new Message();
				msg.Content = contents[i];
				messages.Add(msg);
			}
		}

	}
	public class Message {
		public string Content { get; set; }
	}
}
