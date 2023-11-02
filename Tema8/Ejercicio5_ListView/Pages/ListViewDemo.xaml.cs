using Ejercicio5_ListView.Models;

namespace Ejercicio5_ListView.Pages;

public partial class ListViewDemo : ContentPage
{
	public ListViewDemo()
	{
		InitializeComponent();

		var personas = new List<clsPersona>
		{
			new clsPersona {Nombre="Carmen", Apellidos = "Mart�n"},
            new clsPersona {Nombre="Isa", Apellidos = "Loerzer"},
            new clsPersona {Nombre="Luisa", Apellidos = "Alejandra"},
            new clsPersona {Nombre="Lydia", Apellidos = "P�rez"},
            new clsPersona {Nombre="Paco", Apellidos = "De Paula"},
            new clsPersona {Nombre="Javi", Apellidos = "Gonz�lez"},
            new clsPersona {Nombre="Miguel", Apellidos = "Fern�ndez"},
            new clsPersona {Nombre="Fernando", Apellidos = "Gal�n"},
            new clsPersona {Nombre="Luke", Apellidos = "Skywalker"},
            new clsPersona {Nombre="Obi-Wan", Apellidos = "Kenobi"},
        };

        listView.ItemsSource = personas;

	}
}