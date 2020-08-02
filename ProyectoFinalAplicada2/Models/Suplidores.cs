using ProyectoFinalAplicada2.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAplicada2.Models
{
    public class Suplidores
    {
        [Key]
        [Required(ErrorMessage = "Es obligatorio introducir el campo 'SuplidorId'")]
        [Range(0, 100000, ErrorMessage = "El id debe ser mayor o igual a cero.")]
        public int SuplidorId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Fecha'")]
        [FechaValidacion]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Nombre'")]
        [NombresValidacion]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Dirección'")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Email'")]
        [EmailValidacion]
        public string Email { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Teléfono'")]
        [RegularExpression(@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$", ErrorMessage = "Teléfono no valido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Celular'")]
        [RegularExpression(@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$", ErrorMessage = "Celular no valido")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Cédula'")]
        [RegularExpression(@"^\d{3}[- ]?\d{7}[- ]?\d{1}$", ErrorMessage = "Cédula no valida")]
        public string Cedula { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioId { get; set; }

        public Suplidores()
        {
            SuplidorId = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            Direccion = string.Empty;
            Email = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Cedula = string.Empty;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioId = 0;
        }

        public Suplidores(int suplidorId, DateTime fecha, string nombres, string direccion, string email, string telefono, string celular, string cedula, DateTime fechaCreacion, DateTime fechaModificacion, int usuarioId)
        {
            SuplidorId = suplidorId;
            Fecha = fecha;
            Nombres = nombres;
            Direccion = direccion;
            Email = email;
            Telefono = telefono;
            Celular = celular;
            Cedula = cedula;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
            UsuarioId = usuarioId;
        }
    }
}
