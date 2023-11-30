using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ejercicio3_Calculadora.ViewModels
{
    public class MainPageVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region atributos

        private string labelShowOperation = "0";
        #endregion

        #region propiedades

        public string LabelShowOperation
        {
            get { return labelShowOperation; }
        }

        public ICommand comandoLimpiar { get; set; }
        public ICommand comandoBorrarCifra {  get; set; }
        public ICommand comandoOperaciones { get; set; }
        public ICommand comandoNumeros { get; set; }
        public ICommand comandoResultado { get; set; }

        #endregion

        #region constructores

        public MainPageVM()
        {
            
           
        }

        #endregion



    }
}
