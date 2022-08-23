using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.Despesas
{
    public class ReadDespesasDto
    {
        public string DescricaoDespesa { get; set; }

        public decimal ValorDespesa { get; set; }

        [JsonIgnore]
        public DateTime DataDespesa { get; set; }

        public string DataFormatada { get => DataDespesa.ToString("dd/MM/yyyy"); private set { } }

        public int CategoriaDespesa { get; set; }
    }
}
