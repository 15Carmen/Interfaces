using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema8_PlacasSolares.Modelo.Entidades;

namespace Tema8_PlacasSolares.Modelo.DAL
{
    class clsListaCitas
    {
        /// <summary>
        /// Función que devuelve el listado completo de las citas
        /// Precondiciones: la base de datos esta disponible
        /// Postcondiciones: ninguna
        /// </summary>
        /// <returns> List<clsCita> </returns>
        /// 
        public static ObservableCollection<clsCitas> listadoCompletoCitas()
        {

            ObservableCollection<clsCitas> listaCitas = new ObservableCollection<clsCitas>()
            {
                 new clsCitas("Avenida Federico Molina, 32", "Carmen Martín", 653532798, "cositas importantes"),
                 new clsCitas("Calle de la llorería, 12", "Lucía Molina", 234568124, "una descripcion muy buena"),
                 new clsCitas("Calle Alcotán, 97", "Fernando Acosta", 9531671822, "cositas importantes"),
                 new clsCitas("Plaza de la Perlita, 16", "Marcos Domínguez", 637810234, "cositas importantes"),
                 new clsCitas("Avenida Conquistadores, 25", "Carla Cortés", 523415234, "Antonio devuelveme el dinero del bocata"),

            };

            return listaCitas;
        }

    }
}
