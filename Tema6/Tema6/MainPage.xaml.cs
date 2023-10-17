namespace Tema6
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
        }

        Boolean btnYaCreado = false;


        /// <summary>
        /// Método que crea al clickar el boton 2 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickedBtn2(object sender, EventArgs e)
        {
            //btn3.IsVisible = true;

            if (btnYaCreado!=true)
            {
                Button btn3 = new Button();
                
                btn3.Text = "Boton3";
                btn3.HorizontalOptions = LayoutOptions.Center;
                btn3.VerticalOptions = LayoutOptions.Center;
                btn3.BackgroundColor = Colors.CornflowerBlue;
                btn3.HeightRequest = 70;
                btn3.WidthRequest = 200;
                btn3.FontFamily = "Verdana";
                btn3.FontSize = 16;
                btn3.BorderColor = Colors.Yellow;
                btn3.Margin = 30;

                botones.Add(btn3);
                btn3.Clicked += ClickedBtn3;
                btnYaCreado = true;

            }

           
        }

        private void ClickedBtn3(object sender, EventArgs e)
        {
            botones.Remove(btn1);
            btn2.Text = "Crear controles en tiempo de ejecución mola";
            btn2.WidthRequest = 400;
        }

       


    }
}