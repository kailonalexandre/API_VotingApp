using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos.Candidate
{
    public class CandidateDtoCreate
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres")]

        public string Name { get; set; }

        [Required(ErrorMessage = "O Cosplay é obrigatório")]
        [StringLength(60, ErrorMessage = "Cosplay deve ter no máximo {1} caracteres")]
        public string Cosplay { get; set; } 

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email em formato inválido")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres")]
        public string Email { get; set; }
    }
}
