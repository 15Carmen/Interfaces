using Biblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3.ViewModel
{
    public class clsPersonaNotify : INotifyPropertyChanged
    {

        #region Atributos
        private string nombreNotify;
        private clsPersona persona = new clsPersona();
        #endregion

        #region Constructores

        public clsPersonaNotify()
        {
            this.nombreNotify = persona.Nombre;
        }

        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return nombreNotify; }
            set
            {
                nombreNotify = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Métodos

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
