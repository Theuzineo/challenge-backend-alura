using AutoMapper;
using Domain.DTOs.Usuario.Cadastro;
using Domain.Models;
using FluentResults;
using Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CadastroService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CadastroService(AppDbContext context, IMapper mapper)
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
