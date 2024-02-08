using Entidades;
using UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.ViewModels.Utilidades;
using MauiBL;

namespace UI.ViewModels
{
    public class ListaPersonasVM : clsVMBase
    {

        #region atributos

        private int numAciertos;
        private int numIntentos;
        private ObservableCollection<clsPersonaListaDepartamentos> listaPersonasDepartamento;
        private DelegateCommand comprobarCommand;
        private clsDepartamento departamento;

        #endregion

        #region constructores

        public ListaPersonasVM() 
        {
            CargarListadoPersonas();
            numAciertos = 0;
            numIntentos = 3;
            comprobarCommand = new DelegateCommand(ComprobarCommand_Execute, ComprobarCommand_CanExecute);
            departamento = null;

        }

        #endregion

        #region propiedades

        public int NumAciertos
        {
            get { return numAciertos; }
            set { numAciertos = value; }
        }

        public int NumIntentos
        {
            get { return numIntentos; }
            set { numIntentos = value; }
        }

        public ObservableCollection<clsPersonaListaDepartamentos> ListaPersonasDepartamento
        {
            get { return listaPersonasDepartamento; }
        }

        public DelegateCommand ComprobarCommand { 
            get { return comprobarCommand; }
        }

        public clsDepartamento Departamento
        {
            get { return departamento; }
        }

        #endregion

        #region commands

        private void ComprobarCommand_Execute()
        {
            foreach(clsPersonaListaDepartamentos personaListaDepartamento in ListaPersonasDepartamento)
            {
                if (Departamento.Nombre.Equals(personaListaDepartamento.DepartamentoEscogido.Nombre))
                {
                    NumAciertos += 1;
                }
            }
            
            ComprobarCommand.RaiseCanExecuteChanged();
        }

        private bool ComprobarCommand_CanExecute ()
        {
            bool seComprueba = false;

            if(Departamento != null)
            {
                seComprueba = true;
            }

            return seComprueba;
        }

        #endregion

        #region funciones y métodos

        /// <summary>
        /// Función que cargará el listado completo de las personas en la vista
        /// </summary>
        private async void CargarListadoPersonas()
        {
            List<clsPersona> listaPersonas = new List<clsPersona>(await clsHandlerPersonasBL.getListadoCompletoPersonasBL());
            List<clsDepartamento> listaAuxDepartamentos = new List<clsDepartamento>(await clsHandlerDepartamentosBL.getListadoCompletoDepartamentosBL());

            clsPersonaListaDepartamentos pd;

            //Recorremos la lista de personas
            foreach (clsPersona p in listaPersonas)
            {
                pd = new clsPersonaListaDepartamentos(p);

                listaPersonasDepartamento.Add(pd);


                foreach (clsDepartamento d in listaAuxDepartamentos)
                {
                    if (d != null)
                    {
                        listaAuxDepartamentos.Add(d);
                    }
                }

                

            }

            //Notificamos que ha habido cambios en la propiedad ListaPersonas, para que la cargue la vista.
            NotifyPropertyChanged(nameof(ListaPersonasDepartamento));


        }

        #endregion
    }
}
