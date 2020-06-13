using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ProyectoFinalAplicada2.Validaciones;

namespace ProyectoFinalAplicada2.Models
{
    public class Clientes
    {
        [Key]
        [IdValidacion]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir una fecha")]
        [FechaValidacion]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir un nombre")]
        [NombresValidacion]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir una cédula")]
        [CedulaValidacion]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir un teléfono")]
        [TelefonoValidacion]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir un celular")]
        [CelularValidacion]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir una dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir un E-Mail")]
        [EmailValidacion]
        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioId { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            Cedula = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Direccion = string.Empty;
            Email = string.Empty;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioId = 0;
        }
    }
}
