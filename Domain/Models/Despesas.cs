using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Despesas
    {
        [Key]
        [JsonIgnore]
        public int DespesaId { get; set; }


        [Required(ErrorMessage = "O campo 'Descrição' precisa ser preenchido")]
        public string DescricaoDespesa { get; set; }


        [Required(ErrorMessage = "O campo 'Valor' precisa ser preenchido")]
        public decimal? ValorDespesa { get; set; } = null;


        [Required(ErrorMessage = "O campo 'Data' precisa ser preenchido")]
        public DateTime DataDespesa { get; set; }

        public int CategoriaDespesa { get; set; } = 8;


        public virtual Usuarios Usuario { get; set; }
        public int UsuarioID { get; set; }
    }
}
