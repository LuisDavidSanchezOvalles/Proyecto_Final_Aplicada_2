using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAplicada2.Validaciones
{
    public class FechaVencimientoValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime fecha = new DateTime();
                DateTime.TryParse(value.ToString(), out fecha);

                if (fecha < DateTime.Now)//verificar
                    return new ValidationResult("Debes poner una Fecha valida");

                return ValidationResult.Success;

            }
            return new ValidationResult("Debes poner una Fecha");
        }
    }
}
