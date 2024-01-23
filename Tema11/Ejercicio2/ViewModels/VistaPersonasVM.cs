using BL.HandlersBL;
using BL.ListadosBL;
using Ejercicio3.Models;
using Ejercicio3.ViewModels.Utilidades;
using Ejercicio3.Views;
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
        private ObservableCollection<clsPersona> listadoPersonasMostrado;
        private clsPersona personaSeleccionada;
        private string personaBuscada;
        #endregion

        #region Constructores

        public VistaPersonasVM()
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
            await Shell.Current.GoToAsync("InsertarPersonasPage");
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
            if (!String.IsNullOrEmpty(PersonaBuscada) || !PersonaBuscada.Equals(" "))
            {
                List<clsPersona> listaAuxiliar = new List<clsPersona>(listadoPersonasMostrado);
                ListadoPersonasMostrado.Clear();
                ListadoPersonasMostrado.Add(listaAuxiliar.Find(x => x.Nombre.ToLower().Contains(PersonaBuscada) || x.Apellido.ToLower().Contains(PersonaBuscada)));
            }
            NotifyPropertyChanged(nameof(ListadoPersonasMostrado));
            NotifyPropertyChanged(nameof(PersonaSeleccionada));
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
                    persona.NombreDpto = "No tiene departamento asignado.";

                }
                else
                {
                    persona.NombreDpto = departamento.Nombre;
                }


                //añadimos la persona a la lista.
                listadoPersonasMostrado.Add(persona);
            }

            //Notificamos que ha habido cambios en la propiedad ListaPersonas, para que la cargue la vista.
            NotifyPropertyChanged("ListaPersonasNombreDept");
        }

        #endregion

    }
}
