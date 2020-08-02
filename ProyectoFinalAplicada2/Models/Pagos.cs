using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProyectoFinalAplicada2.Validaciones;

namespace ProyectoFinalAplicada2.Models
{
    public class Pagos
    {
        [Key]
        [Required(ErrorMessage = "Es obligatorio introducir el campo 'PagoId'")]
        [Range(0, 100000, ErrorMessage = "El id debe ser mayor o igual a cero.")]
        public int PagoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Fecha'")]
        [FechaValidacion]
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("PagoId")]
        public virtual List<PagosDetalle> PagoDetalle { get; set; }

        public Pagos()
        {
            PagoId = 0;
            Fecha = DateTime.Now;
            ClienteId = 0;
            Total = 0;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioId = 0;

            PagoDetalle = new List<PagosDetalle>();
        }
    }
}
