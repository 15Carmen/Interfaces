using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.ViewModels.Utilidades;
using BL.HandlersBL;
using BL.ListadosBL;
using UI.Models;
using UI.Views;

namespace UI.ViewModels
{
    public class ListadoDepartamentosVM : clsVMBase
    {

        #region Atributos

        private DelegateCommand crearCommand;
        private DelegateCommand eliminarCommand;
        private DelegateCommand editarCommand;
        private DelegateCommand buscarCommand;
        private ObservableCollection<clsDepartamento> listadoDepartamentosMostrado;
        private clsDepartamento departamentoSeleccionado;
        private string departamentoBuscado;

        #endregion

        #region constructores
        public ListadoDepartamentosVM()
        {
            CargarListaDepartamentos();
            crearCommand = new DelegateCommand(CrearCommand_Executed);
            buscarCommand = new DelegateCommand(BuscarCommand_Executed);
            eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecute);
            editarCommand = new DelegateCommand(EditarCommand_Executed, EditarCommand_CanExecute);
            departamentoSeleccionado = null;
        }

        #endregion

        #region propiedades

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

        public ObservableCollection<clsDepartamento> ListadoDepartamentosMostrado
        {
            get { return listadoDepartamentosMostrado; }
        }

        public clsDepartamento DepartamentoSeleccionado
        {
            get { return departamentoSeleccionado; }
            set
            {
                departamentoSeleccionado = value;
                NotifyPropertyChanged();
                EditarCommand.RaiseCanExecuteChanged();
                EliminarCommand.RaiseCanExecuteChanged();
            }
        }

        public string DepartamentoBuscado
        {
            get { return departamentoBuscado; }
            set
            {
                departamentoBuscado = value;
                NotifyPropertyChanged();
                buscarCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        /// <summary>
        /// Comando que manda la vista de crear departamentos
        /// Pre: la vista de crear departamentos debe existar
        /// Post: ninguna
        /// </summary>
        private async void CrearCommand_Executed()
        {
            //Navegamos a la vista para crear el departamento
            await Shell.Current.Navigation.PushAsync(new CrearDepartamentoPage());
        }

        /// <summary>
        /// Comando que elimina un departamento de la base de datos
        /// Pre: el departamento a eliminar debe existir
        /// Post: ninguna
        /// </summary>
        private async void EliminarCommand_Executed()
        {
            await clsHandlerDepartamentosBL.borrarDepartamentoBL(departamentoSeleccionado.Id);

            //Volvemos a la página de la lista de departamentos
            await Shell.Current.Navigation.PushAsync(new ListadoDepartamentosPage());
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
        /// Comando que navega a la vista para editar el departamento
        /// Pre: la vista debe de estar creada
        /// Post: ninguna
        /// </summary>
        private async void EditarCommand_Executed()
        {
            //Navegamos a la vista para editar a la persona selecciona
            await Shell.Current.Navigation.PushAsync(new EditarDepartamentoPage(departamentoSeleccionado));
        }

        // <summary>
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
        /// Pre: la lista no debe estar vacía
        /// Post: ninguna
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void BuscarCommand_Executed()
        {
            ObservableCollection<clsDepartamento> listaDepartamentosEncontrados=
                new ObservableCollection<clsDepartamento>(listadoDepartamentosMostrado.Where
                (departamento => departamento.Nombre.Contains(departamentoBuscado)).ToList());

            listadoDepartamentosMostrado = listaDepartamentosEncontrados;

            //notificamos del cambio
            NotifyPropertyChanged(nameof(ListadoDepartamentosMostrado));

        }

        #region comandos

        #endregion

        #region funciones y metodos

        private async void CargarListaDepartamentos()
        {
            //Guardamos los departamentos de la api en la variable
            listadoDepartamentosMostrado = new ObservableCollection<clsDepartamento>(await clsListadoDepartamentosBL.listadoCompletoDepartamentosBL());

            //Notificamos que ha habido cambios en la propiedad ListaPersonas, para que la cargue la vista.
            NotifyPropertyChanged(nameof(ListadoDepartamentosMostrado));
        }

        #endregion





    }
}
