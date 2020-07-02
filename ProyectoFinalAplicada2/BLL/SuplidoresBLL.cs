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
    public class SuplidoresBLL
    {
        public static bool Guardar(Suplidores suplidor)
        {
            if (!Existe(suplidor.SuplidorId))
                return Insertar(suplidor);
            else
                return Modificar(suplidor);
        }

        public static bool Insertar(Suplidores suplidor)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Suplidores.Add(suplidor) != null)
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

        public static bool Modificar(Suplidores suplidor)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(suplidor).State = EntityState.Modified;
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
                var suplidor = db.Suplidores.Find(id);
                db.Suplidores.Remove(suplidor);
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
        public static Suplidores Buscar(int id)
        {
            Suplidores suplidor = new Suplidores();
            Contexto db = new Contexto();
            try
            {
                suplidor = db.Suplidores.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return suplidor;
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();

            try
            {
                encontrado = db.Suplidores.Any(s => s.SuplidorId == id);
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

        public static List<Suplidores> GetList(Expression<Func<Suplidores, bool>> suplidor)
        {
            List<Suplidores> Lista = new List<Suplidores>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Suplidores.Where(suplidor).ToList();
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

        public static bool ExisteSuplidor()
        {
            List<Suplidores> suplidores = GetList(s => true);

            if (suplidores.Count > 0)
                return true;
            else
                return false;
        }
    }
}
