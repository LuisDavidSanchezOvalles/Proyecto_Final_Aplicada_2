using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinalAplicada2.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinalAplicada2.Models;

namespace ProyectoFinalAplicada2.BLL.Tests
{
    [TestClass()]
    public class ClientesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Clientes cliente = new Clientes();

            cliente.ClienteId = 0;
            cliente.Fecha = DateTime.Now;
            cliente.Nombres = "Alfredo";
            cliente.Cedula = "234-6583756-9";
            cliente.Telefono = "809-422-2485";
            cliente.Celular = "829-573-5783";
            cliente.Direccion = "Los mellos";
            cliente.Email = "Angel@outlook.com";
            cliente.FechaCreacion = DateTime.Now;
            cliente.FechaModificacion = DateTime.Now;
            cliente.UsuarioId = 1;

            bool paso = ClientesBLL.Guardar(cliente);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = ClientesBLL.Eliminar(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Clientes cliente = ClientesBLL.Buscar(1);

            Assert.IsNotNull(cliente);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Clientes> listaCliente = ClientesBLL.GetList(c => true);

            Assert.IsNotNull(listaCliente);
        }
    }
}