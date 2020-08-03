using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ProyectoFinalAplicada2.Validaciones;

namespace ProyectoFinalAplicada2.Models
{
    public class Cacaos
    {
        [Key]
        [Required(ErrorMessage = "Es obligatorio introducir el campo 'CacaoId'")]
        [Range(0, 2000000, ErrorMessage = "El id debe ser mayor o igual a cero.")]
        public int CacaoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Fecha'")]
        [FechaValidacion]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Tipo'")]
        public string Tipo { get; set; }

        public decimal Cantidad { get; set; }

        public decimal Costo { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Precio'")]
        [Range(0.1, 10000000, ErrorMessage = "El precio debe ser mayor que cero.")]
        public decimal Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioId { get; set; }

        public Cacaos()
        {
            CacaoId = 0;
            Fecha = DateTime.Now;
            Tipo = string.Empty;
            Cantidad = 0;
            Costo = 0;
            Precio = 0;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioId = 0;
        }
    }
}
