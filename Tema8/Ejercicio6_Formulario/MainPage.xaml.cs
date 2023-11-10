using System.Diagnostics;

namespace Ejercicio6_Formulario
{
    public partial class MainPage : ContentPage
    {
        bool nombreCambiado = false;
        bool apellidosCambiados = false;
        public MainPage()
        {
            InitializeComponent();
            DateFechaNac.MaximumDate = DateTime.Today;
        }

        private void EntryNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            nombreCambiado = true;
        }

        private void EntryApellidos_TextChanged(object sender, TextChangedEventArgs e)
        {
            apellidosCambiados = true;
        }

        private void Guardar_Pressed(object sender, EventArgs e)
        {
            bool fechaBien = true;

            if (DateTime.Now.Year - DateFechaNac.Date.Year < 12)
            {
                EstadoFecha.Text = "Debes ser mayor de 12 años";
                EstadoFecha.TextColor = Colors.Red;
                fechaBien = false;
            }
            else
            {
                EstadoFecha.Text = "";
            }

            if (compruebaNombre() && compruebaApellidos() && fechaBien)
            {
                Estado.Text = "Usuario registrado con éxito";
                Estado.TextColor = Colors.Green;
            }
            else
            {
                Estado.Text = "Datos introducidos inválidos";
                Estado.TextColor = Colors.Red;
            }
        }

        private void Añadir_Pressed(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;

            EntryNombre.Text = "";
            EntryApellidos.Text = "";
            DateFechaNac.Date = fechaActual;

            Estado.Text = "";
        }

        private async void Eliminar_Pressed(object sender, EventArgs e)
        {
            bool seguro = await DisplayAlert("¿Seguro?", "Estás a punto de borrar los datos del anterior usuario, ¿estás seguro?", "Sí", "No");
            Debug.WriteLine(seguro);

            if (seguro)
            {
                EntryNombre.Text = "";
                EntryApellidos.Text = "";
                DateFechaNac.Date = DateTime.Today;
                Estado.Text = "Datos eliminados correctamente";
                Estado.TextColor = Colors.Green;
            }
        }

        private void DateFechaNac_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private bool compruebaNombre()
        {
            bool nombreBien = true;

            if (EntryNombre.Text == null || !nombreCambiado || EntryNombre.Text == "")
            {
                EstadoNombre.Text = "Nombre incorrecto";
                EstadoNombre.TextColor = Colors.Red;
                nombreBien = false;
            }
            else
            {
                EstadoNombre.Text = "";
            }
            return nombreBien;
        }
        private bool compruebaApellidos()
        {
            bool apellidosBien = true;
            if (EntryApellidos.Text == null || !apellidosCambiados || EntryApellidos.Text == "")
            {
                EstadoApellidos.Text = "Apellidos incorrectos";
                EstadoApellidos.TextColor = Colors.Red;
                apellidosBien = false;
            }
            else
            {
                EstadoApellidos.Text = "";
            }
            return apellidosBien;
        }
    }
}