using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.ViewModels.Utilidades;
using System.Collections.ObjectModel;
using Entidades;
using BL.HandlersBL;
using BL.ListadosBL;
using UI.Models;
using UI.Views;

namespace UI.ViewModels
{
    internal class ListadoPersonasVM : clsVMBase
    {
        #region Atributos
        private DelegateCommand crearCommand;
        private DelegateCommand eliminarCommand;
        private DelegateCommand editarCommand;
        private DelegateCommand buscarCommand;
        private ObservableCollection<clsPersonaConNombreDepartamento> listadoPersonasMostrado = new ObservableCollection<clsPersonaConNombreDepartamento>();
        private clsPersonaConNombreDepartamento personaSeleccionada;
        private string personaBuscada;
        #endregion

        #region Constructores

        public ListadoPersonasVM()
        {

            CargarListaPersonas();
            crearCommand = new DelegateCommand(CrearCommand_Executed);
            buscarCommand = new DelegateCommand(BuscarCommand_Executed);
            eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecute);
            editarCommand = new DelegateCommand(EditarCommand_Executed, EditarCommand_CanExecute);
            personaSeleccionada = null;
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

        public ObservableCollection<clsPersonaConNombreDepartamento> ListadoPersonasMostrado

        {
            get { return listadoPersonasMostrado; }

        }

        public clsPersonaConNombreDepartamento PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set
            {
                personaSeleccionada = value;
                NotifyPropertyChanged();
                EditarCommand.RaiseCanExecuteChanged();
                EliminarCommand.RaiseCanExecuteChanged();
            }
        }

        public string PersonaBuscada
        {
            get { return personaBuscada; }
            set
            {
                personaBuscada = value;
                NotifyPropertyChanged(nameof(personaBuscada));
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
            //Aquí nos lleva a otra vista
            await Shell.Current.Navigation.PushAsync(new CrearPersonaPage());
        }
       

        /// <summary>
        /// Comando que elimina un departamento de la base de datos
        /// Pre: el departamento a eliminar debe existir
        /// Post: ninguna
        /// </summary>
        private async void EliminarCommand_Executed()
        {
            await clsHandlerPersonasBL.borrarPersonasBL(personaSeleccionada.Id);

            //Recargamos la vista
            await Shell.Current.Navigation.PushAsync(new ListadoPersonasPage());
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
            //Aquí nos lleva a otra vista
            await Shell.Current.Navigation.PushAsync(new EditarPersonaPage(personaSeleccionada));
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
            ObservableCollection<clsPersonaConNombreDepartamento> listaPersonasEncontradas = new ObservableCollection<clsPersonaConNombreDepartamento>(listadoPersonasMostrado.Where(persona => persona.Nombre.Contains(personaBuscada)).ToList());

            //Igualamos las listas.
            listadoPersonasMostrado = listaPersonasEncontradas;

            //notificamos el cambio.
            NotifyPropertyChanged(nameof(ListadoPersonasMostrado));


            //TODO: ahora hay que mostrar esa lista de Personas Encontradas
        }

        #endregion

        #region funciones y metodos

        private async void CargarListaPersonas()
        {
            //Nos traemos la lista.
            List<clsPersona> listaPersonas = new List<clsPersona>(await clsListadoPersonasBL.listadoCompletoPersonasBL());

            ObservableCollection<clsPersonaConNombreDepartamento> listaPersonasDepartamento = new ObservableCollection<clsPersonaConNombreDepartamento>();

            foreach (clsPersona p in listaPersonas)
            {
                clsPersonaConNombreDepartamento per = new clsPersonaConNombreDepartamento(p);

                //Obviamos a las personas nulas.
                if (per != null)
                {
                    //Rellenamos el listado de personas con departamento pero que no saben el nombre del departamento.
                    listaPersonasDepartamento.Add(per);
                }
            }

            //Recorremos la segunda lista
            foreach (clsPersonaConNombreDepartamento persona in listaPersonasDepartamento)
            {
                //Ahora, buscamos el departamento de cada persona.
                clsDepartamento departamento = await clsListadoDepartamentosBL.obtenerDepartamentoPorIdBL(persona.IdDepartamento);

                //Asignamos el nombre
                if (departamento == null)
                {
                    persona.NombreDepartamento = "No tiene departamento asignado.";

                }
                else
                {
                    persona.NombreDepartamento = departamento.Nombre;
                }


                //añadimos la persona a la lista.
                listadoPersonasMostrado.Add(persona);
            }

            //Notificamos que ha habido cambios en la propiedad ListaPersonas, para que la cargue la vista.
            NotifyPropertyChanged(nameof(ListadoPersonasMostrado));
        }

        #endregion

    }
}
