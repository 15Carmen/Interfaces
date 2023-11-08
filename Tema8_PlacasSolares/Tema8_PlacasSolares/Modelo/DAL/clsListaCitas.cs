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
                 new clsCitas("Avenida Federico Molina, 32", "Carmen Martín", 653532798, true),
                 new clsCitas("Calle de la llorería, 12", "Lucía Molina", 234568124, false),
                 new clsCitas("Calle Alcotán, 97", "Fernando Acosta", 9531671822, false),
                 new clsCitas("Plaza de la Perlita, 16", "Marcos Domínguez", 637810234, true),
                 new clsCitas("Avenida Conquistadores, 25", "Carla Cortés", 523415234, false),

            };

            return listaCitas;
        }

    }
}
