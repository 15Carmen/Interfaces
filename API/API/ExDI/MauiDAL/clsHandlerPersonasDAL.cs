using Entidades;
using Newtonsoft.Json;

namespace MauiDAL
{
    public class clsHandlerPersonasDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<List<clsPersona>> getListadoCompletoPersonasDAL()
        {
            //Pido la cadena de la Uri al método estático
            string miCadenaUrl = clsConexion.conexionApi();
            Uri miUri = new Uri($"{miCadenaUrl}personas");
            List<clsPersona> listadoPersonas = new List<clsPersona>();
            HttpClient mihttpClient;
            HttpResponseMessage miCodigoRespuesta;
            string textoJsonRespuesta;
            //Instanciamos el cliente Http
            mihttpClient = new HttpClient();
            
                miCodigoRespuesta = await mihttpClient.GetAsync(miUri);
                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);
                    mihttpClient.Dispose();
                    //JsonConvert necesita using Newtonsoft.Json;
                    //Es el paquete Nuget de Newtonsoft
                    listadoPersonas = JsonConvert.DeserializeObject<List<clsPersona>>(textoJsonRespuesta);
                }
          
           
            return listadoPersonas;
        }

        public static async Task<clsPersona> getPersonaPorIdDAL(int id)
        {
            //Pido la cadena de la Uri al método estático
            string miCadenaUrl = clsConexion.conexionApi();
            Uri miUri = new Uri($"{miCadenaUrl}personas/{id}");
            clsPersona persona = new clsPersona();
            HttpClient mihttpClient;
            HttpResponseMessage miCodigoRespuesta;
            string textoJsonRespuesta;
            //Instanciamos el cliente Http
            mihttpClient = new HttpClient();
            try
            {
                miCodigoRespuesta = await mihttpClient.GetAsync(miUri);
                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);
                    mihttpClient.Dispose();
                    persona = JsonConvert.DeserializeObject<clsPersona>(textoJsonRespuesta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return persona;
        }
    }
}
