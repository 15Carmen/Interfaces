using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4.ViewModel
{
    public class clsPersona : INotifyPropertyChanged
    {

        #region Atributos
        private string nombre;
        private string apellidos;
        #endregion

        #region Constructores

        public clsPersona()
        {
            nombre = "";
            apellidos = "";
        }
        public clsPersona(string nombre, string apellidos)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
        }

        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                NotifyPropertyChanged();
                
                if (nombre.Contains("n"))
                {
                    apellidos = "";
                    NotifyPropertyChanged("Apellidos");
                }

            }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set
            {
                apellidos = value;
               NotifyPropertyChanged() ;

                if (apellidos.Contains("n"))
                {
                    nombre = "";
                    NotifyPropertyChanged("Nombre");
                }
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
