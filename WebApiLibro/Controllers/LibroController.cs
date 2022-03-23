using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // para que aparezca el include
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiLibro.basevisual;

namespace WebApiLibro.Controllers
{
  
    [ApiController]
    public class LibroController : ControllerBase
    {

        [Route("api/[controller]/listarTodo")]
        public List<Libro> ListarTodo()
        {
            var resultado = new List<Libro>();
            var con = new ConexionContexto();
            resultado = con.Libros.
                Include(l=>l.IdCategoriaNavigation).
                ToList();

            return resultado;
        }
    }
}
