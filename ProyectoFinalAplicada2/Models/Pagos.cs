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
        [IdValidacion]
        public int PagoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir una fecha")]
        [FechaValidacion]
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("PagoId")]
        public virtual List<PagosDetalle> PagoDetalle { get; set; }
    }
}
