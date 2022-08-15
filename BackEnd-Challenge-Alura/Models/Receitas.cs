using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackEnd_Challenge_Alura.Models
{
    public class Receitas
    {
        [Key]
        [Required]
        public int IdReceita { get; set; }

        [Required(ErrorMessage = "O campo 'Descrição' precisa ser preenchido")]
        public string DescricaoReceita { get; set; }

        [Required(ErrorMessage = "O campo 'Valor' precisa ser preenchido")]
        public decimal? ValorReceita { get; set; } = null;

        [Required(ErrorMessage = "O campo 'Data' precisa ser preenchido")]
        public DateTime DataReceita { get; set; }
    }
}
