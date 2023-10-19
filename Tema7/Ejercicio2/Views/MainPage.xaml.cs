namespace Ejercicio2
{
    public partial class MainPage : ContentPage
    {       

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabbedPage());
        }
    }
}