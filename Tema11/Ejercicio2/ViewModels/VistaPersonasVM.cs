using BL.HandlersBL;
using BL.ListadosBL;
using Ejercicio3.ViewModels.Utilidades;
using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3.ViewModels
{
    public class VistaPersonasVM : clsVMBase
    {
        #region Atributos
        private DelegateCommand crearCommand;
        private DelegateCommand eliminarCommand;
        private DelegateCommand editarCommand;
        private DelegateCommand buscarCommand;
        private DelegateCommand detallesCommand;
        private ObservableCollection<clsPersona> listadoPersonasCompleto;
        private ObservableCollection<clsPersona> listadoPersonasMostrado;
        private clsPersona personaSeleccionada;
        private string cadena;
        #endregion


        #region Constructores

        public VistaPersonasVM(ObservableCollection<clsPersona> listaPersonas)
        {
            listadoPersonasCompleto = listaPersonas;
            crearCommand = new DelegateCommand(CrearCommand_Executed);
            buscarCommand = new DelegateCommand(BuscarCommand_Executed);
            eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecute);
            editarCommand = new DelegateCommand(EditarCommand_ExecutedAsync, EditarCommand_CanExecute);
            detallesCommand = new DelegateCommand(DetallesCommand_Execute, DetallesCommand_CanExecute);
            listadoDePersonasMostrado = new ObservableCollection<clsPersona>(listadoDePersonasCompleto);
            personaSeleccionada = null;
        }

        public static async Task<VistaPersonasVM> BuildViewModelAsync()
        {
            ObservableCollection<clsPersona> listaAsincrona = new ObservableCollection<clsPersona>(await clsListadoPersonasBL.listadoCompletoPersonasBL());
            return new VistaPersonasVM(listaAsincrona);
        }

        #endregion

        #region Propiedades

        public DelegateCommand CrearCommand
        {
            get { return crearCommand; }
        }

        public DelegateCommand EliminarCommand
        {
            get { return eliminarCommand; }
        }

        public DelegateCommand EditarCommand
        {
            get { return editarCommand; }
        }

        public DelegateCommand BuscarCommand
        {
            get { return buscarCommand; }
        }

        public DelegateCommand DetallesCommand { 
            get { return detallesCommand; } 
        }

        public ObservableCollection<clsPersona> ListadoPersonasMostrado
        {
            get { return listadoPersonasMostrado; }
            set { listadoPersonasMostrado = value; }
        }

        public clsPersona PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set
            {
                personaSeleccionada = value;
                NotifyPropertyChanged();
                editarCommand.RaiseCanExecuteChanged();
                eliminarCommand.RaiseCanExecuteChanged();
            }
        }

        public string Cadena
        {
            get { return cadena; }
            set
            {
                cadena = value;
                NotifyPropertyChanged(nameof(cadena));

                //buscarCommand.RaiseCanExecuteChanged();
                BuscarPersonas();
            }
        }

        #endregion

        #region Comandos

        /// <summary>
        /// Comando que manda la vista de crear departamentos
        /// Pre: la vista de crear departamentos debe existir
        /// Post: ninguna
        /// </summary>
        private async void CrearCommand_Executed()
        {
            await Shell.Current.GoToAsync("InsertarPersonasPage");
        }

        /// <summary>
        /// Comando que elimina un departamento de la base de datos
        /// Pre: el departamento a eliminar debe existir
        /// Post: ninguna
        /// </summary>
        private async void EliminarCommand_Executed()
        {
            bool eliminar = await Application.Current.MainPage.DisplayAlert("Eliminar", "¿Seguro que desea eliminar el departamento de la BBDD?", "Si", "No");
            if (eliminar == true)
            {
                listadoPersonasCompleto.Remove(PersonaSeleccionada);
                listadoPersonasMostrado.Remove(PersonaSeleccionada);
                try
                {
                    await clsHandlerDepartamentosBL.borrarDepartamentoBL(PersonaSeleccionada.Id);
                    PersonaSeleccionada = null;
                    EliminarCommand.RaiseCanExecuteChanged();
                    EditarCommand.RaiseCanExecuteChanged();
                    NotifyPropertyChanged("ListadoDeDepartamentosMostrado");
                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("Alerta", "Error eliminanado el departamento de la BBDD", "OK");
                }
            }
        }


        /// <summary>
        /// Comando que devuelve true si se ha elegido eliminar un departamento y false si no
        /// Pre: ninguna
        /// Post: ninguna
        /// </summary>
        /// <returns>booleano</returns>
        private bool EliminarCommand_CanExecute()
        {
            bool btnEliminar = true;
            if (PersonaSeleccionada == null)
            {
                btnEliminar = false;
            }
            return btnEliminar;
        }

        /// <summary>
        /// Comando que la vista para editar el departamento
        /// Pre: la vista debe de estar creada
        /// Post: ninguna
        /// </summary>
        private async void EditarCommand_Executed()
        {
            var miDiccionario = new Dictionary<string, object>
            {
                {"departamentoParaMandar", PersonaSeleccionada }
            };
            await Shell.Current.GoToAsync("EditarDepartamento", miDiccionario);
        }


        /// <summary>
        /// Comando que devuelve true si se ha elegido editar un departamento y false si no
        /// Pre: ninguna
        /// Post: ninguna
        /// </summary>
        /// <returns>booleano</returns>
        private bool EditarCommand_CanExecute()
        {
            bool btnEditar = true;
            if (PersonaSeleccionada == null)
            {
                btnEditar = false;
            }
            return btnEditar;
        }

        /// <summary>
        /// Comando que busca un departamento en la lista
        /// Pre: la lista nodebe estar vacía
        /// Post: ninguna
        /// </summary>
        private void BuscarCommand_Executed()
        {
            BuscarPersonas();
            NotifyPropertyChanged(nameof(ListadoPersonasMostrado));
            NotifyPropertyChanged(nameof(PersonaSeleccionada));
        }

        #endregion

        #region Funciones y Metodos

        /// <summary>
        /// Método que busca el departamento en la lista completa de departamentos
        /// Pre: ninguna
        /// Post: ninguna
        /// </summary>
        /// <returns>una lista con los departamentos que encuentra</returns>
        private async void BuscarPersonas()
        {
            //Compruebo primero si está vació.
            if (String.IsNullOrEmpty(Cadena) || Cadena.Equals(" "))
            {
                ListadoPersonasMostrado = listadoPersonasCompleto;
            }
            else
            {
                List<clsPersona> listaAuxiliar = new List<clsPersona>(listadoPersonasCompleto);
                ListadoPersonasMostrado.Clear();
                ListadoPersonasMostrado.Add(listaAuxiliar.Find(x => x.Nombre.ToLower().Contains(Cadena) || x.Apellido.ToLower().Contains(Cadena)));
            }
        }

        #endregion
    }
}
