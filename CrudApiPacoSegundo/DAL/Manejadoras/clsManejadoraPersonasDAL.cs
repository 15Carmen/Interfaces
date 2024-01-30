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
    public class clsManejadoraPersonasDAL
    {
        public static async Task<HttpStatusCode> insertarPersonasDAL(clsPersona persona)

        {
            HttpClient mihttpClient = new HttpClient();
            string datos;
            HttpContent contenido;
            string miCadenaUrl = clsUriBase.getUriBase();
            Uri miUri = new Uri($"{miCadenaUrl}personas");
            //Usaremos el Status de la respuesta para comprobar si ha insertado.
            HttpResponseMessage miRespuesta = new HttpResponseMessage();
            try
            {
                datos = JsonConvert.SerializeObject(persona);
                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                miRespuesta = await mihttpClient.PostAsync(miUri, contenido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miRespuesta.StatusCode;
        }

        public static async Task<HttpStatusCode> editarPersonaDAL(clsPersona persona)
        {
            HttpClient mihttpClient = new HttpClient();
            string datos;
            HttpContent contenido;
            string miCadenaUrl = clsUriBase.getUriBase();
            Uri miUri = new Uri($"{miCadenaUrl}personas/{persona.id}");
            HttpResponseMessage miRespuesta = new HttpResponseMessage();
            try
            {
                datos = JsonConvert.SerializeObject(persona);
                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                miRespuesta = await mihttpClient.PutAsync(miUri, contenido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miRespuesta.StatusCode;
        }
        public static async Task<HttpStatusCode> borrarPersonaDAL(int id)
        {
            HttpClient mihttpClient = new HttpClient();
            string datos;
            HttpContent contenido;
            string miCadenaUrl = clsUriBase.getUriBase();
            Uri miUri = new Uri($"{miCadenaUrl}personas/{id}");
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
