using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinalAplicada2.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinalAplicada2.Models;

namespace ProyectoFinalAplicada2.BLL.Tests
{
    [TestClass()]
    public class PagosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Pagos pago = new Pagos();

            pago.PagoId = 0;
            pago.Fecha = DateTime.Now;
            pago.ClienteId = 1;
            pago.Total = 800.0m;
            pago.UsuarioId = 1;
            pago.FechaCreacion = DateTime.Now;
            pago.FechaModificacion = DateTime.Now;
            pago.PagoDetalle.Add(new PagosDetalle
            { 
                PagoDetalleId =  0,
                PagoId = 0,
                VentaId = 1,
                Monto = 800.0m, 
                Saldo = 400.0m 
            });

            bool paso = PagosBLL.Guardar(pago);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = PagosBLL.Eliminar(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Pagos pago = PagosBLL.Buscar(1);

            Assert.IsNotNull(pago);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Pagos> listaPago = PagosBLL.GetList(p => true);

            Assert.IsNotNull(listaPago);
        }

        [TestMethod()]
        public void VentaDisponibleTest()
        {
            Pagos pago = PagosBLL.Buscar(1);

            bool paso = PagosBLL.VentaDisponible(pago);

            Assert.IsTrue(paso);
        }
    }
}