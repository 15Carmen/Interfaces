using Biblioteca;

namespace Tema5_Ejercicio1_HelloWorld
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnCounterClicked(object sender, EventArgs e)
        {
            string apellidos = await DisplayPromptAsync("Completa tu nombre", "Introduce tus apellidos");
            string name = txtNombre.Text;

            clsPersona persona = new clsPersona(name, apellidos);

            await DisplayAlert("Saludo", "Hola "+ persona.NombreCompleto, "ok");
        }

     
    }
}