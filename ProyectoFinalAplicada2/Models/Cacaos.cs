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
        [IdValidacion]
        public int CacaoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir una fecha")]
        [FechaValidacion]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir un tipo")]
        public string Tipo { get; set; }

        public decimal Cantidad { get; set; }

        public decimal Costo { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir un precio")]
        [PrecioValidacion]
        public decimal Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioId { get; set; }

        public Cacaos()
        {
            CacaoId = 0;
            Fecha = DateTime.Now;
            Tipo = string.Empty;
            Cantidad = 0.0m;
            Costo = 0.0m;
            Precio = 0.0m;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioId = 0;
        }
    }
}
