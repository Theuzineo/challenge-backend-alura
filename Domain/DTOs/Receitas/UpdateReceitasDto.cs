using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Receitas
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
