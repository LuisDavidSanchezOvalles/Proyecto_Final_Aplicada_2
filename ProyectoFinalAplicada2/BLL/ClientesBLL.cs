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

        public static bool Insertar(Clientes cliente)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Clientes.Add(cliente) != null)
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

        public static bool Modificar(Clientes cliente)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(cliente).State = EntityState.Modified;
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
        public static Clientes Buscar(int id)
        {
            Clientes cliente = new Clientes();
            Contexto db = new Contexto();
            try
            {
                cliente = db.Clientes.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return cliente;
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();

            try
            {
                encontrado = db.Clientes.Any(c => c.ClienteId == id);
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

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> cliente)
        {
            List<Clientes> Lista = new List<Clientes>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Clientes.Where(cliente).ToList();
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

        public static bool ExisteCliente()
        {
            List<Clientes> clientes = GetList(c => true);

            if (clientes.Count > 0)
                return true;
            else
                return false;
        }
    }
}
