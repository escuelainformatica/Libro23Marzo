using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibro.basevisual;

namespace WindowsFormsApp1.servicio
{
    public class LibroSrv
    {
        public static Libro Crear(decimal id, string titulo,object idCategoria)
        {
            var resultado = new Libro();
            resultado.Id = Convert.ToInt32(id);
            resultado.Titulo = titulo;
            resultado.IdCategoria = Convert.ToInt32(idCategoria);

            return resultado;
        }
        public static string Validar(Libro libro)
        {
            // logica de negocio.
            var resultado = "";
            if(libro.Titulo==null || libro.Titulo.Length==0)
            {
                resultado = "El titulo es requerido";
            }
            if(libro.Titulo.Length>20)
            {
                resultado = "El titulo no puede ser mayor a 20 caracteres";
            }
            if(libro.IdCategoria<=0)
            {
                resultado = "La categoria es requerida";
            }

            return resultado;
        }
    }
}
