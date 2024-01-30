using Maui.ViewModels;

namespace Maui.Views;

public partial class EditarPersonasPage : ContentPage
{
	public EditarPersonasPage()
	{
		InitializeComponent();
	}

    /// <summary>
    /// Hago la llamada al constructor de forma asíncrona y le paso el ViewModel a la vista por aqui.
    /// </summary>
    //protected override void OnAppearing()
    //{
    //    //AgregarEditarPersonaVM viewModel = await AgregarEditarPersonaVM.BuildViewModelAsync();

    //    BindingContext = viewModel;

    //    base.OnAppearing();
    //}
}