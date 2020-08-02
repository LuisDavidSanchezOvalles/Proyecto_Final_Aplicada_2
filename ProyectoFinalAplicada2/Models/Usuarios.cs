using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ProyectoFinalAplicada2.Validaciones;

namespace ProyectoFinalAplicada2.Models
{
    public class Usuarios
    {
        [Key]
        [Required(ErrorMessage = "Es obligatorio introducir el campo 'UsuarioId'")]
        [Range(0, 100000, ErrorMessage = "El id debe ser mayor o igual a cero.")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Fecha'")]
        [FechaValidacion]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Nombres'")]
        [NombresValidacion]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Nombre Usuario'")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Clave'")]
        public string Clave { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Email'")]
        [EmailAddress(ErrorMessage = "Email no valido")]
        public string Email { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioIdCreacion { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            NombreUsuario = string.Empty;
            Clave = string.Empty;
            Email = string.Empty;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioIdCreacion = 0;
        }
    }
}
