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
    class CategoriaClienteWS
    {
        // 

        public static async Task<List<Categoria>> LeerAsync()
        {
            var resultado = new List<Categoria>();
            try
            {
                using (var client = new HttpClient())
                {
                    var conexion = await client.GetAsync("http://localhost:54793/api/categoria/listarTodo");
                    var contenido = await conexion.Content.ReadAsStringAsync();
                    // Newtownsoft
                    resultado = JsonConvert.DeserializeObject<List<Categoria>>(contenido);
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("errores.log", ex.Message + " "
                    + ex.InnerException.Message + " " + DateTime.Now.ToString() + "\n");

                resultado = null;
            }
            return resultado;
        }
    }
}
