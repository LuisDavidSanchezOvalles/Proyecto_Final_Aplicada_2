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
    public class ContratosBLL
    {
        public static bool Guardar(Contratos contrato)
        {
            if (!Existe(contrato.ContratoId))
                return Insertar(contrato);
            else
                return Modificar(contrato);
        }

        public static bool Insertar(Contratos contrato)
        {
            if (contrato.ContratoId != 0)
                return false;

            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Contratos.Add(contrato) != null)
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

        public static bool Modificar(Contratos contrato)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(contrato).State = EntityState.Modified;
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
                var contrato = db.Contratos.Find(id);
                if(contrato != null)
                {
                    db.Contratos.Remove(contrato);
                    paso = db.SaveChanges() > 0;
                }
                
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
        public static Contratos Buscar(int id)
        {
            Contratos contrato = new Contratos();
            Contexto db = new Contexto();
            try
            {
                contrato = db.Contratos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return contrato;
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();

            try
            {
                encontrado = db.Contratos.Any(c => c.ContratoId == id);
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

        public static List<Contratos> GetList(Expression<Func<Contratos, bool>> contrato)
        {
            List<Contratos> Lista = new List<Contratos>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Contratos.Where(contrato).ToList();
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

        public static bool ExisteContrato()
        {
            List<Contratos> contratos = GetList(c => true);

            if (contratos.Count > 0)
                return true;
            else
                return false;
        }

        public static void EvaluarCantidad(int id, decimal cantidad)
        {
            Contratos contrato = Buscar(id);

            contrato.CantidadPendiente = cantidad;

            Modificar(contrato);
        }

        //public static void RestablecerCantidadPendiente(int id)
        //{
        //    Contratos contrato = Buscar(id);

        //    contrato.CantidadPendiente = contrato.Cantidad;

        //    Modificar(contrato);
        //}
        public static void RestablecerCantidadPendiente(int id)
        {
            Ventas venta = VentasBLL.Buscar(id);

            if (venta == null)
                return;

            Contratos contrato = Buscar(venta.VentaDetalle[0].ContratoId);

            contrato.CantidadPendiente = contrato.Cantidad;

            Modificar(contrato);
        }
    }
}
