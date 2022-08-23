using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Receitas
    {
        [Key]
        [Required]
        public int ReceitaId { get; set; }

        [Required(ErrorMessage = "O campo 'Descrição' precisa ser preenchido")]
        public string DescricaoReceita { get; set; }

        [Required(ErrorMessage = "O campo 'Valor' precisa ser preenchido")]
        public decimal? ValorReceita { get; set; } = null;

        [Required(ErrorMessage = "O campo 'Data' precisa ser preenchido")]
        public DateTime DataReceita { get; set; }


        public Usuarios Usuario { get; set; }
    }
}
