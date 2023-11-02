using Ejercicio5_ListView.Pages;

namespace Ejercicio5_ListView
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ListViewDemo();
        }
    }
}