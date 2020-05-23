using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ProyectoFinalAplicada2.Validaciones
{
    public class EmailValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cadena = value as string;

            if (cadena != null)
            {
                String expresion;
                expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                if (Regex.IsMatch(cadena, expresion))
                {
                    if (Regex.Replace(cadena, expresion, String.Empty).Length == 0)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("Email no valido");
                    }
                }
                else
                    return new ValidationResult("Email no valido");
            }
            return new ValidationResult("Debes poner un email");
        }
    }
}
