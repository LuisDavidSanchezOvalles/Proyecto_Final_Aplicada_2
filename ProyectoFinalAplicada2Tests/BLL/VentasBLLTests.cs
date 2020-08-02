using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinalAplicada2.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinalAplicada2.Models;

namespace ProyectoFinalAplicada2.BLL.Tests
{
    [TestClass()]
    public class VentasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Ventas v = new Ventas();

            v.VentaId = 1;
            v.Fecha = DateTime.Now;
            v.ClienteId = 1;
            v.Total = 100;
            v.Balance = 100;
            v.FechaCreacion = DateTime.Now;
            v.FechaModificacion = DateTime.Now;
            v.UsuarioId = 1;
            v.VentaDetalle.Add(new VentasDetalle
            {
                VentaDetalleId = 0,
                VentaId = v.VentaId,
                ContratoId = 1,
                Cantidad = 500,
                Precio = 300,
            });

            bool paso = VentasBLL.Guardar(v);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            paso = VentasBLL.Eliminar(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Ventas venta = VentasBLL.Buscar(1);

            Assert.IsNotNull(venta);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Ventas> listaVenta = VentasBLL.GetList(v => true);

            Assert.IsNotNull(listaVenta);
        }

        [TestMethod()]
        public void ContratoDisponibleTest()
        {
            Ventas venta = VentasBLL.Buscar(1);

            bool paso = VentasBLL.ContratoDisponible(venta);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void RestarBalanceTest()
        {
            bool paso = false;

            decimal balance;

            Ventas v = VentasBLL.Buscar(1);

            balance = v.Balance;

            VentasBLL.RestarBalance(v.VentaId, 300);

            if (balance < v.Balance)
                paso = true;

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void RestablecerBalanceTest()
        {
            bool paso = false;

            decimal balance;

            Ventas v = VentasBLL.Buscar(1);

            balance = v.Balance;

            VentasBLL.RestablecerBalance(v.VentaId);

            if (balance > v.Balance)
                paso = true;

            Assert.IsTrue(paso);
        }
    }
}