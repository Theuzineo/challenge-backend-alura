using AutoMapper;
using Domain.DTOs.Receitas;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Profiles
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
