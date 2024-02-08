using Entidades;
using MauiBL;
using System.Collections.ObjectModel;

namespace UI.Models
{
    public class clsPersonaListaDepartamentos : clsPersona
    {
        #region atributos
        private ObservableCollection<clsDepartamento> listaDepartamentos;
        private clsDepartamento departamentoEscogido;


        #endregion

        #region constructores

        public clsPersonaListaDepartamentos(clsPersona p)
        {
            listaDepartamentos = new ObservableCollection<clsDepartamento>();
            this.Nombre = p.Nombre;
            this.Apellidos = p.Apellidos;
            this.departamentoEscogido = null;
        }

        #endregion

        #region propiedades

        public ObservableCollection<clsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos; }
        }

        public clsDepartamento DepartamentoEscogido
        {
            get { return departamentoEscogido; }
            set { departamentoEscogido = value; }
        }

        #endregion

        #region funciones y métodos


        #endregion

    }
}
