namespace Ejercicio2.Views;

public partial class Page3 : ContentPage
{
	public Page3()
	{
		InitializeComponent();
	}

    private async void btnMainClick(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new MainPage());
    }
}