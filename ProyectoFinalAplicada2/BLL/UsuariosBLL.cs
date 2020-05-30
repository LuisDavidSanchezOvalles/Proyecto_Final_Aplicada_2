using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoFinalAplicada2.Models;
using ProyectoFinalAplicada2.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ProyectoFinalAplicada2.BLL
{
    public class UsuariosBLL
    {
        public static bool Guardar(Usuarios usuario)
        {
            if (!Existe(usuario.UsuarioId))
                return Insertar(usuario);
            else
                return Modificar(usuario);
        }

        public static bool Insertar(Usuarios usuario)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Usuarios.Add(usuario) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Usuarios usuario)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(usuario).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var usuario = db.Usuarios.Find(id);
                db.Usuarios.Remove(usuario);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static Usuarios Buscar(int id)
        {
            Usuarios usuario = new Usuarios();
            Contexto db = new Contexto();
            try
            {
                usuario = db.Usuarios.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return usuario;
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();

            try
            {
                encontrado = db.Usuarios.Any(u => u.UsuarioId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return encontrado;
        }

        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> usuario)
        {
            List<Usuarios> Lista = new List<Usuarios>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Usuarios.Where(usuario).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }

        public static bool Existe(string usuario, string clave)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Usuarios.Where(u => u.NombreUsuario == usuario && u.Clave == clave).SingleOrDefault() != null)
                    paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static int ObtenerId(string usuario, string clave)
        {
            Contexto db = new Contexto();
            int id;
            try
            {
                id = db.Usuarios.Where(u => u.NombreUsuario == usuario && u.Clave == clave).SingleOrDefault().UsuarioId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return id;
        }
    }
}
