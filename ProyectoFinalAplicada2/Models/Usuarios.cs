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
        [IdValidacion]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir una fecha")]
        [FechaValidacion]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir un nombre")]
        [NombresValidacion]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir un nombre de usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir una clave")]
        public string Clave { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir un E-Mail")]
        [EmailValidacion]
        public string Email { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioIdCreacion { get; set; }
    }
}
