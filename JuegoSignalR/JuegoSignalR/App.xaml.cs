using JuegoSignalR.Views;

namespace JuegoSignalR
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            App.Current.MainPage = new GamePage();
        }
    }
}
