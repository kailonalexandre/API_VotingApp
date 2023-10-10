using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos
{
    public class LoginDto
    {
        [Required (ErrorMessage = "Email é um campo obrigatório para Login")]
        [EmailAddress (ErrorMessage = "Email em formato invalido")]
        [StringLength(100, ErrorMessage ="Email deve ter no maximo {1} caracteres")]
        public string Email { get; set; }
    }
}
