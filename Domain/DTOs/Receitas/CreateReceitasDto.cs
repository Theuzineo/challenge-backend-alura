using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Receitas
{
    public class CreateReceitasDto
    {
        [Required(ErrorMessage = "O campo 'Descrição' precisa ser preenchido")]
        public string DescricaoReceita { get; set; }

        [Required(ErrorMessage = "O campo 'Valor' precisa ser preenchido")]
        public decimal? ValorReceita { get; set; }

        [Required(ErrorMessage = "O campo 'Data' precisa ser preenchido")]
        public DateTime DataReceita { get; set; }
    }
}
