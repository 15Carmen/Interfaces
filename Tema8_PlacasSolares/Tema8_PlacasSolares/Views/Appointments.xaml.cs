using System.Collections.ObjectModel;
using Tema8_PlacasSolares.Modelo.DAL;
using Tema8_PlacasSolares.Modelo.Entidades;

namespace Tema8_PlacasSolares.Views;

public partial class Appointments : ContentPage
{
    ObservableCollection<clsCitas> Citas { get { return clsListaCitas.listadoCompletoCitas(); } }

    public Appointments()
	{
		InitializeComponent();
		ListViewCitas.ItemsSource = Citas;
	}

	private async void toDetails(object sender, EventArgs e) 
	{

        await Navigation.PushAsync(new Details());

    }


}