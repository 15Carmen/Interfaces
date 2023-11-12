using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Tema8_PlacasSolares.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void clickEntrar(object sender, EventArgs e)
    {
        if (nombreUsuario.Text is not null && password.Text is not null)
        {
            await Navigation.PushAsync(new Appointments());
        }
        else
        {
            DisplayAlert("Advertencia", "Debe introducir nombre y contraseña", "OK");
        }

    }
}