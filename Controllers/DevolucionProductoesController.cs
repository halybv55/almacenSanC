using Microsoft.AspNetCore.Mvc;
using AlmacenS.Core.Interfaces;
using AlmacenS.Core.Mapeadores;
using AlmacenS.Core.DTOs;

namespace AlmacenS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevolucionProductoController : ControllerBase
    {
        private readonly IDevolucionProductoRepository _devoRepo;

        public DevolucionProductoController(IDevolucionProductoRepository devoRepo)
        {
            _devoRepo = devoRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetDevoluciones()
        {
            var devoluciones = await _devoRepo.GetAllAsync();
            return Ok(devoluciones.Select(d => d.ToDTO()));
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarDevolucion(DevolucionProductoDTO dto)
        {
            var devolucion = dto.ToEntity();
            await _devoRepo.AddAsync(devolucion);
            return Ok(devolucion.ToDTO());
        }
    }
}
