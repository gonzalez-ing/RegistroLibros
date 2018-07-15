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
        public DateTime Fecha { get; set; }
        public string Siglas { get; set; }
        public virtual List<TipoId> Detalles { get; set; }

        public Libros(int libroId, string descripcion, DateTime fecha, string siglas, List<TipoId> detalles)
        {
            libroId = LibroId;
            Fecha = fecha;
            Descripcion = descripcion;
            siglas = Siglas;
            Detalles = new List<TipoId>();
        }
        public Libros()
        {
            this.LibroId = 0;
            Fecha = DateTime.Now;
            this.Descripcion = string.Empty;
            this.Siglas = string.Empty;
            this.Detalles = Detalles;
        }
    }
}