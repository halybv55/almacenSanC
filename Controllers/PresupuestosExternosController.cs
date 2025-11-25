using AlmacenS.Core.DTOs;
using AlmacenS.Core.Services;
using Microsoft.AspNetCore.Mvc;


namespace AlmacenS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PresupuestosExternosController : ControllerBase
    {
        private readonly PresupuestosExternosService _service;

        public PresupuestosExternosController(PresupuestosExternosService service)
        {
            _service = service;
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] PresupuestoCrearDto dto)
        {
            var resultado = await _service.CrearPresupuestoAsync(dto);
            return Ok(resultado);
        }
    }
}
