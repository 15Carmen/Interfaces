using BL.Listados;
using BL.Manejadoras;
using Maui.ViewModels.Utilidades;
using Entities;
using System.Collections.ObjectModel;

namespace Maui.ViewModels
{
    /// <summary>
    /// ViewModel para editar o crear personas.
    /// </summary>
    [QueryProperty("Persona", "personaParaMandar")]
    public class AgregarEditarPersonaVM : clsVMBase, IQueryAttributable
    {
        #region Atributos
        private DelegateCommand agregarCommand;
        private DelegateCommand editarCommand;
        private ObservableCollection<clsDepartamentos> listaDepartamentos;
        private clsPersona persona;
        private clsDepartamentos departamento;
        #endregion

        #region Contructores
        private AgregarEditarPersonaVM(ObservableCollection<clsDepartamentos> lista)
        {
            listaDepartamentos = lista;
            agregarCommand = new DelegateCommand(AgregarCommand_Executed);
            editarCommand = new DelegateCommand(EditarCommand_Executed);
            Persona = new clsPersona();
        }
        /// <summary>
        /// Precondiciones: No tiene.
        /// Constructor asíncrono que recibe la lista, y la manda al constructor privado.
        /// Postcondiciones: Se construye la página.
        /// </summary>
        /// <returns>Devuelve la lista de la api una vez recibida.</returns>
        public static async Task<AgregarEditarPersonaVM> BuildViewModelAsync()
        {
            ObservableCollection<clsDepartamentos> listaAsincrona = new ObservableCollection<clsDepartamentos>(await clsListadoDepartamentosBL.getListadoDepartamentosBL());
            return new AgregarEditarPersonaVM(listaAsincrona);
        }
        #endregion

        #region Propiedades
        public clsPersona Persona
        {
            get { return persona; }
            set
            {
                persona = value;
                departamento = listaDepartamentos.FirstOrDefault(x => x.id == persona.idDepartamento);
                NotifyPropertyChanged(nameof(Departamento));
                NotifyPropertyChanged(nameof(Persona));
            }
        }
        public clsDepartamentos Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }
        public ObservableCollection<clsDepartamentos> ListaDepartamentos
        {
            get { return listaDepartamentos; }
        }
        public DelegateCommand AgregarCommand { get { return agregarCommand; } }
        public DelegateCommand EditarCommand { get { return editarCommand; } }
        #endregion

        #region Commands
        /// <summary>
        /// Precondiciones: No tiene.
        /// Comando para agregar a la persona.
        /// Postcondiciones: Agregas a la persona en la BBDD.
        /// </summary>
        private async void AgregarCommand_Executed()
        {
            bool agregar = await Application.Current.MainPage.DisplayAlert("¿Agregar persona?", null, "Si", "No");
            if (agregar)
            {
                try
                {
                    Persona.idDepartamento = Departamento.id;
                    NotifyPropertyChanged("Derpartamento");
                    await clsManejadoraPersonas.insertarPersonasBL(Persona);
                    await Application.Current.MainPage.DisplayAlert("Persona insertada correctamente", null, "Ok");
                    await Shell.Current.GoToAsync("..");
                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("Alert!", "No se ha podido agregar a la persona", "Ok");
                }
            }
            else
            {
                await Shell.Current.GoToAsync("..");
            }
        }
        /// <summary>
        /// Precondiciones: No tiene.
        /// Comando para editar a la persona.
        /// Postcondiciones: Editas a la persona en la BBDD.
        /// </summary>
        private async void EditarCommand_Executed()
        {
            bool agregar = await Application.Current.MainPage.DisplayAlert("¿Editar persona?", null, "Si", "No");
            if (agregar)
            {
                try
                {
                    Persona.idDepartamento = Departamento.id;
                    await clsManejadoraPersonas.editarPersonaBL(Persona);
                    await Application.Current.MainPage.DisplayAlert("Persona editada correctamente", null, "Ok");
                    await Shell.Current.GoToAsync("..");
                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("Alert!", "No se ha podido editar a la persona", "Ok");
                }
            }
            else
            {
                await Shell.Current.GoToAsync("..");
            }
        }
        #endregion

        #region Metodos
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Persona = query["personaParaMandar"] as clsPersona;
        }
        #endregion
    }
}
