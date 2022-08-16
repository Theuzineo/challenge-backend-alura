using System.Text.Json.Serialization;

namespace BackEnd_Challenge_Alura.Data.Dto.Receitas
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
