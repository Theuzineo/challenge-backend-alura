using Domain.DTOs.Usuario.Cadastro;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace BackEnd_Challenge_Alura.Controllers.Usuario
{

    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private CadastroService _usuarioService;

        public CadastroController(CadastroService usuarioService)
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
