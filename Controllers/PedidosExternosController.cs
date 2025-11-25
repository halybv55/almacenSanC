using AlmacenS.Core.DTOs;
using AlmacenS.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlmacenS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosExternosController : ControllerBase
    {
        private readonly PedidosExternosService _service;

        public PedidosExternosController(PedidosExternosService service)
        {
            _service = service;
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            var pedidos = await _service.ObtenerPedidosAsync();
            return Ok(pedidos);
        }
    }
}
