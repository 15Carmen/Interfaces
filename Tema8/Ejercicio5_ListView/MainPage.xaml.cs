using Ejercicio5_ListView.DAL;
using Ejercicio5_ListView.Entidades;
using System.Collections.ObjectModel;

namespace Ejercicio5_ListView
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<clsPersona> Personas { get { return clsListadoPersonas.listaPersonas(); } }

        public MainPage()
        {
            InitializeComponent();
            ListViewPersonas.ItemsSource = Personas; 
        }

    }
}