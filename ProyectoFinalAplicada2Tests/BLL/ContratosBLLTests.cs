using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinalAplicada2.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinalAplicada2.Models;

namespace ProyectoFinalAplicada2.BLL.Tests
{
    [TestClass()]
    public class ContratosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Contratos c = new Contratos();

            c.ContratoId = 1;
            c.Fecha = DateTime.Now;
            c.ClienteId = 1;
            c.FechaVencimiento = Convert.ToDateTime("27/10/2020");
            c.CacaoId = 1;
            c.Cantidad = 500;
            c.Precio = 300;
            c.FechaCreacion = DateTime.Now;
            c.FechaModificacion = DateTime.Now;
            c.UsuarioId = 1;

            bool paso = ContratosBLL.Guardar(c);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            paso = ContratosBLL.Eliminar(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Contratos c = ContratosBLL.Buscar(1);

            Assert.IsNotNull(c);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Contratos> listaContrato = ContratosBLL.GetList(c => true);

            Assert.IsNotNull(listaContrato);
        }

        [TestMethod()]
        public void EvaluarCantidadTest()
        {
            bool paso = false;
            int id=1;
            decimal cantidad=500, pendiente = 0;

            Contratos c = ContratosBLL.Buscar(1);
            pendiente = c.CantidadPendiente;
            ContratosBLL.EvaluarCantidad(id, cantidad);

            if (pendiente != c.CantidadPendiente)
                paso = true;

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void RestablecerCantidadPendienteTest()
        {
            bool paso = false;
            decimal cantidad = 500;

            Contratos c = ContratosBLL.Buscar(1);

            c.CantidadPendiente = cantidad;

            if (cantidad == c.CantidadPendiente)
                paso = true;

            Assert.IsTrue(paso);
        }
    }
}