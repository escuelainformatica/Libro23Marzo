using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiLibro.basevisual;

namespace WebApiLibro.Controllers
{    
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [Route("api/[controller]/listarTodo")]
        public List<Categoria> listarTodo()
        {
            var resultados = new List<Categoria>();
            var con = new ConexionContexto();

            // LINQ
            // funcion lambda. = > 
            // c(alias) => (donde)

            resultados = con.Categorias
                .OrderBy(categoria=>categoria.Nombre)
                .ToList();
            return resultados;
        }

        [Route("api/[controller]/listarFiltrado")]
        public List<Categoria> listarFiltrado(int id)
        {
            var resultados = new List<Categoria>();
            var con = new ConexionContexto();

            resultados = con.Categorias.Where(c => c.Id == id).ToList();
            return resultados;
        }

        [Route("api/[controller]/obtenerFiltrado")]
        public Categoria obtenerFiltrado(int id)
        {
            var resultados = new Categoria();
            var con = new ConexionContexto();

            resultados = con.Categorias.Where(c => c.Id == id).FirstOrDefault();
            return resultados;
        }

    } // clase

}
