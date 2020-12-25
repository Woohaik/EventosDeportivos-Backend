using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Api.Validators
{
    public class AnotationValidator<T>
    {
        public void validate(T toValidate)
        {
            List<Exception> errores = new List<Exception>();
            ValidationContext validationContext = new ValidationContext(toValidate, null, null);
            List<ValidationResult> errors = new List<ValidationResult>();
            Validator.TryValidateObject(toValidate, validationContext, errors, true);
            if (errors.Count() > 0)
            {
                errors.ForEach(err => errores.Add(new Exception(err.ErrorMessage)));
                throw new AggregateException(errores);
            }
        }

    }
}