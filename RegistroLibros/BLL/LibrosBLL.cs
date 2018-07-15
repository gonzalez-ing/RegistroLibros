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
    public class LibrosBLL
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

        /// Permite Modificar una entidad en la base de datos 
        /// <param name="Libros">Una instancia de Libros</param>
        /// <returns>Retorna True si Modifico o Falso si falló </returns>
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

        /// Permite Eliminar una entidad en la base de datos
        ///<param name="id">El Id del Libro que se desea eliminar </param>
        /// <returns>Retorna True si Eliminó o Falso si falló </returns>
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

        /// Permite Buscar una entidad en la base de datos
        ///<param name="id">El Id del Libro que se desea encontrar </param>
        /// <returns>Retorna el libro encontrado </returns>
        public static Libros Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Libros persona = new Libros();
            try
            {
                persona = contexto.Libros.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return persona;
        }

        /// Permite extraer una lista de Libros de la base de datos
        ///<param name="expression">Expression Lambda conteniendo los filtros de busqueda </param>
        /// <returns>Retorna una lista de Libros</returns>
        public static List<Libros> GetList(Expression<Func<Libros, bool>> expression)
        {
            List<Libros> Libros = new List<Libros>();
            Contexto contexto = new Contexto();
            try
            {
                Libros = contexto.Libros.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return Libros;
        }
    }
}
