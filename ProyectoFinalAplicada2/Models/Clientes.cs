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
        [Required(ErrorMessage = "Es obligatorio introducir el campo 'ClienteId'")]
        [Range(0, 100000, ErrorMessage = "El id debe ser mayor o igual a cero.")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Fecha'")]
        [FechaValidacion]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Nombres'")]
        [NombresValidacion]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Cédula'")]
        [RegularExpression(@"^\d{3}[- ]?\d{7}[- ]?\d{1}$", ErrorMessage = "Cédula no valida")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Teléfono'")]
        [RegularExpression(@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$", ErrorMessage = "Teléfono no valido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Celular'")]
        [RegularExpression(@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$", ErrorMessage = "Celular no valido")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Dirección'")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Email'")]
        [EmailAddress(ErrorMessage = "Email no valido")]
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
