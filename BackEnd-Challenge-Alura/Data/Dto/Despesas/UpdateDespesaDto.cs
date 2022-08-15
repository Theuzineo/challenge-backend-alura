using System.ComponentModel.DataAnnotations;

namespace BackEnd_Challenge_Alura.Data.Dto.Despesas
{
    public class UpdateDespesaDto
    {
        [Required(ErrorMessage = "Especifique as atualizações do campo 'Descrição'")]
        public string DescricaoDespesa { get; set; }


        [Required(ErrorMessage = "Especifique as atualizações do campo 'Valor'")]
        public decimal? ValorDespesa{ get; set; } = null;


        [Required(ErrorMessage = "Especifique as atualizações do campo 'Data'")]
        public DateTime DataDespesa { get; set; }

        public int CategoriaDespesa { get; set; } = 8;
    }
}
