using Biblioteca;
using Ejercicio2.Views;

namespace Ejercicio2
{
    public partial class MainPage : ContentPage
    {       

        public MainPage()
        {
            InitializeComponent();
        }

        clsPersona persona = new clsPersona();

        private async void btnTabbedPageClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaTabbed());
        }

        private async void btn4PageClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page4(persona));

            persona.Nombre = txtNombre.Text;
            persona.Apellidos = txtApellidos.Text;

        }

        private async void btn5PageClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page5());
        }
    }
}