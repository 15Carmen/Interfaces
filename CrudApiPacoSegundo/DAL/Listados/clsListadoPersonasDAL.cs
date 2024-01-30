using Entities;
using Newtonsoft.Json;


namespace DAL.Listados
{
    public class clsListadoPersonasDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<List<clsPersona>> getListadoPersonasDAL()
        {
            //Pido la cadena de la Uri al método estático
            string miCadenaUrl = clsUriBase.getUriBase();
            Uri miUri = new Uri($"{miCadenaUrl}personas");
            List<clsPersona> listadoPersonas = new List<clsPersona>();
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
                    //JsonConvert necesita using Newtonsoft.Json;
                    //Es el paquete Nuget de Newtonsoft
                    listadoPersonas = JsonConvert.DeserializeObject<List<clsPersona>>(textoJsonRespuesta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listadoPersonas;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<clsPersona> obtenerPersonaPorIdDAL(int id)
        {
            //Pido la cadena de la Uri al método estático
            string miCadenaUrl = clsUriBase.getUriBase();
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
