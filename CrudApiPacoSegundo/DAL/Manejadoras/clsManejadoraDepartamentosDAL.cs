using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manejadoras
{
    public class clsManejadoraDepartamentosDAL
    {
        public static async Task<HttpStatusCode> insertarDepartamentoDAL(clsDepartamentos departamento)

        {
            HttpClient mihttpClient = new HttpClient();
            string datos;
            HttpContent contenido;
            string miCadenaUrl = clsUriBase.getUriBase();
            Uri miUri = new Uri($"{miCadenaUrl}departamentos");
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

        public static async Task<HttpStatusCode> editarDepartamentoDAL(clsDepartamentos departamento)
        {
            HttpClient mihttpClient = new HttpClient();
            string datos;
            HttpContent contenido;
            string miCadenaUrl = clsUriBase.getUriBase();
            Uri miUri = new Uri($"{miCadenaUrl}departamentos/{departamento.id}");
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
        public static async Task<HttpStatusCode> borrarDepartamentosDAL(int id)
        {
            HttpClient mihttpClient = new HttpClient();
            string datos;
            HttpContent contenido;
            string miCadenaUrl = clsUriBase.getUriBase();
            Uri miUri = new Uri($"{miCadenaUrl}departamentos/{id}");
            HttpResponseMessage miRespuesta = new HttpResponseMessage();
            try
            {
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
