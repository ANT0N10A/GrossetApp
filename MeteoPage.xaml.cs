using GrossetApp.Models;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace GrossetApp;

public partial class MeteoPage : ContentPage
{
	private string urlMeteo = "https://api.jsonbin.io/v3/b/662034fead19ca34f85bbe8b";
	private readonly HttpClient _httpClient;
	public ObservableCollection<Daily> dailies {  get; set; } = new();
	public MeteoPage()
	{
		InitializeComponent();
		_httpClient = new HttpClient();
		BindingContext = this;
		collectionViewMeteo.ItemsSource = dailies;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		onLoading();
		LoadingIndicator.IsVisible = true;
	}

	private async void onLoading()
	{
		dailies.Clear();
		var response = await _httpClient.GetFromJsonAsync<MeteoRoot>(urlMeteo);
		response?.record?.timelines?.daily?.ForEach(daily => {dailies.Add(daily); });	 

		LoadingIndicator.IsVisible = false;
	}
}