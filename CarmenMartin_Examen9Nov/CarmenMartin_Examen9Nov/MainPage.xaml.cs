
using Microsoft.Maui.Controls.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarmenMartin_Examen9Nov
{
    public partial class MainPage : ContentPage
    {
        int contadorErrores = 0;
        int contadorDiferencias = 0;
  

        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Función que cada vez que se clique una parte de la página que no tiene una diferencia, aumente el 
        /// contador de errores. Cuando se llegue a 3 errores lanzará un mensaje diciendo que hemos perdido
        /// Pre: ninguna
        /// Post: En el mensaje debe de darse la opción de jugar de nuevo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TapImagen(object sender, TappedEventArgs e)
        {
            contadorErrores++;
            lblContadorErrores.Text = $"Errores cometidos: {contadorErrores}";
            
            if (contadorErrores == 3)
            {

                bool volverAJugarDerrota = await DisplayAlert("¡Has perdido!", "¿Quieres volver a Jugar?", "Si", "No");

                //Si el usuario elige la opción de volver a jugar, reestablecemos los contadores
                if (volverAJugarDerrota)
                {
                    contadorErrores = 0;
                    contadorDiferencias = 0;

                    ellipEspalda.Opacity = 0;
                    ellipEspalda2.Opacity = 0;
                    ellipCasa.Opacity = 0;
                    ellipCasa2.Opacity = 0;
                    ellipHueso.Opacity = 0;
                    ellipHueso2.Opacity = 0;

                }
                else{
                
                    Application.Current.Quit();
                 }
            }
        }

        //Falta una función que cuando se clique la zona donde haya una diferencia, se haga visible 
        //la elipse que la marca y qeu añada 1 punto al contador de difererencias

        private async void TapEllipse(object sender, TappedEventArgs e)
        {
            contadorDiferencias++;
            lblContadorAciertos.Text = $"Diferencias encontradas: {contadorDiferencias}";

            Ellipse ellipseGeneral = (Ellipse)sender;

            ellipseGeneral.Opacity = 1;

            if (contadorDiferencias >= 3)
            {
                bool volverAJugarVictoria = await DisplayAlert("¡Has ganado!", "¿Quieres volver a jugar?", "Si", "No");

                //Si el usuario elige la opción de volver a jugar, reestablecemos los contadores
                if (volverAJugarVictoria)
                {
                    contadorErrores = 0;
                    contadorDiferencias = 0;

                    ellipEspalda.Opacity = 0;
                    ellipEspalda2.Opacity = 0;
                    ellipCasa.Opacity = 0;
                    ellipCasa2.Opacity = 0;
                    ellipHueso.Opacity = 0;
                    ellipHueso2.Opacity = 0;

                }
                else
                {

                    Application.Current.Quit();
                }
            }
           

        }


       

       
    }
}