

using BackEnd_Challenge_Alura.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Challenge_Alura.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResumoController : ControllerBase
    {
        private ResumoService _resumoService;


        public ResumoController(ResumoService resumoService)
        {
            _resumoService = resumoService;
        }


        [HttpGet("{ano}/{mes}")]
        public IActionResult GetResumo(int ano, int mes)
        {
            var resultado = _resumoService.GetResumo(ano, mes);

            return Ok(resultado);
        }
    }
}
