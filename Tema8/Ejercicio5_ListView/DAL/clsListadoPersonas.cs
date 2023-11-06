using Ejercicio5_ListView.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5_ListView.DAL
{
    class clsListadoPersonas
    {
        public static ObservableCollection<clsPersona> listaPersonas()
        {
            ObservableCollection<clsPersona> listadoCompleto = new ObservableCollection<clsPersona>()
            {
                new clsPersona {Nombre="Carmen", Apellidos = "Martín"},
                new clsPersona {Nombre="Isa", Apellidos = "Loerzer"},
                new clsPersona {Nombre="Luisa", Apellidos = "Alejandra"},
                new clsPersona {Nombre="Lydia", Apellidos = "Pérez"},
                new clsPersona {Nombre="Paco", Apellidos = "De Paula"},
                new clsPersona {Nombre="Javi", Apellidos = "González"},
                new clsPersona {Nombre="Miguel", Apellidos = "Fernández"},
                new clsPersona {Nombre="Fernando", Apellidos = "Galán"},
                new clsPersona {Nombre="Luke", Apellidos = "Skywalker"},
                new clsPersona {Nombre="Obi-Wan", Apellidos = "Kenobi"}
            };

            return listadoCompleto;
        }
    }
}
