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

            bool paso = EntradasBLL.Guardar(e);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = EntradasBLL.Eliminar(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Entradas entrada = EntradasBLL.Buscar(1);

            Assert.IsNotNull(entrada);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Entradas> listaVenta = EntradasBLL.GetList(e => true);

            Assert.IsNotNull(listaVenta);
        }
    }
}