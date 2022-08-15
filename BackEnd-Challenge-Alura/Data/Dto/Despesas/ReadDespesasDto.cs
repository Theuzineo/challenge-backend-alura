using System.Text.Json.Serialization;

namespace BackEnd_Challenge_Alura.Data.Dto.Despesas
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
