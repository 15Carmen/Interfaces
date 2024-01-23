using Ejercicio3.ViewModels.Utilidades;
using Entidades;
using BL.HandlersBL;
using System.Collections.ObjectModel;
using BL.ListadosBL;

namespace Ejercicio3.ViewModels
{
    public class VistaDepartamentosVM : clsVMBase
    {

        #region Atributos
        private DelegateCommand crearCommand;
        private DelegateCommand eliminarCommand;
        private DelegateCommand editarCommand;
        private DelegateCommand buscarCommand;
        private ObservableCollection<clsPersona> listadoDeDepartamentosCompleto;
        private ObservableCollection<clsPersona> listadoDeDepartamentosMostrado;
        private clsPersona departamentoSeleccionado;
        private string cadena;
        #endregion


        #region Constructores

        public VistaDepartamentosVM(ObservableCollection<clsPersona> listaDepartamentos)
        {
            listadoDeDepartamentosCompleto = listaDepartamentos;
            //crearCommand = new DelegateCommand(CearCommand_Executed);
        }

       

        #endregion

        #region Propiedades

        public DelegateCommand CrearCommand { 
            get { return crearCommand; } 
        }

        public DelegateCommand EliminarCommand {
            get { return eliminarCommand; }
        }

        public DelegateCommand EditarCommand {
            get { return editarCommand; }
        }

        public DelegateCommand BuscarCommand {
            get { return buscarCommand; } 
        }

        public ObservableCollection<clsPersona> ListadoDeDepartamentosMostrado
        {
            get { return listadoDeDepartamentosMostrado; }
            set { listadoDeDepartamentosMostrado = value; }
        }

        public clsPersona DepartamentoSeleccionado
        {
            get { return departamentoSeleccionado; }
            set
            {
                departamentoSeleccionado = value;
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
                NotifyPropertyChanged();
                buscarCommand.RaiseCanExecuteChanged();
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
            await Shell.Current.GoToAsync("InsertarDepartamentosPage");
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
                listadoDeDepartamentosCompleto.Remove(DepartamentoSeleccionado);
                listadoDeDepartamentosMostrado.Remove(DepartamentoSeleccionado);
                try
                {
                    await clsHandlerDepartamentosBL.borrarDepartamentoBL(DepartamentoSeleccionado.Id);
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
        /// Comando que devuelve true si se ha elegido eliminar un departamento y false si no
        /// Pre: ninguna
        /// Post: ninguna
        /// </summary>
        /// <returns>booleano</returns>
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
        /// Comando que la vista para editar el departamento
        /// Pre: la vista debe de estar creada
        /// Post: ninguna
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
        /// Comando que devuelve true si se ha elegido editar un departamento y false si no
        /// Pre: ninguna
        /// Post: ninguna
        /// </summary>
        /// <returns>booleano</returns>
        private bool EditarCommand_CanExecute()
        {
            bool btnEditar = true;
            if (DepartamentoSeleccionado == null)
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
            BuscarDepartamentos();
            NotifyPropertyChanged();
            buscarCommand.RaiseCanExecuteChanged();
        }

        #endregion

        #region Funciones y Metodos

        /// <summary>
        /// Método que busca el departamento en la lista completa de departamentos
        /// Pre: ninguna
        /// Post: ninguna
        /// </summary>
        /// <returns>una lista con los departamentos que encuentra</returns>
        private ObservableCollection<clsPersona> BuscarDepartamentos()
        {
            List<clsPersona> listaAuxiliar = new List<clsPersona>(listadoDeDepartamentosCompleto);
            ListadoDeDepartamentosMostrado.Clear();
            ListadoDeDepartamentosMostrado.Add(listaAuxiliar.Find(x => x.Nombre.Contains(Cadena)));
            return ListadoDeDepartamentosMostrado;
        }

        #endregion

    }
}
