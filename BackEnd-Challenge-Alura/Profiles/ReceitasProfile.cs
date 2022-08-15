using AutoMapper;
using BackEnd_Challenge_Alura.Data.Dto.Receitas;
using BackEnd_Challenge_Alura.Models;

namespace BackEnd_Challenge_Alura.Profiles
{
    public class ReceitasProfile : Profile
    {
        public ReceitasProfile()
        {
            CreateMap<CreateReceitasDto, Receitas>();
            CreateMap<Receitas, ReadReceitasDto>();
            CreateMap<UpdateReceitasDto, Receitas>(); 
        }
    }
}
