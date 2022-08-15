using BackEnd_Challenge_Alura.Data.Dto.Receitas;
using Microsoft.AspNetCore.Mvc;
using BackEnd_Challenge_Alura.Services;
using FluentResults;
using BackEnd_Challenge_Alura.Models;

namespace BackEnd_Challenge_Alura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceitasController : ControllerBase
    {
        private ReceitasService _receitasServives;


        public ReceitasController(ReceitasService receitasSerives)
        {
            _receitasServives = receitasSerives;
        }


        [HttpPost]
        public IActionResult AdicionaReceita([FromBody] CreateReceitasDto receitaDto)
        {

            ReadReceitasDto? resultado = _receitasServives.AdicionaReceita(receitaDto);
            if (resultado == null) return BadRequest();
            return CreatedAtAction(nameof(RecuperaReceitaPorDescricao), new { id = resultado.DescricaoReceita }, receitaDto);
        }


        [HttpGet("{id}")]
        public IActionResult GetReceitaPorId(int id)
        {
            ReadReceitasDto? resultado = _receitasServives.GetReceitaPorId(id);
            if (resultado == null) return NotFound();

            return Ok(resultado);
        }


        [HttpGet]
        public IActionResult RecuperaReceitaPorDescricao([FromQuery] string? descricao)
        {
            List<ReadReceitasDto>? resultado= _receitasServives.RecuperaReceitaPorDescricao(descricao);
            if (resultado == null) return NotFound();

            return Ok(resultado);
        }

        
        [HttpGet("{ano}/{mes}")]
        public IActionResult RecuperaReceitaPorData(int ano, int mes)
        {
            List<ReadReceitasDto>? resultado = _receitasServives.RecuperaReceitaPorData(ano, mes);
            if (resultado == null) return NotFound();

            return Ok(resultado);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateReceitaPorId(int id, [FromBody] UpdateReceitasDto updateReceitaDto)
        {
            Result resultado = _receitasServives.UpdateReceitaPorId(id, updateReceitaDto);
            if (resultado.IsFailed) return BadRequest();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteReceitaPorId(int id)
        {
            Result resultado = _receitasServives.DeleteReceitaPorId(id);
            if (resultado.IsFailed) return BadRequest();

            return NoContent();
        }
    }
}
