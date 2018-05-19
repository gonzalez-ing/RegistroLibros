using RegistroLibros.DAL;
using RegistroLibros.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RegistroLibros.BLL
{
    class LibrosBLL
    {
        public static bool Guardar(Libros libros)
        {
            bool paso = false;
            //Creamos una instancia del contexto para poder conectar con la BD
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Libros.Add(libros) != null)
                {
                    contexto.SaveChanges(); //Guardar los cambios
                    paso = true;
                }

                contexto.Dispose();//siempre hay que cerrar la conexion
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static bool Modificar(Libros libros)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(libros).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Libros libros = contexto.Libros.Find(id);

                contexto.Libros.Remove(libros);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static Libros Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Libros libros = new Libros();
            try
            {
                libros = contexto.Libros.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return libros;
        }


        public static List<Libros> GetList(Expression<Func<Libros, bool>> expression)
        {
            List<Libros> Personas = new List<Libros>();
            Contexto contexto = new Contexto();
            try
            {
                Personas = contexto.Libros.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return Personas;
        }
    }
}
