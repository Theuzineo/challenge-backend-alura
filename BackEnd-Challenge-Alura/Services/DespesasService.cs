using AutoMapper;
using BackEnd_Challenge_Alura.Data;
using BackEnd_Challenge_Alura.Data.Dto.Despesas;
using BackEnd_Challenge_Alura.Enums;
using BackEnd_Challenge_Alura.Models;
using FluentResults;

namespace BackEnd_Challenge_Alura.Services
{
    public class DespesasService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public DespesasService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadDespesasDto? AdicionaReceita(CreateDespesasDto despesaDto)
        {
            var verificaCategoria = CategoriasDespesas(despesaDto.CategoriaDespesa);
            if (verificaCategoria == false) return null;

            Despesas? ProcuraDespesa = _context.DespesasDb.FirstOrDefault(ProcuraDespesa => 
            ProcuraDespesa.DescricaoDespesa == despesaDto.DescricaoDespesa);
            if (ProcuraDespesa != null)
            {

                if(ProcuraDespesa.DataDespesa.Month == despesaDto.DataDespesa.Month &&
                    ProcuraDespesa.DataDespesa.Year == despesaDto.DataDespesa.Year)
                        
                    return null;
            }
            Despesas despesa = _mapper.Map<Despesas>(despesaDto);
            
            _context.DespesasDb.Add(despesa);
            _context.SaveChanges();
            return _mapper.Map<ReadDespesasDto>(despesa);
        }

        public ReadDespesasDto? RecuperaDespesaPorId(int id)
        {
            Despesas? despesa = _context.DespesasDb.FirstOrDefault(despesa => despesa.IdDespesa == id);
            if (despesa == null) return null;

            return _mapper.Map<ReadDespesasDto>(despesa);
        }

        public List<ReadDespesasDto>? RecuperaDespesaPorDescricao(string descricao)
        {
            if (descricao == null)
            {
                var despesas = _context.DespesasDb.ToList();
                return despesaToList(despesas); ;
            }

            var despesa = _context.DespesasDb.Where(Descricao =>
            Descricao.DescricaoDespesa.ToLower().Contains(descricao.ToLower())).ToList();
            if (despesa == null) return null;

            return despesaToList(despesa);
        }

        public List<ReadDespesasDto>? ReceuperaDespesaPorData(int ano, int mes)
        {
            var despesa = _context.DespesasDb.Where(Data =>
            Data.DataDespesa.Month == mes && Data.DataDespesa.Year == ano).ToList();
            if (despesa.Count == 0) return null;

            return despesaToList(despesa);
        }

        private List<ReadDespesasDto> despesaToList(List<Despesas> despesas) 
            => _mapper.Map<List<Despesas>, List<ReadDespesasDto>>(despesas);

        public Result UpdateDespesaPorId(int id, UpdateDespesaDto updateDespesaDto)
        {
            Despesas? despesa = _context.DespesasDb.FirstOrDefault(Id => Id.IdDespesa == id);
            if (despesa == null) return Result.Fail("Despesa não encontrada");

            var verificaDescricao = _context.DespesasDb.FirstOrDefault(descricao =>
            descricao.DescricaoDespesa == updateDespesaDto.DescricaoDespesa);
            if (verificaDescricao != null) return Result.Fail("Já existe essa descrição");

            _mapper.Map(updateDespesaDto, despesa);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteDespesaPorId(int id)
        {
            Despesas? despesa = _context.DespesasDb.FirstOrDefault(Id => Id.IdDespesa == id);
            if (despesa == null) return Result.Fail("Despesa não encontrada");

            _context.DespesasDb.Remove(despesa);
            _context.SaveChanges();
            return Result.Ok();
        }

        public static bool CategoriasDespesas(int campoCategoria)
        {
            var categorias = Enum.GetValues(typeof(EnumCategoria)).Cast<EnumCategoria>().FirstOrDefault(x => (int)x == campoCategoria);

            if (categorias != null) return true;

            return false;
        }

    }
}
