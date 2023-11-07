namespace Tema8_PlacasSolares.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

	private async void clickEntrar(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Appointments());
	}
}
