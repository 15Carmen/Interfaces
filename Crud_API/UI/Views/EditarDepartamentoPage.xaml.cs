using UI.Models;
using UI.ViewModels;
using Entidades;

namespace UI.Views;

public partial class EditarDepartamentoPage : ContentPage
{
	public EditarDepartamentoPage(clsDepartamento departamento)
	{
		InitializeComponent();

		EditarDepartamentoVM vm = new EditarDepartamentoVM(departamento);
		BindingContext = vm;
	}
}