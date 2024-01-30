using BL.Listados;
using BL.Manejadoras;
using Maui.ViewModels.Utilidades;
using Entities;
using System.Collections.ObjectModel;
namespace Maui.ViewModels
{
    /// <summary>
    /// ViewModel para mostrar en la vista de la lista de departamentos.
    /// </summary>
    public class VistaDepartamentosVM : clsVMBase
    {
        #region Atributos
        private DelegateCommand crearCommand;
        private DelegateCommand eliminarCommand;
        private DelegateCommand editarCommand;
        private DelegateCommand buscarCommand;
        private ObservableCollection<clsDepartamentos> listadoDeDepartamentosCompleto;
        private ObservableCollection<clsDepartamentos> listadoDeDepartamentosMostrado;
        private clsDepartamentos departamentoSeleccionado;
        private string cadena;
        #endregion

        #region Constructores
        private VistaDepartamentosVM(ObservableCollection<clsDepartamentos> lista)
        {
            listadoDeDepartamentosCompleto = lista;
            crearCommand = new DelegateCommand(CrearCommand_Executed);
            buscarCommand = new DelegateCommand(BuscarCommand_Executed);
            eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecute);
            editarCommand = new DelegateCommand(EditarCommand_Executed, EditarCommand_CanExecute);
            listadoDeDepartamentosMostrado = new ObservableCollection<clsDepartamentos>(listadoDeDepartamentosCompleto);
            departamentoSeleccionado = null;
            cadena = null;
        }
        /// <summary>
        /// Precondiciones: No tiene.
        /// Constructor asíncrono que recibe la lista, y la manda al constructor privado.
        /// Postcondiciones: Se construye la página.
        /// </summary>
        /// <returns>Devuelve la lista de la api una vez recibida.</returns>
        public static async Task<VistaDepartamentosVM> BuildViewModelAsync()
        {
            ObservableCollection<clsDepartamentos> listaAsincrona = new ObservableCollection<clsDepartamentos>(await clsListadoDepartamentosBL.getListadoDepartamentosBL());
            return new VistaDepartamentosVM(listaAsincrona);
        }
        #endregion

        #region Propiedades
        public string Cadena
        {
            get
            { return cadena; }
            set
            {
                cadena = value;
                NotifyPropertyChanged();
                buscarCommand.RaiseCanExecuteChanged();
            }
        }
        public clsDepartamentos DepartamentoSeleccionado
        {
            get
            {
                return departamentoSeleccionado;
            }
            set
            {
                departamentoSeleccionado = value;
                NotifyPropertyChanged();
                editarCommand.RaiseCanExecuteChanged();
                eliminarCommand.RaiseCanExecuteChanged();
            }
        }
        public ObservableCollection<clsDepartamentos> ListadoDeDepartamentosMostrado
        {
            get
            {
                return listadoDeDepartamentosMostrado;
            }
            set
            {
                listadoDeDepartamentosMostrado = value;
            }
        }
        public DelegateCommand CrearCommand { get { return crearCommand; } }
        public DelegateCommand BuscarCommand { get { return buscarCommand; } }
        public DelegateCommand EliminarCommand { get { return eliminarCommand; } }
        public DelegateCommand EditarCommand { get { return editarCommand; } }
        #endregion

        #region Commands
        /// <summary>
        /// Precondiciones: No tiene.
        /// Command que me manda a la vista de crear departamentos.
        /// Postcondiciones: Navegas a la vista de crear departamentos.
        /// </summary>
        private async void CrearCommand_Executed()
        {
            await Shell.Current.GoToAsync("CrearDepartamento");
        }
        /// <summary>
        /// Precondiciones: No tiene.
        /// Command que busca un departamento en la lista.
        /// Postcondiciones: Muestra las coincidencias.
        /// </summary>
        private void BuscarCommand_Executed()
        {
            BuscarDepartamentos();
            NotifyPropertyChanged();
            buscarCommand.RaiseCanExecuteChanged();
        }
        //No lo voy a usar
        //private bool BuscarCommand_CanExecute()
        //{
        //    bool btnBuscador = true;
        //    if (String.IsNullOrEmpty(busqueda))
        //    {
        //        btnBuscador = false;
        //    }
        //    return btnBuscador;
        //}
        /// <summary>
        /// Precondiciones: No tiene.
        /// Comando para eliminar un departamento de la BBDD.
        /// Postcondiciones: Elimina un departamento de la BBDD.
        /// </summary>
        private async void EliminarCommand_Executed()
        {
            bool eliminar = await Application.Current.MainPage.DisplayAlert("Eliminar", "¿Seguro que desea eliminar el departamento de la BBDD?", "Si", "No");
            if (eliminar == true)
            {
                listadoDeDepartamentosCompleto.Remove(DepartamentoSeleccionado);
                listadoDeDepartamentosMostrado.Remove(DepartamentoSeleccionado);
                try
                {
                    await clsManejadoraDepartamentos.borrarDepartamentosBL(DepartamentoSeleccionado.id);
                    DepartamentoSeleccionado = null;
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
        /// Precondiciones: No tiene.
        /// Comando que devuelve true si hay un departamento seleccionado y false si no lo hay.
        /// Postcondiciones: Devuelve un booleano según hay un departamento seleccionado o no.
        /// </summary>
        /// <returns>bool</returns>
        private bool EliminarCommand_CanExecute()
        {
            bool btnEliminar = true;
            if (DepartamentoSeleccionado == null)
            {
                btnEliminar = false;
            }
            return btnEliminar;
        }
        /// <summary>
        /// Precondiciones: No tiene.
        /// Comando para editar un departamento de la BBDD.
        /// Postcondiciones: Edita un departamento de la BBDD.
        /// </summary>
        private async void EditarCommand_Executed()
        {
            var miDiccionario = new Dictionary<string, object>
            {
                {"departamentoParaMandar", DepartamentoSeleccionado }
            };
            await Shell.Current.GoToAsync("EditarDepartamento", miDiccionario);
        }
        /// <summary>
        /// Precondiciones: No tiene.
        /// Comando que devuelve true si hay un departamento seleccionado y false si no lo hay.
        /// Postcondiciones: Devuelve un booleano según haya un departamento seleccionado o no.
        /// </summary>
        /// <returns>bool</returns>
        private bool EditarCommand_CanExecute()
        {
            bool btnEditar = true;
            if (DepartamentoSeleccionado == null)
            {
                btnEditar = false;
            }
            return btnEditar;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Precondiciones: No tiene.
        /// Método que busca las coincidencias de la busqueda en la lista de departamentos.
        /// Postcondiciones: Devuelve una ObservableCollection con las coincidencias.
        /// </summary>
        /// <returns>ObservableCollection</returns>
        private ObservableCollection<clsDepartamentos> BuscarDepartamentos()
        {
            List<clsDepartamentos> listaAuxiliar = new List<clsDepartamentos>(listadoDeDepartamentosCompleto);
            ListadoDeDepartamentosMostrado.Clear();
            ListadoDeDepartamentosMostrado.Add(listaAuxiliar.Find(x => x.nombre.Contains(Cadena)));
            return ListadoDeDepartamentosMostrado;
        }
        #endregion
    }
}
