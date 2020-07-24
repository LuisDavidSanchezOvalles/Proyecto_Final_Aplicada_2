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

        public static bool ExisteAlgunCacao()
        {
            List<Cacaos> cacaos = GetList(c => true);

            if (cacaos.Count > 0)
                return true;
            else
                return false;
        }

        public static void ActualizarCacao(int id, decimal cantidad, decimal costo)
        {
            Cacaos cacao = Buscar(id);

            cacao.Cantidad += cantidad;
            cacao.Costo = costo;

            Modificar(cacao);
        }

        public static bool ContratarCacao(Contratos contrato)
        {
            Contratos AnteriorContrato = ContratosBLL.Buscar(contrato.ContratoId);
            Cacaos cacao;

            if(AnteriorContrato == null)
            {
                cacao = Buscar(contrato.CacaoId);

                cacao.Cantidad -= contrato.Cantidad;
            }
            else
            {
                decimal diferenciaCantidad = AnteriorContrato.Cantidad - contrato.Cantidad;

                cacao = Buscar(contrato.CacaoId);

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

        public static void DevolverCacao(int contratoId, int cacaoId)
        {
            Contratos contrato = ContratosBLL.Buscar(contratoId);
            Cacaos cacao = Buscar(cacaoId);

            if (cacao == null)
                return;

            cacao.Cantidad += contrato.Cantidad;

            Modificar(cacao);
        }

        public static bool cacaoDisponible()
        {
            List<Cacaos> cacaos = GetList(c => true);

            foreach (var item in cacaos)
            {
                if (item.Cantidad > 0)
                    return true;
            }

            return false;
        }
    }
}
