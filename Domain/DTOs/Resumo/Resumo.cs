using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Resumo
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
