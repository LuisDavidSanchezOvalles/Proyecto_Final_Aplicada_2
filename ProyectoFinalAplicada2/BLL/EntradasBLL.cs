using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada2.Models;
using ProyectoFinalAplicada2.DAL;
using System.Linq.Expressions;

namespace ProyectoFinalAplicada2.BLL
{
    public class EntradasBLL
    {
        public static bool Guardar(Entradas entrada)
        {
            if (!Existe(entrada.EntradaId))
                return Insertar(entrada);
            else
                return Modificar(entrada);
        }

        public static bool Insertar(Entradas entrada)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Entradas.Add(entrada) != null)
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

        public static bool Modificar(Entradas entrada)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(entrada).State = EntityState.Modified;
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
                var entrada = db.Entradas.Find(id);
                db.Entradas.Remove(entrada);
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
        public static Entradas Buscar(int id)
        {
            Entradas entrada = new Entradas();
            Contexto db = new Contexto();
            try
            {
                entrada = db.Entradas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return entrada;
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();

            try
            {
                encontrado = db.Entradas.Any(e => e.EntradaId == id);
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

        public static List<Entradas> GetList(Expression<Func<Entradas, bool>> entrada)
        {
            List<Entradas> Lista = new List<Entradas>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Entradas.Where(entrada).ToList();
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
    }
}
