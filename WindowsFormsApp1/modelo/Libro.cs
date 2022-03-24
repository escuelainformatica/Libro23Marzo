using System;
using System.Collections.Generic;



namespace WebApiLibro.basevisual
{
    public partial class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int? IdCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
    }
}
