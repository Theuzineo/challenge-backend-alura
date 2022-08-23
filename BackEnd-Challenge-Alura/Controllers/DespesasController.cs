using Domain.DTOs.Despesas;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace BackEnd_Challenge_Alura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DespesasController : ControllerBase
    {
        private DespesasService _despesasService;


        public DespesasController(DespesasService despesasService)
        {
            _despesasService = despesasService;
        }


        [HttpPost]
        public IActionResult AdicionaReceita([FromBody] CreateDespesasDto despesaDto)
        {
            ReadDespesasDto? resultado = _despesasService.AdicionaReceita(despesaDto);
            if (resultado == null) return BadRequest();
            return CreatedAtAction(nameof(RecuperaDespesaPorDescricao), new { id = resultado.DescricaoDespesa }, despesaDto);
        }


        [HttpGet("{id}")]
        public IActionResult RecuperaDespesaPorId(int id)
        {
            ReadDespesasDto? resultado = _despesasService.RecuperaDespesaPorId(id);
            if (resultado == null) return NotFound();

            return Ok(resultado);
        }


        [HttpGet]
        public IActionResult RecuperaDespesaPorDescricao([FromQuery] string? descricao)
        {
            List<ReadDespesasDto>? resultado = _despesasService.RecuperaDespesaPorDescricao(descricao);
            if (resultado == null) return NotFound();

            return Ok(resultado);
        }


        [HttpGet("{ano}/{mes}")]
        public IActionResult RecuperaDespesaPorData(int ano, int mes)
        {
            List<ReadDespesasDto>? resultado = _despesasService.ReceuperaDespesaPorData(ano, mes);
            if (resultado == null) return NotFound();

            return Ok(resultado);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateDespesaPorId(int id, [FromBody] UpdateDespesaDto updateDespesaDto)
        {

            Result resultado = _despesasService.UpdateDespesaPorId(id, updateDespesaDto);
            if (resultado.IsFailed) return BadRequest();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteDespesaPorId(int id)
        {
            Result resultado = _despesasService.DeleteDespesaPorId(id);
            if (resultado.IsFailed) return BadRequest();

            return NoContent();
        }
    }
}
