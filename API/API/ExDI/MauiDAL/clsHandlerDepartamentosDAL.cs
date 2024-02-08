using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiDAL
{
    public class clsHandlerDepartamentosDAL
    {
        public static async Task<List<clsDepartamento>> getListadoCompletoDepartamentosDAL()
        {
            string miCadenaUrl = clsConexion.conexionApi();
            Uri miUri = new Uri($"{miCadenaUrl}departamentos");
            List<clsDepartamento> listadoDepartamento = new List<clsDepartamento>();
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
                    listadoDepartamento = JsonConvert.DeserializeObject<List<clsDepartamento>>(textoJsonRespuesta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listadoDepartamento;
        }

        public static async Task<clsDepartamento> getDepartamentoPorIdDAL(int id)
        {
            string miCadenaUrl = clsConexion.conexionApi();
            Uri miUri = new Uri($"{miCadenaUrl}departamentos/" + id);
            clsDepartamento departamento = new clsDepartamento();
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
                    departamento = JsonConvert.DeserializeObject<clsDepartamento>(textoJsonRespuesta);
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
