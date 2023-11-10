
namespace CarmenMartin_Examen9Nov
{
    public partial class MainPage : ContentPage
    {
        public int contadorErrores = 0;
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
        private /*async*/ void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            contadorErrores++;

            if(contadorErrores > 3)
            {

                DisplayAlert("¡Has perdido!", "¿Quieres volver a Jugar?", "Si", "No");

                //Si el usuario elige la opción de volver a jugar, reestablecemos los contadores
                /*if ("Si")
                {
                    contadorErrores = 0;
                    contadorDiferencias = 0;
                    await Navigation.PushAsync(new MainPage()); 

                }else{
                
                    //LA aplicacaión se cierra
                 }*/
            }
        }

        //Falta una función que cuando se clique la zona donde haya una diferencia, se haga visible 
        //la elipse que la marca y qeu añada 1 punto al contador de difererencias


       

       
    }
}