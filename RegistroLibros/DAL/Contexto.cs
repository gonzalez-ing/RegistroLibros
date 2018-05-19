using RegistroLibros.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroLibros.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Libros> Libros { get; set; }

        // base("ConStr") para pasar la conexion a la clase base de EntityFramework 
        public Contexto() : base("ConStr")
        { }
    }
}
