using AutoMapper;
using BackEnd_Challenge_Alura.Data.Dto.Despesas;
using BackEnd_Challenge_Alura.Models;

namespace BackEnd_Challenge_Alura.Profiles
{
    public class DespesasProfile : Profile
    {
        public DespesasProfile()
        {
            CreateMap<CreateDespesasDto, Despesas>();
            CreateMap<Despesas, ReadDespesasDto>();
            CreateMap<UpdateDespesaDto, Despesas>();
        }

    }
}
