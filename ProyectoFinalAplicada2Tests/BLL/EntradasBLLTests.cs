using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinalAplicada2.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinalAplicada2.Models;

namespace ProyectoFinalAplicada2.BLL.Tests
{
    [TestClass()]
    public class EntradasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Entradas e = new Entradas();
            e.EntradaId = 0;
            e.Fecha = DateTime.Now;
            e.SuplidorId = 1;
            e.CacaoId = 1;
            e.Cantidad = 500;
            e.Total = 500;
            e.FechaCreacion = DateTime.Now;
            e.FechaModificacion = DateTime.Now;
            e.UsuarioId = 1;

            if (!EntradasBLL.Existe(e.EntradaId))
            {
                EntradasBLL.Insertar(e);
                paso = true;
            }
            else
            {
                EntradasBLL.Modificar(e);
                paso = true;
            }

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            bool paso;
            Entradas e = new Entradas();
            e.EntradaId = 0;
            e.Fecha = DateTime.Now;
            e.SuplidorId = 1;
            e.CacaoId = 1;
            e.Cantidad = 500;
            e.Total = 500;
            e.FechaCreacion = DateTime.Now;
            e.FechaModificacion = DateTime.Now;
            e.UsuarioId = 1;

            paso = EntradasBLL.Insertar(e);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Entradas e = new Entradas();
            e.EntradaId = 1;
            e.Fecha = DateTime.Now;
            e.SuplidorId = 1;
            e.CacaoId = 1;
            e.Cantidad = 500;
            e.Total = 600;
            e.FechaCreacion = DateTime.Now;
            e.FechaModificacion = DateTime.Now;
            e.UsuarioId = 1;
            paso = EntradasBLL.Modificar(e);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = EntradasBLL.Eliminar(1);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Entradas e = new Entradas();
            e = EntradasBLL.Buscar(2);

            Assert.AreEqual(e, e);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso;

            paso = EntradasBLL.Existe(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var listado = new List<Entradas>();
            listado = EntradasBLL.GetList(e => true);
            Assert.AreEqual(listado, listado);
        }
    }
}