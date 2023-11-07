using Tema8_PlacasSolares.Views;

namespace Tema8_PlacasSolares
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
           
        }

    }
}