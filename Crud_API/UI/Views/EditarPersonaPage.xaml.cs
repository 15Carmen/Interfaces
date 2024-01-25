using UI.Models;
using UI.ViewModels;
using Entidades;

namespace UI.Views;

public partial class EditarPersonaPage : ContentPage
{
	public EditarPersonaPage(clsPersonaConNombreDepartamento persona)
	{
		InitializeComponent();

        EditarPersonaVM vm = new EditarPersonaVM(persona);
        BindingContext = vm;
    }
}