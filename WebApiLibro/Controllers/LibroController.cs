using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // para que aparezca el include
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiLibro.basevisual;

namespace WebApiLibro.Controllers
{
    // CRUDL  Create (insertar) ✅, Read ✅, Update ✅, Delete, List  ✅, Count ✅

    [ApiController]
    public class LibroController : ControllerBase
    {

        [Route("api/[controller]/")]
        [HttpGet]
        public List<Libro> ListarTodo()
        {

            Thread.Sleep(4000); 

            var resultado = new List<Libro>();            
            try
            {
                // 1) creo la conexion
                using (var con = new ConexionContexto())
                {
                    // 2) listo los datos
                    resultado = con.Libros.
                        Include(l => l.IdCategoriaNavigation).
                        ToList();
                }
            }
            catch(Exception ex)
            {
                resultado = null;
            }
            return resultado;
        }
        // localhost:xxx/api/libro/obtener/2
        [Route("api/[controller]/obtener/{id}")]
        [HttpGet]
        public Libro Obtener(int id)
        {
            var resultado = new Libro();
            try
            {
                using(var con=new ConexionContexto())
                {
                    //resultado = con.Libros.Where(libro => libro.Id == idLibro).FirstOrDefault();
                    resultado = con.Libros
                        .Include(libro => libro.IdCategoriaNavigation)
                        .Where(libro => libro.Id == id)
                        .FirstOrDefault();
                }
            } catch(Exception ex)
            {
                resultado = null;
            }
            return resultado;
        }
        // http://localhost:54793/api/libro/obtener?id=2
        [Route("api/[controller]/obtener")]
        public Libro ObtenerAlterno(int id)
        {
            return Obtener(id);
        }

        [Route("api/[controller]/contar")]
        public int Contar()
        {
            int resultado = 0;
            try
            {
                using (var con = new ConexionContexto())
                {
                    resultado = con.Libros.Count();
                }
            }
            catch (Exception ex)
            {
                resultado = 0;
            }
            return resultado;
        }

        [Route("api/[controller]/insertar")]
        [HttpPost]
        public bool Insertar(Libro libro)
        {
            var resultado = true;
            try
            {
                using (var con = new ConexionContexto())
                {
                    // insert into libros(id,titulo,idcategoria) values(....);
                    con.Libros.Add(libro); // pendiente de guardar
                    con.SaveChanges(); // guardo todos los cambios pendientes.
                }
            }
            catch (Exception ex)
            {
                resultado = false;
            }


            return resultado;
        }

        [Route("api/[controller]/modificar")]
        [HttpPost]
        public bool Actualizar(Libro libro)
        {
            var resultado = true;
            try
            {
                using (var con = new ConexionContexto())
                {
                    // 1) voy a leer el libro antiguo
                    var libroAntiguo = con.Libros.Find(libro.Id);
                    // 2) luego, voy a modificar los valores.
                    libroAntiguo.IdCategoria = libro.IdCategoria;
                    libroAntiguo.Titulo = libro.Titulo;
                    // 3) guardo los cambios.
                    con.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                resultado = false;
            }
            return resultado;
        }

        [Route("api/[controller]/eliminar")]
        [HttpPost]
        public bool Eliminar(int id)
        {
            var resultado = true;
            try
            {
                using (var con = new ConexionContexto())
                {
                    // 1) voy a leer el libro antiguo
                    var libroAntiguo = con.Libros.Find(id);
                    // 2) borro el libro
                    con.Libros.Remove(libroAntiguo);
                    // 3) actualizo los cambios
                    con.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                resultado = false;
            }

            return resultado;
        }

        [Route("api/[controller]/listarporcat/{idCat}")]
        [HttpGet]
        public List<Libro> ListarPorCategoria(int idCat)
        {
            var resultado = new List<Libro>();
            try
            {
                using (var con = new ConexionContexto())
                {
                    resultado = con.Libros.Where(libro => libro.IdCategoria == idCat).ToList();
                }
            }
            catch (Exception ex)
            {
                resultado = null;
            }


            return resultado;
        }




    }
}
