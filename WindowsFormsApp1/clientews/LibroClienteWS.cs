using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiLibro.basevisual;

namespace WindowsFormsApp1.clientews
{
    class LibroClienteWS
    {
        public async Task<List<Libro>> LeerLibrosAsync()
        {
            var resultado = new List<Libro>();
            try
            {
                using (var client = new HttpClient())
                {
                    var conexion = await client.GetAsync("http://localhost:54793/api/libro/");
                    var contenido = await conexion.Content.ReadAsStringAsync();
                    // Newtownsoft
                    resultado = JsonConvert.DeserializeObject<List<Libro>>(contenido);
                }
            } catch (Exception ex)
            {
                File.AppendAllText("errores.log", ex.Message + " " 
                    + ex.InnerException.Message+ " "+DateTime.Now.ToString() +"\n");

                resultado = null;
            }
            return resultado;
        }
        public async Task<bool> Insertar(Libro libro)
        {
            var resultado = true;
            try
            {
                using (var client = new HttpClient())
                {
                    var libroJson = JsonConvert.SerializeObject(libro);
                    var contenidoSolicitud = new StringContent(libroJson, System.Text.Encoding.UTF8, "application/json");

                    var conexion = await client.PostAsync("http://localhost:54793/api/libro/insertar", contenidoSolicitud);

                    var contenidoRespuesta = await conexion.Content.ReadAsStringAsync();

                    resultado = JsonConvert.DeserializeObject<bool>(contenidoRespuesta);

                }
            } catch(Exception ex)
            {
                File.AppendAllText("errores.log","LibroClientws.insertar(): " + ex.Message + " "
                    + ex.InnerException.Message + " " + DateTime.Now.ToString() + "\n");
                resultado = false;
            }
            return resultado;
        }


    }
}
