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
    public class PagosBLL
    {
        public static bool Guardar(Pagos pago)
        {
            if (!Existe(pago.PagoId))
                return Insertar(pago);
            else
                return Modificar(pago);
        }

        public static bool Insertar(Pagos pago)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Pagos.Add(pago) != null)
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

        public static bool Modificar(Pagos pago)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM PagosDetalle Where PagoId = {pago.PagoId}");

                foreach (var item in pago.PagoDetalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(pago).State = EntityState.Modified;
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var cliente = db.Clientes.Find(id);
                db.Clientes.Remove(cliente);
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
        public static Pagos Buscar(int id)
        {
            Pagos pago = new Pagos();
            Contexto db = new Contexto();
            try
            {
                pago = db.Pagos.Include(p => p.PagoDetalle).Where(p => p.PagoId == id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return pago;
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();

            try
            {
                encontrado = db.Pagos.Any(p => p.PagoId == id);
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

        public static List<Pagos> GetList(Expression<Func<Pagos, bool>> pago)
        {
            List<Pagos> Lista = new List<Pagos>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Pagos.Where(pago).ToList();
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

        public static Pagos PagoDeVenta(int id)
        {
            Pagos pago = new Pagos();
            Contexto db = new Contexto();

            try
            {
                pago = db.Pagos.Include(p => p.PagoDetalle).Where(p => p.PagoDetalle[0].VentaId == id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return pago;
        }

        public static bool ExistePago()
        {
            List<Pagos> pagos = GetList(c => true);

            if (pagos.Count > 0)
                return true;
            else
                return false;
        }

        public static bool EntradaValida(Pagos pagos)
        {
            //verifica si el contrato ya esta utilizado
            List<Pagos> lista = GetList(c => true);

            foreach (var item in lista)
            {

                if (item.PagoDetalle[0].VentaId == pagos.PagoDetalle[0].VentaId)
                    return false;
            }

            return true;
        }
    }
}
