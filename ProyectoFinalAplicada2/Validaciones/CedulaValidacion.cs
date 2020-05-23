using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ProyectoFinalAplicada2.Validaciones
{
    public class CedulaValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cadena = value as string;

            if (cadena != null)
            {
                String expresion;
                expresion = @"^\d{3}[- ]?\d{7}[- ]?\d{1}$";
                if (Regex.IsMatch(cadena, expresion))
                {
                    if (Regex.Replace(cadena, expresion, String.Empty).Length == 0)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("Cedula no valida");
                    }
                }
                else
                    return new ValidationResult("Cedula no valida");
            }
            return new ValidationResult("Debes poner una Cedula");
        }
    }
}
