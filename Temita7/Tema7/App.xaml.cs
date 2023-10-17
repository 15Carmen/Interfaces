using Tema7.Views;

namespace Tema7
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Tema7.Views.PaginaTabbed();
        }
    }
}