using Api_Donaciones_Mongo.Models;
using Api_Donaciones_Mongo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Donaciones_Mongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly ComentariosService _comentariosService;

        public ComentariosController(ComentariosService comentariosService)
        {
            _comentariosService = comentariosService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comentario>>> Get()
        {
            return await _comentariosService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comentario>> Get(string id)
        {
            var comentario = await _comentariosService.GetByIdAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }
            return comentario;
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<List<Comentario>>> GetByUsuario(int usuarioId)
        {
            return await _comentariosService.GetByUsuarioIdAsync(usuarioId);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Comentario comentario)
        {
            await _comentariosService.CreateAsync(comentario);
            return CreatedAtAction(nameof(Get), new { id = comentario.Id }, comentario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Comentario comentario)
        {
            var existingComentario = await _comentariosService.GetByIdAsync(id);
            if (existingComentario == null)
            {
                return NotFound();
            }

            comentario.Id = id;
            await _comentariosService.UpdateAsync(id, comentario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var comentario = await _comentariosService.GetByIdAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }

            await _comentariosService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("calificacion/{calificacion}")]
        public async Task<ActionResult<List<Comentario>>> GetByCalificacion(int calificacion)
        {
            return await _comentariosService.GetByCalificacionAsync(calificacion);
        }

        [HttpGet("promedio")]
        public async Task<ActionResult<double>> GetPromedioCalificacion()
        {
            return await _comentariosService.GetPromedioCalificacionAsync();
        }

        [HttpGet("donacion/{donacionId}")]
        public async Task<ActionResult<List<Comentario>>> GetByDonacionId(int donacionId)
        {
            return await _comentariosService.GetByDonacionIdAsync(donacionId);
        }

    }
}
