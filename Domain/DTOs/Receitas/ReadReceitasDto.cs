using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.Receitas
{
    public class ReadReceitasDto
    {
        public string DescricaoReceita { get; set; }

        public decimal? ValorReceita { get; set; }

        [JsonIgnore]
        public DateTime DataReceita { get; set; }

        public string DataFormatada { get => DataReceita.ToString("dd/MM/yyyy"); private set { } }
    }
}
