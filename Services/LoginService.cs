using AutoMapper;
using Domain.DTOs.Usuario.Login;
using FluentResults;
using Infra.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Protocols.WSIdentity;

namespace Services
{
    public class LoginService
    {
        private AppDbContext _context;
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;
        private IMapper _mapper;


        public LoginService(AppDbContext context, SignInManager<IdentityUser<int>> signInManger, TokenService tokenService, IMapper mapper)
        {
            _context = context;
            _signInManager = signInManger;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public Result LogarUsuario(CreateLoginDto loginDto)
        {
            var login = _context.tb_Usuarios
                .FirstOrDefault(user => user.Email == loginDto.Email && user.Senha == loginDto.Senha);
            if (login == null) return null;


            // Implementa a geração de Tokens
            // ???????????????


            //var resultadoIdentity = _signInManager
            //    .PasswordSignInAsync(loginDto.Email, loginDto.Senha, false, false);
            //if (resultadoIdentity.Result.Succeeded)
            //{
            //    var identityUser = _signInManager
            //        .UserManager
            //        .Users
            //        .FirstOrDefault(usuario =>
            //        usuario.NormalizedUserName == loginDto.Email.ToUpper());
            //    Token token = _tokenService.CreateToken(identityUser);
            //    return Result.Ok().WithSuccess(token.Value);
            //}
            return Result.Fail("Login falhou");
        }
    }
}
