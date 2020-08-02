using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinalAplicada2.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinalAplicada2.Models;
using System.Drawing.Printing;

namespace ProyectoFinalAplicada2.BLL.Tests
{
    [TestClass()]
    public class UsuariosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Usuarios usuarios = new Usuarios();

            usuarios.UsuarioId = 0;
            usuarios.Fecha = DateTime.Now;
            usuarios.Nombres = "Jose Alfonso";
            usuarios.NombreUsuario = "Josh";
            usuarios.Clave = "clave";
            usuarios.Email = "JA@outlook.com";
            usuarios.FechaCreacion = DateTime.Now;
            usuarios.FechaModificacion = DateTime.Now;
            usuarios.UsuarioIdCreacion = 1;

            bool paso = UsuariosBLL.Guardar(usuarios);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void EncriptarTest()
        {
            string cadena = UsuariosBLL.Encriptar("prueba");

            Assert.IsTrue(cadena != string.Empty);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = UsuariosBLL.Eliminar(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Usuarios usuario = UsuariosBLL.Buscar(1);

            Assert.IsNotNull(usuario);
        }

        [TestMethod()]
        public void DesEncriptarTest()
        {
            string cadena = UsuariosBLL.DesEncriptar("YYCkAG0BaQBuAAcB");

            Assert.IsTrue(cadena != string.Empty);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Usuarios> listaUsuario = UsuariosBLL.GetList(u => true);

            Assert.IsNotNull(listaUsuario);
        }

        [TestMethod()]
        public void ExisteUsuarioTest()
        {
            bool paso = UsuariosBLL.ExisteUsuario("admin", "admin");

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ObtenerUsuarioIdTest()
        {
            string id = UsuariosBLL.ObtenerUsuarioId("admin", "admin");

            Assert.AreEqual(id, "1");
        }
    }
}