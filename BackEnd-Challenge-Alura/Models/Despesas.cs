using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackEnd_Challenge_Alura.Models
{
    public class Despesas
    {
        [Key]
        [JsonIgnore]
        public int IdDespesa { get; set; }


        [Required(ErrorMessage = "O campo 'Descrição' precisa ser preenchido")]
        public string DescricaoDespesa { get; set; }


        [Required(ErrorMessage = "O campo 'Valor' precisa ser preenchido")]
        public decimal? ValorDespesa { get; set; } = null;


        [Required(ErrorMessage = "O campo 'Data' precisa ser preenchido")]
        public DateTime DataDespesa { get; set; }

        public int CategoriaDespesa { get; set; } = 8;
    }
}
