using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Models.Entidades
{
    public class clsPersona : INotifyPropertyChanged
    {
        #region Atributos
        private string nombre;
        #endregion

        #region Constructores

        public clsPersona()
        {
            nombre = "Carmen";
        }
        public clsPersona(string nombre)
        {
            this.nombre = nombre;
        }

        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                NotifyPropertyChanged();  //Dentro de los parentesis pasamos las propiedades que deben mandarse, o 
                //ninguna cosa, porque abajo pilla el nombre de la propiedad que lo esta llamando
            }
        }

        

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
