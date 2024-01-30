using Maui.ViewModels;

namespace Maui.Views;

public partial class VistaDepartamentosPage : ContentPage
{
    public VistaDepartamentosPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Hago la llamada al constructor de forma asíncrona y le paso el ViewModel a la vista por aqui.
    /// </summary>
    protected override async void OnAppearing()
    {
        VistaDepartamentosVM viewModel = await VistaDepartamentosVM.BuildViewModelAsync();
        this.BindingContext = viewModel;
        InitializeComponent();
        base.OnAppearing();
    }
}