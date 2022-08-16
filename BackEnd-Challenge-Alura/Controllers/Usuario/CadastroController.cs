using BackEnd_Challenge_Alura.Services;
using BackEnd_Challenge_Alura.ViewModels.Dto.Usuario.Cadastro;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Challenge_Alura.Controllers.Usuario
{

    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public CadastroController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpPost]
        public IActionResult RegistroUsuario([FromBody] CreateCadastroDto cadastroDto)
        {
            Result resultado = _usuarioService.RegistroUsuario(cadastroDto);
            if (resultado.IsFailed) return BadRequest();

            return Ok();
        }

        [HttpGet("{nome}")]
        public IActionResult GetUsuarios(string nome)
        {
            ReadCadastroDto? resultado = _usuarioService.GetUsuarios(nome);
            if (resultado == null) return BadRequest();

            return Ok(resultado);
        }
    }
}
