namespace Tema7
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
    }
}