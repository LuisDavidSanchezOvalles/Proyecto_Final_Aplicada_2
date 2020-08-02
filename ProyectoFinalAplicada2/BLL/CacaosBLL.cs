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
    public class CacaosBLL
    {
        public static bool Guardar(Cacaos cacao)
        {
            if (!Existe(cacao.CacaoId))
                return Insertar(cacao);
            else
                return Modificar(cacao);
        }

        private static bool Insertar(Cacaos cacao)
        {
            if (cacao.CacaoId != 0)
                return false;

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Cacaos.Add(cacao) != null)
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

        private static bool Modificar(Cacaos cacao)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(cacao).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
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
                var cacao = contexto.Cacaos.Find(id);
                if(cacao != null)
                {
                    List<Entradas> entradas = EntradasBLL.GetList(e => e.CacaoId == id);

                    foreach (var item in entradas)
                    {
                        EntradasBLL.Eliminar(item.EntradaId);
                    }

                    contexto.Cacaos.Remove(cacao);
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

        public static Cacaos Buscar(int id)
        {
            Cacaos cacao = new Cacaos();
            Contexto contexto = new Contexto();

            try
            {
                cacao = contexto.Cacaos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return cacao;
        }

        private static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Cacaos.Any(c => c.CacaoId == id);
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

        public static List<Cacaos> GetList(Expression<Func<Cacaos, bool>> cacao)
        {
            List<Cacaos> Lista = new List<Cacaos>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Cacaos.Where(cacao).ToList();
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

        public static bool ActualizarCacao(Entradas entrada)
        {
            Entradas AnteriorEntrada = EntradasBLL.Buscar(entrada.EntradaId);
            Cacaos cacao = Buscar(entrada.CacaoId);

            if(AnteriorEntrada == null)
            {
                cacao.Cantidad += entrada.Cantidad;
                cacao.Costo = entrada.Costo;
            }
            else
            {
                decimal diferenciaCantidad = entrada.Cantidad - AnteriorEntrada.Cantidad;

                cacao.Cantidad += diferenciaCantidad;
                cacao.Costo = entrada.Costo;

                if (cacao.Cantidad <= 0)
                    return false;
            }

            Modificar(cacao);
            return true;
        }

        public static bool VenderCacao(Ventas venta)
        {
            Ventas AnteriorVenta = VentasBLL.Buscar(venta.VentaId);
            Contratos contrato = ContratosBLL.Buscar(venta.VentaDetalle[0].ContratoId);
            Cacaos cacao = Buscar(contrato.CacaoId);

            decimal cantidad = 0, anteriorCantidad = 0;

            foreach(var item in venta.VentaDetalle)
            {
                cantidad += item.Cantidad;
            }

            if (AnteriorVenta == null)
            {
                cacao.Cantidad -= cantidad;
            }
            else
            {
                foreach (var item in AnteriorVenta.VentaDetalle)
                {
                    anteriorCantidad += item.Cantidad;
                }

                decimal diferenciaCantidad = anteriorCantidad - cantidad;

                cacao.Cantidad += diferenciaCantidad;
            }

            if (cacao.Cantidad >= 0)
            {
                Modificar(cacao);
                return true;
            }
            else
                return false;
        }

        public static void DevolverCacao(int id)
        {
            Ventas venta = VentasBLL.Buscar(id);

            if (venta == null)
                return;

            Contratos contrato = ContratosBLL.Buscar(venta.VentaDetalle[0].ContratoId);
            Cacaos cacao = Buscar(contrato.CacaoId);

            if (cacao == null)//por si no existe el cacao para devolverle
                return;

            decimal cantidad = 0;

            foreach(var item in venta.VentaDetalle)
            {
                cantidad += item.Cantidad;
            }

            cacao.Cantidad += cantidad;

            Modificar(cacao);
        }
    }
}
