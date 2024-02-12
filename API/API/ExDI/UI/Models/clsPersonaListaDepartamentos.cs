using Entidades;
using MauiBL;
using System.Collections.ObjectModel;

namespace UI.Models
{
    public class clsPersonaListaDepartamentos : clsPersona
    {
        #region atributos
        private ObservableCollection<clsDepartamento> listaDepartamentos;
        
        #endregion

        #region constructores


        public clsPersonaListaDepartamentos(clsPersona p)
        {
            listaDepartamentos = new ObservableCollection<clsDepartamento>();
            this.Nombre = p.Nombre;
            this.Apellidos = p.Apellidos;
            this.Direccion = p.Direccion;
            this.FechaNac = p.FechaNac;
            this.Foto = p.Foto;
            this.Id = p.Id;
            this.IdDepartamento = p.IdDepartamento;
            this.Telefono = p.Telefono;
           
        }

        #endregion

        #region propiedades

        public ObservableCollection<clsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos; }
            set { listaDepartamentos = value; }
        }

        #endregion

        #region funciones y métodos


        #endregion

    }
}
