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
        private ObservableCollection<clsPersonaConNombreDepartamento> listadoPersonasMostrado;
        private clsPersonaConNombreDepartamento personaSeleccionada;
        private string personaBuscada;
        #endregion

        #region Constructores

        public ListadoPersonasVM()
        {
            listadoPersonasMostrado = new ObservableCollection<clsPersonaConNombreDepartamento>();
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
        /// Comando que manda la vista de crear personas
        /// Pre: la vista de crear personas debe existir
        /// Post: ninguna
        /// </summary>
        private async void CrearCommand_Executed()
        {
            //Navegamos a la vista para crear la persona
            await Shell.Current.Navigation.PushAsync(new CrearPersonaPage());
        }
       

        /// <summary>
        /// Comando que elimina una persona de la base de datos
        /// Pre: la persona a eliminar debe existir
        /// Post: ninguna
        /// </summary>
        private async void EliminarCommand_Executed()
        {
            await clsHandlerPersonasBL.borrarPersonasBL(personaSeleccionada.Id);

            //Volvemos a la página de la lista de personas
            await Shell.Current.Navigation.PushAsync(new ListadoPersonasPage());
        }


        /// <summary>
        /// Comando que devuelve true si se ha elegido eliminar una persona y false si no
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
        /// Comando que navega a la vista para editar la persona
        /// Pre: la vista debe de estar creada
        /// Post: ninguna
        /// </summary>
        private async void EditarCommand_Executed()
        {
            //Navegamos a la vista para editar a la persona selecciona
            await Shell.Current.Navigation.PushAsync(new EditarPersonaPage(personaSeleccionada));
        }


        /// <summary>
        /// Comando que devuelve true si se ha elegido editar una persona y false si no
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
        /// Comando que busca una persona en la lista
        /// Pre: la lista no debe estar vacía
        /// Post: ninguna
        /// </summary>
        private void BuscarCommand_Executed()
        {
            ObservableCollection<clsPersonaConNombreDepartamento> listaPersonasEncontradas = 
                new ObservableCollection<clsPersonaConNombreDepartamento>(listadoPersonasMostrado.Where(persona => persona.Nombre.Contains(personaBuscada)).ToList());

            listadoPersonasMostrado = listaPersonasEncontradas;

            //notificamos el cambio.
            NotifyPropertyChanged(nameof(ListadoPersonasMostrado));


        }

        #endregion

        #region funciones y metodos

        private async void CargarListaPersonas()
        {
            //Guardamos en una lista auxiliar de personas a las personas que sacamos de la api
            List<clsPersona> listaAuxiliarPersonasSinNombreDept = new List<clsPersona>(await clsListadoPersonasBL.listadoCompletoPersonasBL());

            ObservableCollection<clsPersonaConNombreDepartamento> listaAuxiliarPersonasConNombreDept = new ObservableCollection<clsPersonaConNombreDepartamento>();

            //Declaramos los objetos que necesitaremos en el método
            clsPersonaConNombreDepartamento personaNombreDept;
            clsDepartamento departamento;

            //Recorremos cada persona de la lista auxiliar
            foreach (clsPersona personaSinNombreDept in listaAuxiliarPersonasSinNombreDept)
            {
                //Guardamos en una nueva persona con nombre departamento una persona sin nombre departamento. El departamento en esta persona será un string vacío ("")
                personaNombreDept = new clsPersonaConNombreDepartamento(personaSinNombreDept);

                //Si la persona no es nula
                if (personaNombreDept != null)
                {
                    //Rellenamos el listado de personas con departamento pero que no saben el nombre del departamento.
                    listaAuxiliarPersonasConNombreDept.Add(personaNombreDept);
                }
            }

            //Recorremos la lista auxiliar de personas con nombre departamento con string vacío
            foreach (clsPersonaConNombreDepartamento personaConNombreDepartamento in listaAuxiliarPersonasConNombreDept)
            {
                //Guardamos en el objeto departamento el departamento que le corresponde a la persona
                departamento = await clsListadoDepartamentosBL.obtenerDepartamentoPorIdBL(personaConNombreDepartamento.IdDepartamento);

                //Asignamos el nombre
                if (departamento == null)
                {
                    personaConNombreDepartamento.NombreDepartamento = "No tiene departamento asignado.";
                }
                else
                {
                    personaConNombreDepartamento.NombreDepartamento = departamento.Nombre;
                }


                //añadimos la persona a la lista que sde mostrará por pantalla
                listadoPersonasMostrado.Add(personaConNombreDepartamento);
            }

            //Notificamos que ha habido cambios en la propiedad ListaPersonas
            NotifyPropertyChanged(nameof(ListadoPersonasMostrado));
        }

        #endregion

    }
}
