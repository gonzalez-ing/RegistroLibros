using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroLibros.Entidades
{
    public class Libros
    {
        public int LibroId { get; set; }
        public string Descripcion { get; set; }
        public string Siglas { get; set; }
        public virtual List<TipoId> Detalles { get; set; }

        public Libros(int libroId, string descripcion, string siglas, List<TipoId> detalles)
        {
            libroId = LibroId;
            Descripcion = descripcion;
            siglas = Siglas;
            Detalles = new List<TipoId>();
        }
        public Libros()
        {
            this.LibroId = 0;
            this.Descripcion = string.Empty;
            this.Siglas = string.Empty;
            this.Detalles = Detalles;
        }
    }
}