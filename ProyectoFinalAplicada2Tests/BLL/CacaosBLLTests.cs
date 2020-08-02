using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinalAplicada2.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinalAplicada2.Models;

namespace ProyectoFinalAplicada2.BLL.Tests
{
    [TestClass()]
    public class CacaosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Cacaos cacao = new Cacaos();

            cacao.CacaoId = 0;
            cacao.Fecha = DateTime.Now;
            cacao.Tipo = "Sanchéz";
            cacao.Cantidad = 0.0m;
            cacao.Costo = 0.0m;
            cacao.Precio = 500.0m;
            cacao.FechaCreacion = DateTime.Now;
            cacao.FechaModificacion = DateTime.Now;
            cacao.UsuarioId = 1;

            bool paso = CacaosBLL.Guardar(cacao);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = CacaosBLL.Eliminar(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Cacaos cacao = CacaosBLL.Buscar(1);

            Assert.IsNotNull(cacao);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Cacaos> listaCacao = CacaosBLL.GetList(c => true);

            Assert.IsNotNull(listaCacao);
        }

        [TestMethod()]
        public void ActualizarCacaoTest()
        {
            Cacaos cacao = CacaosBLL.Buscar(1);
            Entradas entrada = EntradasBLL.Buscar(1);

            decimal cantidad = cacao.Cantidad;

            CacaosBLL.ActualizarCacao(entrada);

            cacao = CacaosBLL.Buscar(1);

            Assert.IsTrue(cantidad + entrada.Cantidad == cacao.Cantidad && cacao.Costo == entrada.Costo);
        }

        [TestMethod()]
        public void VenderCacaoTest()
        {
            Cacaos cacao = CacaosBLL.Buscar(1);
            Ventas venta = VentasBLL.Buscar(1);

            decimal cantidad = cacao.Cantidad;
            decimal cantidadVenta = 0;

            foreach(var item in venta.VentaDetalle)
            {
                cantidadVenta += item.Cantidad;
            }

            CacaosBLL.VenderCacao(venta);

            cacao = CacaosBLL.Buscar(1);

            Assert.IsTrue(cantidad + cantidadVenta == cacao.Cantidad);
        }

        [TestMethod()]
        public void DevolverCacaoTest()
        {
            Cacaos cacao = CacaosBLL.Buscar(1);
            Ventas venta = VentasBLL.Buscar(1);

            decimal cantidad = cacao.Cantidad;
            decimal cantidadVenta = 0;

            foreach (var item in venta.VentaDetalle)
            {
                cantidadVenta += item.Cantidad;
            }

            CacaosBLL.DevolverCacao(1);

            cacao = CacaosBLL.Buscar(1);

            Assert.IsTrue(cantidad + cantidadVenta == cacao.Cantidad);
        }
    }
}