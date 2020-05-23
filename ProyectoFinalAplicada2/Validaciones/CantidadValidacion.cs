using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAplicada2.Validaciones
{
    public class CantidadValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                decimal cantidad = Convert.ToDecimal(value);

                if (cantidad >= 0.1m)
                    return ValidationResult.Success;
                else
                    return new ValidationResult("La cantidad debe mayor o igual a 0.1");

            }
            return new ValidationResult("Debes poner una cantidad");
        }
    }
}
