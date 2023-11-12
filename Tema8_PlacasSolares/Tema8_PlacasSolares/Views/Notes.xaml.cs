namespace Tema8_PlacasSolares.Views;
public partial class Notes : ContentPage
{
	public Notes()
	{
		InitializeComponent();
	}

    /// <summary>
    /// Función que al pulsal el botón de guardar se muestra un mensaje en naranja sobre que
    /// se han guardado los datos correctamente
    /// Pre: ninguna
    /// Post: ninguna
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
        Estado.Text = "Datos guardados correctamente";
        Estado.TextColor = Colors.Orange;
    }

    /// <summary>
    /// Si se pulsa el botón de borrar el texto se muestra un mensaje en rojo  sobre que los datos 
    /// han sido eliminados y se borra el texto
    /// Pre: ninguna
    /// Post: ninguna
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnBorrar_Clicked(object sender, EventArgs e)
    {
        Estado.Text = "Datos borrados";
        Estado.TextColor = Colors.Red;
        Notas.Text = string.Empty;
    }
}