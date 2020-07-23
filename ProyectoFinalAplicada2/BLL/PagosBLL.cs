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

        private static bool Insertar(Pagos pago)
        {
            if (pago.PagoId != 0)
                return false;

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Pagos.Add(pago) != null)
                    paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Pagos pago)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM PagosDetalle Where PagoId = {pago.PagoId}");

                foreach (var item in pago.PagoDetalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
                contexto.Entry(pago).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var pago = Buscar(id);
                if(pago != null)
                {
                    contexto.Pagos.Remove(pago);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Pagos Buscar(int id)
        {
            Pagos pago = new Pagos();
            Contexto contexto = new Contexto();

            try
            {
                pago = contexto.Pagos.Where(p => p.PagoId == id).Include(p => p.PagoDetalle).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return pago;
        }

        private static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Pagos.Any(p => p.PagoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Pagos> GetList(Expression<Func<Pagos, bool>> pago)
        {
            List<Pagos> Lista = new List<Pagos>();
            Contexto contexto = new Contexto();
            try
            {
                Lista = contexto.Pagos.Where(pago).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }

        public static Pagos PagoDeVenta(int ventaId)
        {
            Pagos pago = new Pagos();
            Contexto contexto = new Contexto();

            try
            {
                pago = contexto.Pagos.Include(p => p.PagoDetalle).Where(p => p.PagoDetalle[0].VentaId == ventaId).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return pago;
        }

        public static bool ExisteAlgunPago()
        {
            List<Pagos> pagos = GetList(c => true);

            if (pagos.Count > 0)
                return true;
            else
                return false;
        }

        public static bool VentaDisponible(Pagos pagos)
        {
            //verifica si la venta ya esta utilizada en algun otro pago
            List<Pagos> lista = GetList(p => true);

            foreach (var item in lista)
            {

                if (item.PagoDetalle[0].VentaId == pagos.PagoDetalle[0].VentaId)
                    return false;
            }

            return true;
        }
    }
}
