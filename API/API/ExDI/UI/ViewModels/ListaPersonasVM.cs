using Entidades;
using UI.Models;
using System.Collections.ObjectModel;
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
        private clsDepartamento departamentoSeleccionado;


        #endregion

        #region constructores

        public ListaPersonasVM() 
        {
            listaPersonasDepartamento = new ObservableCollection<clsPersonaListaDepartamentos>();
            CargarListadoPersonas();
            numAciertos = 0;
            numIntentos = 3;
            comprobarCommand = new DelegateCommand(ComprobarCommand_Execute, ComprobarCommand_CanExecute);
            this.departamentoSeleccionado = null;

        }

        #endregion

        #region propiedades

        public int NumAciertos
        {
            get { return numAciertos; }
        }

        public int NumIntentos
        {
            get { return numIntentos; }
        }

        public ObservableCollection<clsPersonaListaDepartamentos> ListaPersonasDepartamento
        {
            get { return listaPersonasDepartamento; }
        }

        public DelegateCommand ComprobarCommand { 
            get { return comprobarCommand; }
        }

        public clsDepartamento DepartamentoSeleccionado
        {
            get { return departamentoSeleccionado; }
            set
            {
                departamentoSeleccionado = value;
                NotifyPropertyChanged(nameof(DepartamentoSeleccionado));
                comprobarCommand.RaiseCanExecuteChanged();
            }
        }


        #endregion

        #region commands

        private async void ComprobarCommand_Execute()
        {
            
            foreach(clsPersonaListaDepartamentos persona in ListaPersonasDepartamento)
            {
                if (persona.IdDepartamento.Equals(DepartamentoSeleccionado.Id))
                {
                    numAciertos++;                   
                }

                if(numAciertos == 8)
                {
                    //Todo: displayAlert diciendo que ha acertado todo
                }
                else
                {
                    numIntentos--;

                    if(numIntentos == 0)
                    {
                        //Todo: DisplayAlert diciendo que ha perdido todas las oportunidades y pidiendo que si quiere 
                        // reiniciar el juego
                    }
                }

            }

            NotifyPropertyChanged(nameof(NumAciertos));
            NotifyPropertyChanged(nameof(NumIntentos));
            ComprobarCommand.RaiseCanExecuteChanged();
        }

        private bool ComprobarCommand_CanExecute()
        {
            bool puedeComprobar = false;

            if (listaPersonasDepartamento !=  null)
            {
                puedeComprobar = true;
            }

            return puedeComprobar;
        }


        #endregion

        #region funciones y métodos

        /// <summary>
        /// Función que cargará el listado completo de las personas en la vista
        /// </summary>
        private async void CargarListadoPersonas()
        {

            //Guardamos las personas de la api en la variable
            List<clsPersona> listaAuxiliar = new List<clsPersona>
                (await clsHandlerPersonasBL.getListadoCompletoPersonasBL());

            clsPersonaListaDepartamentos personaConLista;

            foreach(clsPersona personaSinLista in listaAuxiliar)
            {
                personaConLista = new clsPersonaListaDepartamentos(personaSinLista);

                //Si la persona no es nula
                if (personaConLista != null)
                {
                    //Le añadimos la lista de departamentos a cada persona
                    personaConLista.ListaDepartamentos = new ObservableCollection<clsDepartamento>
                        (await clsHandlerDepartamentosBL.getListadoCompletoDepartamentosBL());

                    //Rellenamos el listado de personas con 
                    listaPersonasDepartamento.Add(personaConLista);
   
                }
            }

            //Notificamos que ha habido cambios en la propiedad ListaPersonas, para que la cargue la vista.
            NotifyPropertyChanged(nameof(ListaPersonasDepartamento));

        }

        #endregion
    }
}
