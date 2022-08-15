using System.ComponentModel.DataAnnotations;

namespace BackEnd_Challenge_Alura.Data.Dto.Despesas
{
    public class CreateDespesasDto
    {
        [Required(ErrorMessage = "O campo 'Descrição' precisa ser preenchido")]
        public string DescricaoDespesa { get; set; }

        [Required(ErrorMessage = "O campo 'Valor' precisa ser preenchido")]
        public decimal? ValorDespesa { get; set; } = null;


        [Required(ErrorMessage = "O campo 'Data' precisa ser preenchido")]
        public DateTime DataDespesa { get; set; }

        public int CategoriaDespesa { get; set; } = 8;

    }
}
