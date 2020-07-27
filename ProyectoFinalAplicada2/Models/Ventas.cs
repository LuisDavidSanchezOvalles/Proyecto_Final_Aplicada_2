using ProyectoFinalAplicada2.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAplicada2.Models
{
    public class Ventas
    {
        [Key]
        [IdValidacion]
        public int VentaId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Fecha'")]
        [FechaValidacion]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'ClienteId'")]
        [IdValidacion]
        public int ClienteId { get; set; }
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("VentaId")]
        public virtual List<VentasDetalle> VentaDetalle { get; set; }

        [ForeignKey("VentaId")]
        public virtual List<PagosDetalle> PagoDetalle { get; set; }

        public Ventas()
        {
            VentaId = 0;
            Fecha = DateTime.Now;
            ClienteId = 0;
            Total = 0.0m;
            Balance = 0.0m;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioId = 0;

            VentaDetalle = new List<VentasDetalle>();
            PagoDetalle = new List<PagosDetalle>();
        }
    }
}
