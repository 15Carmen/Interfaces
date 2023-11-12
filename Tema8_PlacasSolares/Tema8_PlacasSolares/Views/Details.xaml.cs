namespace Tema8_PlacasSolares.Views;
using Tema8_PlacasSolares.Modelo.Entidades;

public partial class Details : ContentPage
{
	public Details()
	{
		InitializeComponent();
	}

    /// <summary>
    /// Funci�n que al pulsar la imagen + se podr�a a�adir una foto desde la galeria del dispositivo
    /// Pre: Debe de tener la galer�a alguna foto para subirla
    /// Post: ninguna
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnNuevaFoto_Clicked(object sender, EventArgs e)
    {
       //Work in progress
    }
    
    /// <summary>
    /// Funci�n que al pulsar el bot�n guardar aparece un mensaje en naranja diciendo que los datos
    /// se han guardado de forma correcta
    /// Pre:ninguna
    /// Post: ninguna
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
        lblGuardar.Text = "Datos guardados correctamente";
    }

    /// <summary>
    /// Funci�n que al clickar el checkBox cambia el texto de al lado del mismo. 
    /// Si el checkBox sta seleccionado, el texto cambia para que diga que la casa es apta y pone el checkbox de color naranja
    /// SI el checkBox est� deselecionado, el texto cambia para que diga que no es apta y pone el checkbox de color negro
    /// Pre: ninguna
    /// Post: ninguna
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CasaApta_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if(check.IsChecked == true)
        {
            lblCheck.Text = "Casa apta";
            lblCheck.TextColor = Colors.DarkOrange;
            check.Color = Colors.DarkOrange;
        }
        else
        {
            lblCheck.Text = "Casa no apta";
            lblCheck.TextColor = Colors.Black;
            check.Color = Colors.Black;

        }
        
    }
}
