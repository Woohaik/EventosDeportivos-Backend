using Domain.Models.ICustomerContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Customer
{
    public class CredentialModel : ICredential
    {


        [Required(ErrorMessage = "Email Requerido")]
        [EmailAddress(ErrorMessage = "No es un correo electronico Valido")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Email debe tener entre 2 a 100 caracteres")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password Requerido")]
        public string password { get; set; }
    }
}
