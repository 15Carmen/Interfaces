using Maui.ViewModels;

namespace Maui.Views;

public partial class DetallesPersonaPage : ContentPage
{
	public DetallesPersonaPage()
	{
		InitializeComponent();
	}

    /// <summary>
    /// Hago la llamada al constructor de forma asíncrona y le paso el ViewModel a la vista por aqui.
    /// </summary>
    protected override async void OnAppearing()
    {
        AgregarEditarPersonaVM viewModel = await AgregarEditarPersonaVM.BuildViewModelAsync();
        this.BindingContext = viewModel;
        InitializeComponent();
        base.OnAppearing();
    }
}