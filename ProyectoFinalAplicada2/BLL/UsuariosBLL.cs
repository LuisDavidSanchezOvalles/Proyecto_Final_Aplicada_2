using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoFinalAplicada2.Models;
using ProyectoFinalAplicada2.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text;

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

        private static bool Insertar(Usuarios usuario)
        {
            if (usuario.UsuarioId != 0)
                return false;

            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                usuario.Clave = Encriptar(usuario.Clave);

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

        private static bool Modificar(Usuarios usuario)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                usuario.Clave = Encriptar(usuario.Clave);

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

        public static string Encriptar(string cadenaEncriptada)
        {
            if (!string.IsNullOrEmpty(cadenaEncriptada))
            {
                string resultado = string.Empty;
                byte[] encryted = Encoding.Unicode.GetBytes(cadenaEncriptada);
                resultado = Convert.ToBase64String(encryted);

                return resultado;
            }
            return string.Empty;
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
                if(usuario != null)
                    usuario.Clave = DesEncriptar(usuario.Clave);
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

        public static string DesEncriptar(string cadenaDesencriptada)
        {
            if (!string.IsNullOrEmpty(cadenaDesencriptada))
            {
                string resultado = string.Empty;
                byte[] decryted = Convert.FromBase64String(cadenaDesencriptada);
                resultado = System.Text.Encoding.Unicode.GetString(decryted);

                return resultado;
            }
            return string.Empty;
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

        public static bool ExisteUsuario(string usuario, string clave)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                clave = Encriptar(clave);

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

        public static string ObtenerUsuarioId(string usuario, string clave)
        {
            Contexto db = new Contexto();
            string id;
            try
            {
                clave = Encriptar(clave);

                id = db.Usuarios.Where(u => u.NombreUsuario == usuario && u.Clave == clave).FirstOrDefault().UsuarioId.ToString();
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
