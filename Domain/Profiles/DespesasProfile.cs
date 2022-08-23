using AutoMapper;
using Domain.DTOs.Despesas;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Profiles
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
