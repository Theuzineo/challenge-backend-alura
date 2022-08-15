using BackEnd_Challenge_Alura.Data;
using BackEnd_Challenge_Alura.Data.Dto.Resumo;
using BackEnd_Challenge_Alura.Enums;
using System.Linq;

namespace BackEnd_Challenge_Alura.Services
{
    public class ResumoService
    {
        private AppDbContext _context;

        public ResumoService(AppDbContext context)
        {
            _context = context;
        }

        public Resumo GetResumo(int ano, int mes)
        {
            var getValorReceitas = _context.ReceitasDb
                .Where(receitas => receitas.DataReceita.Year == ano && receitas.DataReceita.Month == mes)
                .Select(receitas => receitas.ValorReceita)
                .Sum();

            var getValorDespesas = _context.DespesasDb
                .Where(despesas => despesas.DataDespesa.Year == ano && despesas.DataDespesa.Month == mes)
                .Select(despesas => despesas.ValorDespesa)
                .Sum();

            var getSaldoMes = getValorReceitas - getValorDespesas;


            var getCampos =
                from tbCategoria in _context.DespesasDb
                where tbCategoria.DataDespesa.Year == ano && tbCategoria.DataDespesa.Month == mes
                group new { tbCategoria.CategoriaDespesa, tbCategoria.ValorDespesa }                     
                by tbCategoria.CategoriaDespesa into tbSaldo
                select new RetornoCategoria 
                {  
                    Categoria = (EnumCategoria)tbSaldo.Key,
                    TotalCategoria = tbSaldo.Sum(x => x.ValorDespesa) ?? 0
                };

            var teste = getCampos.ToList();
            return new Resumo()
            {
                TotalReceitas = getValorReceitas ?? 0,
                TotalDespesas = getValorDespesas ?? 0,
                SaldoTotal = getSaldoMes ?? 0,
                TotalPorCategoria = getCampos.ToList()

            };

        }

    }
}
