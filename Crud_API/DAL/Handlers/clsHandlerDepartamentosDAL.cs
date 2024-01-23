using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Handlers
{
    public class clsHandlerDepartamentosDAL
    {

        public static async Task<HttpStatusCode> insertarDepartamentoDAL(clsPersona departamento)
        {
            HttpClient mihttpClient = new HttpClient();
            string datos;
            HttpContent contenido;
            string miCadenaUrl = clsConexion.conexionApi();
            Uri miUri = new Uri($"{miCadenaUrl}departamentos");

            //Usaremos el Status de la respuesta para comprobar si ha borrado
            HttpResponseMessage miRespuesta = new HttpResponseMessage();
            try
            {
                datos = JsonConvert.SerializeObject(departamento);

                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                miRespuesta = await mihttpClient.PostAsync(miUri, contenido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miRespuesta.StatusCode;
        }


        public static async Task<HttpStatusCode> editarDepartamentoDAL(clsPersona departamento)
        {
            HttpClient mihttpClient = new HttpClient();
            string datos;
            HttpContent contenido;
            string miCadenaUrl = clsConexion.conexionApi();
            Uri miUri = new Uri($"{miCadenaUrl}departamentos");

            //Usaremos el Status de la respuesta para comprobar si ha borrado
            HttpResponseMessage miRespuesta = new HttpResponseMessage();
            try
            {
                datos = JsonConvert.SerializeObject(departamento);

                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                miRespuesta = await mihttpClient.PutAsync(miUri, contenido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miRespuesta.StatusCode;
        }

        public static async Task<HttpStatusCode> borrarDepartamentoDAL(int id)
        {
            HttpClient mihttpClient = new HttpClient();
            string datos;
            HttpContent contenido;
            string miCadenaUrl = clsConexion.conexionApi();
            Uri miUri = new Uri($"{miCadenaUrl}departamentos");

            //Usaremos el Status de la respuesta para comprobar si ha borrado
            HttpResponseMessage miRespuesta = new HttpResponseMessage();
            try
            {
                datos = JsonConvert.SerializeObject(id);

                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                miRespuesta = await mihttpClient.DeleteAsync(miUri);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miRespuesta.StatusCode;
        }
    }
}
