using Biblioteca;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace HolaMundo_C__UWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// prototipo: private void btnAccion_Click(object sender, RoutedEventArgs e)
        /// comentarios: Evento asociado al botón click saludar. Mostrará por pantalla el nombre de la persona escrito en una ventana a parte.
        /// precondiones: No tiene.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// postcondiciones: No devuelve nada ya que es un evento.

        private async void boton_Click(object sender, RoutedEventArgs e)
        {
            clsPersona usuario = new clsPersona();
            usuario.Nombre = textBox.Text;
            var cuadro = new MessageDialog("");
            if (usuario.Nombre == null || usuario.Nombre.Equals("") || usuario.Nombre.StartsWith(" "))
            {
                txtError.Text = "No has introducido un nombre.";
                txtError.Visibility = Visibility.Visible;
            }
            else
            {

                cuadro = new MessageDialog("Hola " + usuario.Nombre);
            }
            await
            cuadro.ShowAsync();
        }

    }
}
