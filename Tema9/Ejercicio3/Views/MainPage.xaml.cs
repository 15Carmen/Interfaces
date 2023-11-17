using Ejercicio3.ViewModel;

namespace Ejercicio3.Views
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
            clsPersonaNotify clsPersonaNotify = new clsPersonaNotify();
            BindingContext = clsPersonaNotify;
        }

        
    }
}