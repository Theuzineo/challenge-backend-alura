using BackEnd_Challenge_Alura.Enums;
using System.ComponentModel.DataAnnotations;

namespace BackEnd_Challenge_Alura.Data.Dto.Resumo
{
    public class Resumo
    {
        public decimal TotalReceitas { get; set; }

        public decimal TotalDespesas { get; set; }

        public decimal SaldoTotal { get; set; }


        public List<RetornoCategoria> TotalPorCategoria { get; set; }

    }

    public class RetornoCategoria
    {
        public EnumCategoria Categoria { get; set; }
        public decimal TotalCategoria { get; set; }
    }
}
