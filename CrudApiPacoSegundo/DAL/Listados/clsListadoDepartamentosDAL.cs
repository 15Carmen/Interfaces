using Entities;
using Newtonsoft.Json;

namespace DAL.Listados
{
    public class clsListadoDepartamentosDAL
    {

        public static async Task<List<clsDepartamentos>> getListadoDepartamentosDAL()
        {
            string miCadenaUrl = clsUriBase.getUriBase();
            Uri miUri = new Uri($"{miCadenaUrl}departamentos");
            List<clsDepartamentos> listadoDepartamento = new List<clsDepartamentos>();
            HttpClient mihttpClient;
            HttpResponseMessage miCodigoRespuesta;
            string textoJsonRespuesta;
            mihttpClient = new HttpClient();
            try
            {
                miCodigoRespuesta = await mihttpClient.GetAsync(miUri);
                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);
                    mihttpClient.Dispose();
                    listadoDepartamento = JsonConvert.DeserializeObject<List<clsDepartamentos>>(textoJsonRespuesta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listadoDepartamento;
        }

        public static async Task<clsDepartamentos> obtenerDepartamentoPorIdDAL(int id)
        {
            string miCadenaUrl = clsUriBase.getUriBase();
            Uri miUri = new Uri($"{miCadenaUrl}departamentos/" + id);
            clsDepartamentos departamento = new clsDepartamentos();
            HttpClient mihttpClient;
            HttpResponseMessage miCodigoRespuesta;
            string textoJsonRespuesta;
            mihttpClient = new HttpClient();
            try
            {
                miCodigoRespuesta = await mihttpClient.GetAsync(miUri);
                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);
                    mihttpClient.Dispose();
                    departamento = JsonConvert.DeserializeObject<clsDepartamentos>(textoJsonRespuesta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return departamento;
        }
    }
}
