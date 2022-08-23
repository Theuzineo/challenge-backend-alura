using AutoMapper;
using Domain.DTOs.Receitas;
using Domain.Models;
using FluentResults;
using Infra.Data;

namespace Services
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
            Receitas? ProcuraReceita = _context.tb_Receitas.FirstOrDefault(ProcuraReceita => ProcuraReceita.DescricaoReceita == receitaDto.DescricaoReceita);
            if (ProcuraReceita != null)
            {
                if (ProcuraReceita.DataReceita.Month == receitaDto.DataReceita.Month &&
                    ProcuraReceita.DataReceita.Year == receitaDto.DataReceita.Year)
                    return null;
            }

            Receitas receita = _mapper.Map<Receitas>(receitaDto);
            _context.tb_Receitas.Add(receita);
            _context.SaveChanges();
            return _mapper.Map<ReadReceitasDto>(receita);
        }

        public List<ReadReceitasDto>? RecuperaReceitaPorDescricao(string descricao)
        {
            if (descricao == null)
            {
                var receitas = _context.tb_Receitas.ToList();
                return receitaToList(receitas);
            }

            var receita = _context.tb_Receitas.Where(Descricao =>
            Descricao.DescricaoReceita.ToLower().Contains(descricao.ToLower())).ToList();
            if (receita == null) return null;

            return receitaToList(receita);
        }
        public List<ReadReceitasDto>? RecuperaReceitaPorData(int ano, int mes)
        {
            var receita = _context.tb_Receitas.Where(Data =>
            Data.DataReceita.Month == mes && Data.DataReceita.Year == ano).ToList();
            if (receita.Count == 0) return null;

            return receitaToList(receita);
        }

        private List<ReadReceitasDto> receitaToList(List<Receitas> receitas)
            => _mapper.Map<List<Receitas>, List<ReadReceitasDto>>(receitas);

        public ReadReceitasDto? GetReceitaPorId(int id)
        {
            Receitas? receita = _context.tb_Receitas.FirstOrDefault(receita => receita.ReceitaId == id);
            if (receita == null) return null;

            return _mapper.Map<ReadReceitasDto>(receita);
        }

        public Result UpdateReceitaPorId(int id, UpdateReceitasDto updateReceitaDto)
        {
            Receitas? receita = _context.tb_Receitas.FirstOrDefault(Id => Id.ReceitaId == id);
            if (receita == null) return Result.Fail("Receita não encontrada");

            var verificaDescricao = _context.tb_Receitas.FirstOrDefault(descricao =>
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
            Receitas? receita = _context.tb_Receitas.FirstOrDefault(Id => Id.ReceitaId == id);
            if (receita == null) return Result.Fail("Receita não encontrada");

            _context.tb_Receitas.Remove(receita);
            _context.SaveChanges();
            return Result.Ok();
        }

    }
}
