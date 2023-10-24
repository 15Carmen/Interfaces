using Biblioteca;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejercicio2.Views;

public partial class Page4 : ContentPage
{

	public Page4()
	{
		InitializeComponent();
	}

	public Page4(clsPersona persona)
    {
		InitializeComponent();

        Nombre.Text = persona.Nombre;
        Apellidos.Text = persona.Apellidos;

    }
}