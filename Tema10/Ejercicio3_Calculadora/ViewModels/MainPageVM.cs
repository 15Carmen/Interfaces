using Ejercicio3_Calculadora.ViewModels.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ejercicio3_Calculadora.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        #region atributos

        private string displayText;
        private string botonPulsado;
        private DelegateCommand comandoLimpiar;
        private DelegateCommand comandoBorrarCifra;
        private DelegateCommand<string> comandoOperaciones;
        private DelegateCommand<string> comandoNumeros;
        private DelegateCommand comandoResultado;

        #endregion

        #region constructores
        public MainPageVM()
        {
            comandoLimpiar = new DelegateCommand(ComandoLimpiar_Execute, ComandoLimpiar_CanExecute);
            comandoBorrarCifra = new DelegateCommand(ComandoBorrarCifra_Execute, ComandoBorrarCifra_CanExecute);
            comandoOperaciones = new DelegateCommand<string>(ComandoOperaciones_Execute);
            comandoNumeros = new DelegateCommand<string>(ComandoNumeros_Execute);
            comandoResultado = new DelegateCommand(ComandoResultado_Execute, ComandoResultado_CanExecute);
            displayText = "0";
        }
        #endregion

        #region propiedades

        public string DisplayText
        {
            get { return displayText; }
            private set
            {
                if (displayText != value)
                {
                    displayText = value;
                }
            }

        }

        public string BotonPulsado
        {
            get { return botonPulsado; }
            set { botonPulsado = value; }
        }

        public DelegateCommand ComandoLimpiar
        {
            get { return comandoLimpiar; }
        }

        public DelegateCommand ComandoBorrarCifra
        {
            get { return comandoBorrarCifra; }
        }

        public DelegateCommand<string> ComandoOperaciones
        {
            get { return comandoOperaciones; }
        }

        public DelegateCommand<string> ComandoNumeros
        {
            get { return comandoNumeros; }
        }

        public DelegateCommand ComandoResultado
        {
            get { return comandoResultado; }
        }

        #endregion

        #region commands

        private void ComandoLimpiar_Execute()
        {
            if (!DisplayText.Equals("0"))
            {
                DisplayText = "0";
            }
            NotifyPropertyChanged(nameof(DisplayText));
        } 

        private bool ComandoLimpiar_CanExecute()
        {
            bool sePuedeBorrar = false;

            if (!DisplayText.Equals("0"))
            {
                sePuedeBorrar = true;
            }

            return sePuedeBorrar;
        }

        private void ComandoBorrarCifra_Execute()
        {
            DisplayText = DisplayText.Substring(0, DisplayText.Length - 1);

            if (DisplayText == "")
            {
                DisplayText = "0";
            }

            NotifyPropertyChanged(nameof(DisplayText));
        }

        private bool ComandoBorrarCifra_CanExecute()
        {
            bool borrarCifra = false;

            if(DisplayText.Length > 1 || DisplayText != "0")
            {
                borrarCifra = true;
            }

            return borrarCifra;
        }

        private void ComandoOperaciones_Execute(Object args)
        {
            BotonPulsado = args.ToString();

            switch (BotonPulsado)
            {
                case "+":
                    DisplayText += "+";
                    break;
                case "-":
                    DisplayText += "-";
                    break;
                case "*":
                    DisplayText += "*";
                    break;
                case "/":
                    DisplayText += "/";
                    break;
            }


            NotifyPropertyChanged(nameof(DisplayText));
            ComandoLimpiar.RaiseCanExecuteChanged();
            ComandoBorrarCifra.RaiseCanExecuteChanged();
        }

        private void ComandoNumeros_Execute(Object args)
        {
            BotonPulsado = args.ToString();

            if (DisplayText.StartsWith("0") && !DisplayText.StartsWith("0."))
            {
                DisplayText = DisplayText.Substring(1);
            }

            switch (BotonPulsado)
            {
                case "0":
                    DisplayText += "0";
                    break;
                case "1":
                    DisplayText += "1";
                    break;
                case "2":
                    DisplayText += "2";
                    break;
                case "3":
                    DisplayText += "3";
                    break;
                case "4":
                    DisplayText += "4";
                    break;
                case "5":
                    DisplayText += "5";
                    break;
                case "6":
                    DisplayText += "6";
                    break;
                case "7":
                    DisplayText += "7";
                    break;
                case "8":
                    DisplayText += "8";
                    break;
                case "9":
                    DisplayText += "9";
                    break;

            }

            NotifyPropertyChanged(nameof(DisplayText));
            ComandoLimpiar.RaiseCanExecuteChanged();
            ComandoBorrarCifra.RaiseCanExecuteChanged();
        }

        private void ComandoResultado_Execute()
        {
            //Todo
        }

        private bool ComandoResultado_CanExecute()
        {
            bool hacerOperacion = false;

            if (!DisplayText.Equals("0"))
            {
                hacerOperacion = true;
            }

            return hacerOperacion;

        }

        #endregion



    }
}
