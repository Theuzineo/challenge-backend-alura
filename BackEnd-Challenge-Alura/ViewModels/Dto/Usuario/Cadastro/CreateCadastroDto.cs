using System.ComponentModel.DataAnnotations;

namespace BackEnd_Challenge_Alura.ViewModels.Dto.Usuario.Cadastro
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
