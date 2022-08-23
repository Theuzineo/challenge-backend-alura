using AutoMapper;
using Domain.DTOs.Usuario.Cadastro;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Profiles
{
    public class UsuarioProfile : Profile
    {

        public UsuarioProfile()
        {
            CreateMap<CreateCadastroDto, Usuarios>();
            CreateMap<Usuarios, ReadCadastroDto>();
            //CreateMap<UpdateReceitasDto, Usuarios>();
        }
    }
}
