using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAplicada2.Models
{
    public class VentasDetalle
    {
        [Key]
        public int VentaDetalleId { get; set; }
        public int VentaId { get; set; }
        public int ContratoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }

        public VentasDetalle()
        {
            VentaDetalleId = 0;
            VentaId = 0;
            ContratoId = 0;
            Cantidad = 0;
            Precio = 0;
        }

        public VentasDetalle(int ventaId, int contratoId, decimal cantidad, decimal precio)
        {
            VentaDetalleId = 0;
            VentaId = ventaId;
            ContratoId = contratoId;
            Cantidad = cantidad;
            Precio = precio;
        }
    }
}
