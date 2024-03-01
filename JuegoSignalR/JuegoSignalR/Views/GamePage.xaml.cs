using JuegoSignalR.ViewModels;

namespace JuegoSignalR.Views;

public partial class GamePage : ContentPage
{
	public GamePage()
	{
		InitializeComponent();
		this.BindingContext = new GamePageVM();
	}
}