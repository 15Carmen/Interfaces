using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace Ejercicio1.DAL
{
    public class clsConexion
    {

        public void Conexion()
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "server=107-25/SQLEXPRESS;database=Persona;uid=prueba;pwd=123;";

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            
        }

    }
}
