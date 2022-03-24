using System;
using System.Collections.Generic;



namespace WebApiLibro.basevisual
{
    public partial class Categoria
    {
        public Categoria()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
