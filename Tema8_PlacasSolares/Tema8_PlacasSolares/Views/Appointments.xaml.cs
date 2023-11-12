using System.Collections.ObjectModel;
using Tema8_PlacasSolares.Modelo.DAL;
using Tema8_PlacasSolares.Modelo.Entidades;

namespace Tema8_PlacasSolares.Views;

public partial class Appointments : ContentPage
{

	/// <summary>
	/// Función que devuelve un listado con todas las citas guardadas en la clase clsListaCita
	/// </summary>
    ObservableCollection<clsCitas> Citas { get { return clsListaCitas.listadoCompletoCitas(); } }

    public Appointments()
	{
		InitializeComponent();
		ListViewCitas.ItemsSource = Citas;
	}

	/// <summary>
	/// Función que al pulsar cualquier elemento del listado de citas, se abre una nueva página tabbed con los
	/// detalles de la cita y con las notas de la misma
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private async void toDetails(object sender, SelectedItemChangedEventArgs e) 
	{

        await Navigation.PushAsync(new PaginaTabbed { BindingContext = e.SelectedItem as clsCitas});

    }


}