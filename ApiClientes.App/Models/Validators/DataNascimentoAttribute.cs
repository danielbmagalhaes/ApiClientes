using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiClientes.App.Models.Validators
{
    public class DataNascimentoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            if (value == null){ return new ValidationResult("Informe uma data de nascimento.", new[] { validationContext.DisplayName }); }
			else if (((DateTime)value) <= DateTime.Now.AddYears(-120) || ((DateTime)value) >= DateTime.Now) { return new ValidationResult("Informe uma data de nascimento válida.", new[] { validationContext.DisplayName });  }
            else { return ValidationResult.Success; }

        }

	}
}
