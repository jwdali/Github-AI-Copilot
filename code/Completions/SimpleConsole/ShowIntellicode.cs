namespace SimpleConsole {
	internal class ShowIntellicode {

		public static async Task<string> GetWeather() {
			// Free weather API (no key required)
			// Seattle coordinates: latitude=47.6062, longitude=-122.3321
			string url = "https://api.open-meteo.com/v1/forecast?latitude=47.6062&longitude=-122.3321&current_weather=true";


			return string.Empty;
		}



		//public static async Task<string> GetWeatherDone() {
		//	// Free weather API (no key required)
		//	// Seattle coordinates: latitude=47.6062, longitude=-122.3321
		//	string url = "https://api.open-meteo.com/v1/forecast?latitude=47.6062&longitude=-122.3321&current_weather=true";
		//	HttpClient client = new HttpClient();
		//	client.MaxResponseContentBufferSize = 1024;
		//	client.DefaultRequestHeaders.Accept.Clear();

		//	var weather = await client.GetStringAsync(url);

		//	return weather;

		//}

	}
}
