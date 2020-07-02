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
        [IdValidacion]
        public int SuplidorId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Fecha'")]
        [FechaValidacion]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Nombre'")]
        [NombresValidacion]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Dirección'")]
        [Range(3,30)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Email'")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Telefono'")]
        [TelefonoValidacion]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Celular'")]
        [CelularValidacion]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Cedula'")]
        [CedulaValidacion]
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
