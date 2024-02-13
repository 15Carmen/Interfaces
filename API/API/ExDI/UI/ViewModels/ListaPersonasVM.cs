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



        #endregion

        #region constructores

        public ListaPersonasVM() 
        {
            CargarListadoPersonas();
            numAciertos = 0;
            numIntentos = 3;
            comprobarCommand = new DelegateCommand(ComprobarCommand_Execute, ComprobarCommand_CanExecute);
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

        #endregion

        #region commands

        private async void ComprobarCommand_Execute()
        {
            bool repite;
            numAciertos = 0;

            //Recorremos la lista de personas
            foreach (clsPersonaListaDepartamentos persona in ListaPersonasDepartamento)
            {               
                //Si el id del departamento seleccionado es igual que el idDepartamento de la persona
                if (persona.DepartamentoSeleccionado.Id == persona.IdDepartamento)
                {
                    //Incrementamos en 1 los aciertos 
                    numAciertos++;                   
                }
            }

            //Si el usuario acierta todo
            if (numAciertos == 8)
            {
                //Mostramos un displayAlert indicando que ha ganado
                repite = await App.Current.MainPage.DisplayAlert("¡Has ganado!", "¿Quieres volver a jugar?", "Sí", "No");

                //Si quiere volver a jugar reiniciamos el juego
                if (repite)
                {
                    ReiniciarPartida();
                }
                else //Si no, se cierra la app
                {
                    App.Current.Quit();
                }

            }
            else //Si el usuario no acierta todo
            {
                //Se le resta un intento
                numIntentos--;

                //Cuando se le acaben los intentos
                if (numIntentos == 0)
                {
                    //Mostramos un displayAlert indicando que ha perdido
                    repite = await App.Current.MainPage.DisplayAlert("¡Has perdido!", "¿Quieres repetir el juego?", "Sí", "No");

                    //Si quiere volver a jugar reiniciamos el juego
                    if (repite)
                    {
                        ReiniciarPartida();
                    }
                    else //Si no, se cierra la app
                    {
                        App.Current.Quit();
                    }
                }
            }

            NotifyPropertyChanged(nameof(NumAciertos));
            NotifyPropertyChanged(nameof(NumIntentos));
            ComprobarCommand.RaiseCanExecuteChanged();
        }

        private bool ComprobarCommand_CanExecute()
        {
            return true;
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

            //Instanciamos la lista de personas con listado departamentos
            listaPersonasDepartamento = new ObservableCollection<clsPersonaListaDepartamentos>();

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

        /// <summary>
        /// Método que reiniciará el juego una vez el usuario haya perdido o ganado
        /// </summary>
        private void ReiniciarPartida()
        {
            //Reiniciamos el contador de aciertos y de intentos
            numAciertos = 0;
            numIntentos = 3;

            CargarListadoPersonas();

            //Notificamos los cambios en las propiedades
            NotifyPropertyChanged(nameof(NumAciertos));
            NotifyPropertyChanged(nameof(NumIntentos));


            //Aseguramos que el comando de comprobar pueda ejecutarse
            ComprobarCommand.RaiseCanExecuteChanged();
        }

        #endregion
    }
}
