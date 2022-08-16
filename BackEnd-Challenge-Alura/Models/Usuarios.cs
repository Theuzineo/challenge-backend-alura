using System.ComponentModel.DataAnnotations;

namespace BackEnd_Challenge_Alura.Models
{
    public class Usuarios
    {
        [Key]
        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public string ConfirmarSenha { get; set; }
    }
}
