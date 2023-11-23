using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio1.Models.Entidades;

namespace Ejercicio1.Models.DAL
{
    public class clsListadoPersonasDAL
    {

        public static List<clsPersona> listadoCompletoPersonasDAL()
        {

            List<clsPersona> listadoPersonas = new List<clsPersona>();

            listadoPersonas.Add(new clsPersona(1, "Carmen", "Marrtin", 1));
            listadoPersonas.Add(new clsPersona(2, "Isa", "Loerzer", 3));

            return listadoPersonas;
        }

    }
}
