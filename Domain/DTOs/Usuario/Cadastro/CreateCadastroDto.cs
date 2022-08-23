using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Usuario.Cadastro
{
    public class CreateCadastroDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Compare("Senha")]
        public string ConfirmarSenha { get; set; }
    }
}
