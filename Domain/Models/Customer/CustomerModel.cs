using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.ICustomerContracts;

namespace Domain.Models.Customer
{
    public class CustomerModel : ICustomer
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Nombre Requerido")]
        [StringLength(maximumLength: 50, MinimumLength = 4, ErrorMessage = "Nombre debe tener entre 4 a 50 caracteres")]
        public string name { get; set; }

        [Required(ErrorMessage = "Apellido Requerido")]
        [StringLength(maximumLength: 50, MinimumLength = 4, ErrorMessage = "Apellido debe tener entre 4 a 50 caracteres")]
        public string lastname { get; set; }

        [Required(ErrorMessage = "Email Requerido")]
        [EmailAddress(ErrorMessage = "No es un correo electronico Valido")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Email debe tener entre 2 a 100 caracteres")]
        public string email { get; set; }

        [Required(ErrorMessage = "DNI Requerido")]
        [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "DNI Debe tener 10 digitos")]
        public string dni { get; set; }

        [Required(ErrorMessage = "Password Requerido")]
        public string password { get; set; }
    }
}
