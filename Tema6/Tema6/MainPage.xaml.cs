namespace Tema6
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
        }

        private void ClickedBtn2(object sender, EventArgs e)
        {
            btn3.IsVisible = true;
        }

        private void ClickedBtn3(object sender, EventArgs e)
        {
            btn1.IsVisible = false;
            btn2.Text = "Crear controles en tiempo de ejecución mola";
        }


    }
}