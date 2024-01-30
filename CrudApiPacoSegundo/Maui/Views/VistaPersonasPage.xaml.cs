using Maui.ViewModels;

namespace Maui.Views;

public partial class VistaPersonasPage : ContentPage
{
	public VistaPersonasPage()
	{
		InitializeComponent();
	}

    /// <summary>
    /// Hago la llamada al constructor de forma asíncrona y le paso el ViewModel a la vista por aqui.
    /// </summary>
    protected override async void OnAppearing()
    {
        VistaPersonasVM viewModel = await VistaPersonasVM.BuildViewModelAsync();
        //viewModel.Cargando = true;
        BindingContext = viewModel;
        //viewModel.Cargando = false;
        base.OnAppearing();
    }
}