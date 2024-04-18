using GrossetApp.Models;

namespace GrossetApp;

public partial class CittaPage : ContentPage
{
	private string urlCitta = "https://api.jsonbin.io/v3/b/6620334ce41b4d34e4e60a2c";
    private readonly HttpClient _httpClient;
    public CittaPage()
	{
		InitializeComponent();
        _httpClient = new HttpClient();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        onLoading();
        LoadingIndicator.IsVisible = true;
    }

    private async void onLoading()
    {
        
        

        LoadingIndicator.IsVisible = false;
    }
}