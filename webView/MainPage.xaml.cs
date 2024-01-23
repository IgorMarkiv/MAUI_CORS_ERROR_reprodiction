namespace webView
{
	public partial class MainPage : ContentPage
	{
		int count = 0;
		HttpClient httpClient = new HttpClient();

		public MainPage()
		{
			InitializeComponent();
		}

		private void OnCounterClicked(object sender, EventArgs e)
		{
			// Existing code to update counter
		}

		// Method to handle button clicks and update WebView
		private async void OnButtonClicked(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			string url = button.CommandParameter.ToString(); // URL will be set as CommandParameter in XAML

			try
			{
				string html = await httpClient.GetStringAsync(url);
				MyWebView.Source = new HtmlWebViewSource { Html = html, BaseUrl = url };
			}
			catch (Exception ex)
			{
				// Handle exceptions, such as network errors
				await DisplayAlert("Error", $"Failed to load content: {ex.Message}", "OK");
			}
		}


	}

}
