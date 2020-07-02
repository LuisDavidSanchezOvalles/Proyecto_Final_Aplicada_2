using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ProyectoFinalAplicada2.Validaciones;

namespace ProyectoFinalAplicada2.Models
{
    public class Contratos
    {
        [Key]
        [IdValidacion]
        public int ContratoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Fecha'")]
        [FechaValidacion]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'ClienteId'")]
        [IdValidacion]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'FechaVencimiento'")]
        [FechaVencimientoValidacion]
        public DateTime FechaVencimiento { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'CacaoId'")]
        [IdValidacion]
        public int CacaoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo ''")]
        [CantidadValidacion]
        public decimal Cantidad { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Precio'")]
        [PrecioValidacion]
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
        public decimal CantidadPendiente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("ContratoId")]
        public virtual List<VentasDetalle> VentaDetalle { get; set; }

        public Contratos()
        {
            ContratoId = 0;
            Fecha = DateTime.Now;
            ClienteId = 0;
            FechaVencimiento = DateTime.Now;
            CacaoId = 0;
            Cantidad = 0.0m;
            Precio = 0.0m;
            Total = 0.0m;
            CantidadPendiente = 0.0m;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioId = 0;

            VentaDetalle = new List<VentasDetalle>();
        }

        public Contratos(int contratoId, DateTime fecha, int clienteId, DateTime fechaVencimiento, int cacaoId, decimal cantidad, decimal precio, decimal total, decimal cantidadPendiente, DateTime fechaCreacion, DateTime fechaModificacion, int usuarioId, List<VentasDetalle> ventaDetalle)
        {
            ContratoId = contratoId;
            Fecha = fecha;
            ClienteId = clienteId;
            FechaVencimiento = fechaVencimiento;
            CacaoId = cacaoId;
            Cantidad = cantidad;
            Precio = precio;
            Total = total;
            CantidadPendiente = cantidadPendiente;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
            UsuarioId = usuarioId;
            VentaDetalle = ventaDetalle;
        }
    }
}
