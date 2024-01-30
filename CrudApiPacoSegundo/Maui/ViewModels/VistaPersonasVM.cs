using BL.Listados;
using BL.Manejadoras;
using Maui.ViewModels.Utilidades;
using Entities;
using System.Collections.ObjectModel;
using Maui.Views;

namespace Maui.ViewModels
{
    /// <summary>
    /// ViewModel para mostrar en la vista de la lista de personas con sus nombres de departamentos.
    /// </summary>
    public class VistaPersonasVM : clsVMBase //IQueryAttributable
    {
        #region Atributos
        private DelegateCommand crearCommand;
        private DelegateCommand eliminarCommand;
        private DelegateCommand editarCommand;
        private DelegateCommand buscarCommand;
        private DelegateCommand detallesCommand;
        private ObservableCollection<clsPersona> listadoDePersonasCompleto;
        private ObservableCollection<clsPersona> listadoDePersonasMostrado;
        private clsPersona personaSeleccionada;
        private String busqueda;
        #endregion

        #region Constructores
        private VistaPersonasVM(ObservableCollection<clsPersona> lista)
        {
            listadoDePersonasCompleto = lista;
            crearCommand = new DelegateCommand(CrearCommand_Executed);
            buscarCommand = new DelegateCommand(BuscarCommand_Executed);
            eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecute);
            editarCommand = new DelegateCommand(EditarCommand_ExecutedAsync, EditarCommand_CanExecute);
            detallesCommand = new DelegateCommand(DetallesCommand_Execute, DetallesCommand_CanExecute);
            listadoDePersonasMostrado = new ObservableCollection<clsPersona>(listadoDePersonasCompleto);
            personaSeleccionada = null;
            busqueda = null;
            //LoadData();
        }
        /// <summary>
        /// Precondiciones: No tiene.
        /// Constructor asíncrono que recibe la lista, y la manda al constructor privado.
        /// Postcondiciones: Se construye la página.
        /// </summary>
        /// <returns>Devuelve la lista de la api una vez recibida.</returns>
        public static async Task<VistaPersonasVM> BuildViewModelAsync()
        {
            ObservableCollection<clsPersona> listaAsincrona = new ObservableCollection<clsPersona>(await clsListadoPersonasBL.getListadoPersonasBL());
            return new VistaPersonasVM(listaAsincrona);
        }
        //Esta es la forma fácil de hacer el constructor asíncrono, pero la no recomendada.
        //private async void LoadData()
        //{
        //    listadoDePersonasCompleto = new ObservableCollection<clsPersona>(await clsListadoPersonasBL.getListadoPersonasBL());
        //    NotifyPropertyChanged(nameof(listadoDePersonasCompleto));
        //}
        #endregion

        #region Propiedades
        public String Busqueda
        {
            get
            { return busqueda; }
            set
            {
                busqueda = value;
                NotifyPropertyChanged(nameof(busqueda));

                //buscarCommand.RaiseCanExecuteChanged();
                BuscarPersonas();
            }
        }
        public clsPersona PersonaSeleccionada
        {
            get
            {
                return personaSeleccionada;
            }
            set
            {
                personaSeleccionada = value;
                NotifyPropertyChanged();
                editarCommand.RaiseCanExecuteChanged();
                eliminarCommand.RaiseCanExecuteChanged();
            }
        }
        public ObservableCollection<clsPersona> ListadoDePersonasMostrado
        {
            get
            {
                return listadoDePersonasMostrado;
            }
            set
            {
                listadoDePersonasMostrado = value;
            }
        }
        public DelegateCommand CrearCommand { get { return crearCommand; } }
        public DelegateCommand BuscarCommand { get { return buscarCommand; } }
        public DelegateCommand EliminarCommand { get { return eliminarCommand; } }
        public DelegateCommand EditarCommand { get { return editarCommand; } }
        public DelegateCommand DetallesCommand { get { return detallesCommand; } }
        #endregion

        #region Commands
        /// <summary>
        /// Precondiciones: No tiene.
        /// Command que me manda a la vista de crear personas.
        /// Postcondiciones: Navegas a la vista de crear personas.
        /// </summary>
        private async void CrearCommand_Executed()
        {
            await Shell.Current.Navigation.PushAsync(new CrearPersonaPage());
        }
        /// <summary>
        /// Precondiciones: No tiene.
        /// Command que busca una persona en la lista.
        /// Postcondiciones: Muestra las coincidencias.
        /// </summary>
        private void BuscarCommand_Executed()
        {
            BuscarPersonas();
            NotifyPropertyChanged(nameof(ListadoDePersonasMostrado));
            NotifyPropertyChanged(nameof(PersonaSeleccionada));
        }
        /// <summary>
        /// Precondiciones: No tiene.
        /// Comando para editar una persona de la BBDD.
        /// Postcondiciones: Edita una persona de la BBDD.
        /// </summary>
        private async void EliminarCommand_Executed()
        {
            bool eliminar = await Application.Current.MainPage.DisplayAlert("Eliminar", "¿Seguro que desea eliminar a la persona?", "Si", "No");
            if (eliminar == true)
            {
                listadoDePersonasCompleto.Remove(PersonaSeleccionada);
                ListadoDePersonasMostrado.Remove(PersonaSeleccionada);
                try
                {
                    await clsManejadoraPersonas.borrarPersonaBL(PersonaSeleccionada.id);
                    PersonaSeleccionada = null;
                    EliminarCommand.RaiseCanExecuteChanged();
                    EditarCommand.RaiseCanExecuteChanged();
                    NotifyPropertyChanged(nameof(ListadoDePersonasMostrado));
                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("Alerta", "Error eliminanado la persona de la BBDD", "OK");
                }
            }
        }
        /// <summary>
        /// Precondiciones: No tiene.
        /// Comando que devuelve true si hay una persona seleccionada y false si no la hay.
        /// Postcondiciones: Devuelve un booleano según haya una persona seleccionada o no.
        /// </summary>
        /// <returns>bool</returns>
        private bool EliminarCommand_CanExecute()
        {
            bool btnEliminar = false;
            if (PersonaSeleccionada != null)
            {
                btnEliminar = true;
            }
            return btnEliminar;
        }
        /// <summary>
        /// Precondiciones: No tiene.
        /// Comando para editar una persona de la BBDD.
        /// Postcondiciones: Edita una persona de la BBDD.
        /// </summary>
        private async void EditarCommand_ExecutedAsync()
        {
            var miDiccionario = new Dictionary<string, object>
            {
                {"personaParaMandar", PersonaSeleccionada }
            };
            await Shell.Current.GoToAsync(nameof(EditarPersonasPage), miDiccionario);
        }
        /// <summary>
        /// Precondiciones: No tiene.
        /// Comando que devuelve true si hay una persona seleccionada y false si no la hay.
        /// Postcondiciones: Devuelve un booleano según haya una persona seleccionada o no.
        /// </summary>
        /// <returns>bool</returns>
        private bool EditarCommand_CanExecute()
        {
            bool btnEditar = false;
            if (PersonaSeleccionada != null)
            {
                btnEditar = true;
            }
            return btnEditar;
        }
        /// <summary>
        /// Precondiciones: No tiene.
        /// Comando para ir a la vista de detalles de la persona.
        /// Postcondiciones: No tiene.
        /// </summary>
        private async void DetallesCommand_Execute()
        {
            var miDiccionario = new Dictionary<string, object>
            {
                {"personaParaMandar", PersonaSeleccionada }
            };
            await Shell.Current.GoToAsync(nameof(DetallesPersonaPage), miDiccionario);
        }
        /// <summary>
        /// Precondiciones: No tiene.
        /// Comando que devuelve true si hay una persona seleccionada y false si no la hay.
        /// Postcondiciones: Devuelve un booleano según haya una persona seleccionada o no.
        /// </summary>
        /// <returns>bool</returns>
        private bool DetallesCommand_CanExecute()
        {
            bool btnEditar = false;
            if (PersonaSeleccionada != null)
            {
                btnEditar = true;
            }
            return btnEditar;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Precondiciones: No tiene.
        /// Método para buscar dentro de la lista una persona o varias personas en concreto mediante una busqueda que buscará dentro de la lista.
        /// Postcondiciones: Devuelve una ObservableCollection con las coincidencias.
        /// </summary>
        /// <returns>ObservableCollection</returns>
        public async void BuscarPersonas()
        {
            //Compruebo primero si está vació.
            if (String.IsNullOrEmpty(Busqueda) || Busqueda.Equals(" "))
            {
                ListadoDePersonasMostrado = listadoDePersonasCompleto;
            }
            else
            {
                List<clsPersona> listaAuxiliar = new List<clsPersona>(listadoDePersonasCompleto);
                ListadoDePersonasMostrado.Clear();
                ListadoDePersonasMostrado.Add(listaAuxiliar.Find(x => x.nombre.ToLower().Contains(Busqueda) || x.apellidos.ToLower().Contains(Busqueda)));
            }

        }
        //private void actualizarLista()
        //{
        //    try
        //    {
        //        ListadoDePersonasMostrado = new ObservableCollection<clsPersona> (clsListadoPersonasBL.getListadoPersonasBL());
        //    }catch(SqlException)
        //    {
        //        var toast = Toast.Make("La BBDD no esta disponible.", ToastDuration.Long).Show();
        //    }
        //    NotifyPropertyChanged("ListadoDePersonasMostrado");
        //}
        #endregion
    }
}
