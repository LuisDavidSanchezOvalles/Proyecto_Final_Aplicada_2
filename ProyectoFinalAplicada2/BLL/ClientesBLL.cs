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
    public class ClientesBLL
    {
        public static bool Guardar(Clientes cliente)
        {
            if (!Existe(cliente.ClienteId))
                return Insertar(cliente);
            else
                return Modificar(cliente);
        }

        private static bool Insertar(Clientes cliente)
        {
            if (cliente.ClienteId != 0)
                return false;

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Clientes.Add(cliente) != null)
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

        private static bool Modificar(Clientes cliente)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(cliente).State = EntityState.Modified;
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
                var cliente = contexto.Clientes.Find(id);
                if(cliente != null)
                {
                    contexto.Clientes.Remove(cliente);
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

        public static Clientes Buscar(int id)
        {
            Clientes cliente = new Clientes();
            Contexto contexto = new Contexto();

            try
            {
                cliente = contexto.Clientes.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return cliente;
        }

        private static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Clientes.Any(c => c.ClienteId == id);
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

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> cliente)
        {
            List<Clientes> Lista = new List<Clientes>();
            Contexto contexto = new Contexto();
            try
            {
                Lista = contexto.Clientes.Where(cliente).ToList();
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
    }
}
