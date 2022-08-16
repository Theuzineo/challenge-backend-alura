using AutoMapper;
using BackEnd_Challenge_Alura.Data;
using BackEnd_Challenge_Alura.Models;
using BackEnd_Challenge_Alura.ViewModels.Dto.Usuario.Cadastro;
using FluentResults;

namespace BackEnd_Challenge_Alura.Services
{
    public class UsuarioService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public UsuarioService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Result RegistroUsuario(CreateCadastroDto cadastroDto)
        {
            var cadastro = _context.tb_Usuarios.FirstOrDefault(id => id.Email == cadastroDto.Email);
            if (cadastro != null) return Result.Fail("Email inserido já existe");

            cadastro = _mapper.Map<Usuarios>(cadastroDto);
            _context.tb_Usuarios.Add(cadastro);
            _context.SaveChanges();
            return Result.Ok();
        }

        public ReadCadastroDto? GetUsuarios(string nome)
        {
            Usuarios? usuario = _context.tb_Usuarios.FirstOrDefault(conta => conta.Nome == nome);
            if (usuario == null) return null;

            return _mapper.Map<ReadCadastroDto>(usuario);

        }
    }
}
