using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinalAplicada2.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinalAplicada2.Models;

namespace ProyectoFinalAplicada2.BLL.Tests
{
    [TestClass()]
    public class SuplidoresBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Suplidores s = new Suplidores();
            s.SuplidorId = 0;
            s.Fecha = DateTime.Now;
            s.Nombres = "Luis David Sánchez Ovalles";
            s.Direccion = "Duarte ";
            s.Email = "luisdavidsanchez149@gmail.com";
            s.Telefono = "8295678989";
            s.Celular = "8095667788";
            s.Cedula = "40278989911";
            s.FechaCreacion = DateTime.Now;
            s.FechaModificacion = DateTime.Now;
            s.UsuarioId = 1;

            bool paso = SuplidoresBLL.Guardar(s);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = SuplidoresBLL.Eliminar(1);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Suplidores suplidor = SuplidoresBLL.Buscar(1);

            Assert.IsNotNull(suplidor);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Suplidores> listaSuplidor = SuplidoresBLL.GetList(s => true);

            Assert.IsNotNull(listaSuplidor);
        }
    }
}