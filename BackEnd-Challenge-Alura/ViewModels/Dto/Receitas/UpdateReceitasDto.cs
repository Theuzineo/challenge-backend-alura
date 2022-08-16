using System.ComponentModel.DataAnnotations;

namespace BackEnd_Challenge_Alura.Data.Dto.Receitas
{
    public class UpdateReceitasDto
    {
        [Required(ErrorMessage = "Especifique as atualizações do campo 'Descrição'")]
        public string DescricaoReceita { get; set; }

        [Required(ErrorMessage = "Especifique as atualizações do campo 'valor'")]
        public decimal? ValorReceita { get; set; } = null;

        [Required(ErrorMessage = "Especifique as atualizações do campo 'Data'")]
        public DateTime DataReceita { get; set; }

    }
}
