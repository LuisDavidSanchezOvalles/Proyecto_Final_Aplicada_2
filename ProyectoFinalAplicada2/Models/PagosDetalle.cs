using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAplicada2.Models
{
    public class PagosDetalle
    {
        [Key]
        public int PagoDetalleId { get; set; }
        public int PagoId { get; set; }
        public int VentaId { get; set; }
        public decimal Monto { get; set; }
        public decimal Saldo { get; set; }
    }
}
