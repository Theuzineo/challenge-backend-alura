using AutoMapper;
using BackEnd_Challenge_Alura.Models;
using BackEnd_Challenge_Alura.ViewModels.Dto.Usuario.Cadastro;

namespace BackEnd_Challenge_Alura.Profiles
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
