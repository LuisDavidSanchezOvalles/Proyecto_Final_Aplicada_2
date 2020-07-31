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
            bool paso = false;
            Suplidores s = new Suplidores();
            s.SuplidorId = 0;
            s.Fecha = DateTime.Now;
            s.Nombres = "Luis David";
            s.Direccion = " Duarte ";
            s.Email = "ag@dn.com";
            s.Telefono = " 829566 ";
            s.Celular = "33333333";
            s.Cedula = " 056 ";
            s.FechaCreacion = DateTime.Now;
            s.FechaModificacion = DateTime.Now;
            s.UsuarioId = 1;

            if (!SuplidoresBLL.Existe(s.SuplidorId))
            {
                SuplidoresBLL.Insertar(s);
                paso = true;
            }
            else
            {
                SuplidoresBLL.Modificar(s);
                paso = true;
            }

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            bool paso;
            Suplidores s = new Suplidores();
            s.SuplidorId = 0;
            s.Fecha = DateTime.Now;
            s.Nombres = "Luis David";
            s.Direccion = " Duarte ";
            s.Email = "ag@dn.com";
            s.Telefono = " 829566 ";
            s.Celular = "33333333";
            s.Cedula = " 056 ";
            s.FechaCreacion = DateTime.Now;
            s.FechaModificacion = DateTime.Now;
            s.UsuarioId = 1;
            paso = SuplidoresBLL.Insertar(s);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;

            Suplidores s = new Suplidores();
            s.SuplidorId = 1;
            s.Fecha = DateTime.Now;
            s.Nombres = "Luis David";
            s.Direccion = " Duarte ";
            s.Email = "Klk@outlook.com";
            s.Telefono = " 829566 ";
            s.Celular = "33333333";
            s.Cedula = " 056 ";
            s.FechaCreacion = DateTime.Now;
            s.FechaModificacion = DateTime.Now;
            s.UsuarioId = 1;

            paso = SuplidoresBLL.Modificar(s);

            Assert.AreEqual(paso, true);
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
            Suplidores s = new Suplidores();
            s = SuplidoresBLL.Buscar(2);

            Assert.AreEqual(s, s);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso;

            paso = SuplidoresBLL.Existe(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var listado = new List<Suplidores>();
            listado = SuplidoresBLL.GetList(s => true);
            Assert.AreEqual(listado, listado);
        }
    }
}