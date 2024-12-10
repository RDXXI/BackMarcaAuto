using BackTest.Application.Services;
using BackTest.Domain.Entities;
using BackTest.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackTest.Infrastructure.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcasAutosController : ControllerBase
    {
        private readonly IMarcaAutoService _service;

        public MarcasAutosController(IMarcaAutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetMarcas()
        {
            var marcas = await _service.GetAllMarcasAsync();
            return Ok(marcas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMarcaById(int id)
        {
            var marca = await _service.GetMarcaByIdAsync(id);

            if (marca == null)
            {
                return NotFound();
            }

            return Ok(marca);
        }

        [HttpPost]
        public async Task<IActionResult> AddMarca([FromBody] MarcaAuto marca)
        {
            await _service.AddMarcaAsync(marca);
            return CreatedAtAction(nameof(GetMarcas), new { id = marca.Id }, marca);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMarca(int id, [FromBody] MarcaAuto marca)
        {
            if (marca == null || id != marca.Id)
            {
                return BadRequest("La marca no es válida.");
            }

            var existingMarca = await _service.GetMarcaByIdAsync(id);
            if (existingMarca == null)
            {
                return NotFound(); 
            }

            await _service.UpdateMarcaAsync(marca);
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarca(int id)
        {
            var marca = await _service.GetMarcaByIdAsync(id);
            if (marca == null)
            {
                return NotFound();
            }

            await _service.DeleteMarcaAsync(id);
            return NoContent();
        }
    }
}
