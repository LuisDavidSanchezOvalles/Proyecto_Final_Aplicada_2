using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ProyectoFinalAplicada2.Validaciones;

namespace ProyectoFinalAplicada2.Models
{
    public class Entradas
    {
        [Key]
        [Required(ErrorMessage = "Es obligatorio introducir el campo 'EntradaId'")]
        [Range(0, 100000, ErrorMessage = "El id debe ser mayor o igual a cero.")]
        public int EntradaId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Fecha'")]
        [FechaValidacion]
        public DateTime Fecha { get; set; }

        public int SuplidorId { get; set; }

        public int CacaoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Cantidad'")]
        [Range(0.1, 100000, ErrorMessage = "La cantidad debe ser mayor que cero.")]
        public decimal Cantidad { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el campo 'Costo'")]
        [Range(0.1, 100000, ErrorMessage = "El costo debe ser mayor que cero.")]
        public decimal Costo { get; set; }

        public decimal Total { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioId { get; set; }

        public Entradas()
        {
            EntradaId = 0;
            Fecha = DateTime.Now;
            SuplidorId = 0;
            CacaoId = 0;
            Cantidad = 0;
            Costo = 0;
            Total = 0;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioId = 0;
        }

        public Entradas(int entradaId, DateTime fecha, int suplidorId, int cacaoId, decimal cantidad, decimal costo, decimal total, DateTime fechaCreacion, DateTime fechaModificacion, int usuarioId)
        {
            EntradaId = entradaId;
            Fecha = fecha;
            SuplidorId = suplidorId;
            CacaoId = cacaoId;
            Cantidad = cantidad;
            Costo = costo;
            Total = total;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
            UsuarioId = usuarioId;
        }
    }
}
