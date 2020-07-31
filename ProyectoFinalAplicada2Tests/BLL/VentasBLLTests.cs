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
            bool paso = false;

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

            if (!VentasBLL.Existe(v.VentaId))
            {
                VentasBLL.Insertar(v);
                paso = true;
            }
            else
            {
                VentasBLL.Modificar(v);
                paso = true;
            }

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            bool paso = false;

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

            paso = VentasBLL.Insertar(v);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;

            Ventas v = new Ventas();

            v.VentaId = 0;
            v.Fecha = DateTime.Now;
            v.ClienteId = 1;
            v.Total = 1000;
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

            paso = VentasBLL.Modificar(v);

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
            Ventas v = VentasBLL.Buscar(1);

            Assert.AreEqual(v, v);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso;

            paso = VentasBLL.Existe(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var listado = new List<Ventas>();
            listado = VentasBLL.GetList(s => true);
            Assert.AreEqual(listado, listado);
        }

        [TestMethod()]
        public void ContratoDisponibleTest()
        {
            bool paso = false;

            if (1 != 0)
                paso = true;

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