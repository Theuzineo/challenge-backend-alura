using BackEnd_Challenge_Alura.Data;
using FluentResults;
using BackEnd_Challenge_Alura.Models;
using AutoMapper;
using BackEnd_Challenge_Alura.Data.Dto.Receitas;

namespace BackEnd_Challenge_Alura.Services
{
    public class ReceitasService
    {
        private AppDbContext _context;
        private IMapper _mapper;


        public ReceitasService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadReceitasDto? AdicionaReceita(CreateReceitasDto receitaDto)
        {
            Receitas? ProcuraReceita = _context.ReceitasDb.FirstOrDefault(ProcuraReceita => ProcuraReceita.DescricaoReceita == receitaDto.DescricaoReceita);
            if (ProcuraReceita != null)
            {
                if (ProcuraReceita.DataReceita.Month == receitaDto.DataReceita.Month &&
                    ProcuraReceita.DataReceita.Year == receitaDto.DataReceita.Year)
                    return null;
            }

            Receitas receita = _mapper.Map<Receitas>(receitaDto);
            _context.ReceitasDb.Add(receita);
            _context.SaveChanges();
            return _mapper.Map<ReadReceitasDto>(receita);
        }

        public List<ReadReceitasDto>? RecuperaReceitaPorDescricao(string descricao)
        {
            if (descricao == null)
            {
                var receitas = _context.ReceitasDb.ToList();
                return receitaToList(receitas);
            }

            var receita = _context.ReceitasDb.Where(Descricao =>
            Descricao.DescricaoReceita.ToLower().Contains(descricao.ToLower())).ToList();
            if (receita == null) return null;

            return receitaToList(receita);
        }
        public List<ReadReceitasDto>? RecuperaReceitaPorData(int ano, int mes)
        {
            var receita = _context.ReceitasDb.Where(Data =>
            Data.DataReceita.Month == mes && Data.DataReceita.Year == ano).ToList();
            if (receita.Count == 0) return null;

            return receitaToList(receita);
        }

        private List<ReadReceitasDto> receitaToList(List<Receitas> receitas)
            => _mapper.Map<List<Receitas>, List<ReadReceitasDto>>(receitas);

        public ReadReceitasDto? GetReceitaPorId(int id)
        {
            Receitas? receita = _context.ReceitasDb.FirstOrDefault(receita => receita.IdReceita == id);
            if (receita == null) return null;

            return _mapper.Map<ReadReceitasDto>(receita);
        }

        public Result UpdateReceitaPorId(int id, UpdateReceitasDto updateReceitaDto)
        {
            Receitas? receita = _context.ReceitasDb.FirstOrDefault(Id => Id.IdReceita == id);
            if (receita == null) return Result.Fail("Receita não encontrada");

            var verificaDescricao = _context.ReceitasDb.FirstOrDefault(descricao =>
            descricao.DescricaoReceita == updateReceitaDto.DescricaoReceita &&
            descricao.DataReceita.Year == updateReceitaDto.DataReceita.Year &&
            descricao.DataReceita.Month == updateReceitaDto.DataReceita.Month);
            if (verificaDescricao != null) return Result.Fail("Descrição já existe");
                                                                    
            _mapper.Map(updateReceitaDto, receita);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteReceitaPorId(int id)
        {
            Receitas? receita = _context.ReceitasDb.FirstOrDefault(Id => Id.IdReceita == id);
            if (receita == null) return Result.Fail("Receita não encontrada");

            _context.ReceitasDb.Remove(receita);
            _context.SaveChanges();
            return Result.Ok();
        }

    }
}
