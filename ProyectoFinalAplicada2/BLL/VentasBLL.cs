﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada2.Models;
using ProyectoFinalAplicada2.DAL;
using System.Linq.Expressions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ProyectoFinalAplicada2.BLL
{
    public class VentasBLL
    {
        public static bool Guardar(Ventas venta)
        {
            if (!Existe(venta.VentaId))
                return Insertar(venta);
            else
                return Modificar(venta);
        }

        private static bool Insertar(Ventas venta)
        {
            if (venta.VentaId != 0)
                return false;

            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Ventas.Add(venta) != null)
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

        private static bool Modificar(Ventas venta)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM VentasDetalle Where VentaId = {venta.VentaId}");

                foreach (var item in venta.VentaDetalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }

                CalcularSaldo(venta);

                db.Entry(venta).State = EntityState.Modified;
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

        private static void CalcularSaldo(Ventas venta)
        {
            List<Pagos> pagos = PagosBLL.GetList(p => true);

            if(pagos != null)
            {
                foreach (var pago in pagos)
                {
                    if (pago.PagoDetalle[0].VentaId == venta.VentaId)
                    {
                        decimal balance = venta.Total;

                        foreach (var item in pago.PagoDetalle)
                        {
                            balance -= item.Monto;
                            item.Saldo = balance;
                        }

                        PagosBLL.Guardar(pago);
                    }
                }
            }
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var venta = db.Ventas.Find(id);
                if(venta != null)
                {
                    db.Ventas.Remove(venta);
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
        public static Ventas Buscar(int id)
        {
            Ventas venta = new Ventas();
            Contexto db = new Contexto();
            try
            {
                venta = db.Ventas.Where(v => v.VentaId == id).Include(v => v.VentaDetalle).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return venta;
        }

        private static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();

            try
            {
                encontrado = db.Ventas.Any(v => v.VentaId == id);
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

        public static List<Ventas> GetList(Expression<Func<Ventas, bool>> venta)
        {
            List<Ventas> Lista = new List<Ventas>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Ventas.Where(venta).Include(v => v.VentaDetalle).ToList();
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

        public static bool ContratoDisponible(Ventas ventas)
        {
            //verifica si el contrato ya esta utilizado
            if (ventas.VentaId != 0)
                return true;

            List<Ventas> lista = GetList(c => true);

            foreach (var item in lista)
            {

                if (item.VentaDetalle[0].ContratoId == ventas.VentaDetalle[0].ContratoId)
                    return false;
            }

            return true;
        }

        public static void RestarBalance(int id, decimal balance)
        {
            Ventas venta = Buscar(id);

            venta.Balance = balance;

            Modificar(venta);
        }

        public static void RestablecerBalance(int id)
        {
            Pagos pago = PagosBLL.Buscar(id);

            if (pago == null)
                return;

            Ventas venta = Buscar(pago.PagoDetalle[0].VentaId);

            venta.Balance = venta.Total;

            Modificar(venta);
        }
    }
}
