using Microsoft.AspNetCore.Mvc;
using AlmacenS.Core.Interfaces;
using AlmacenS.Core.Mapeadores;
using AlmacenS.Core.DTOs;

namespace AlmacenS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargaProductoController : ControllerBase
    {
        private readonly ICargaProductoRepository _cargaRepo;
        private readonly IProductoRepository _productoRepo;
        private readonly IAlertaReabastecimientoRepository _alertaRepo;

        public CargaProductoController(
            ICargaProductoRepository cargaRepo,
            IProductoRepository productoRepo,
            IAlertaReabastecimientoRepository alertaRepo)
        {
            _cargaRepo = cargaRepo;
            _productoRepo = productoRepo;
            _alertaRepo = alertaRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCargas()
        {
            var cargas = await _cargaRepo.GetAllAsync();
            return Ok(cargas.Select(c => c.ToDTO()));
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarCarga(CargaProductoDTO dto)
        {
            var producto = await _productoRepo.GetByCodigoAsync(dto.CodigoProducto);
            if (producto == null)
                return NotFound("Producto no encontrado");

            if (producto.Cantidad < dto.CantidadBuena)
                return BadRequest("No hay suficiente stock");

            producto.Cantidad -= dto.CantidadBuena;
            await _productoRepo.UpdateAsync(producto);

            if (producto.Cantidad < producto.StockMinimo)
            {
                await _alertaRepo.AddAsync(new Core.Entities.AlertaReabastecimiento
                {
                    CodigoProducto = producto.Codigo,
                    Mensaje = $"Stock bajo para {producto.Nombre}",
                    Estado = "Pendiente",
                    Fecha = DateTime.UtcNow
                });
            }

            var carga = dto.ToEntity();
            await _cargaRepo.AddAsync(carga);

            return Ok(carga.ToDTO());
        }
    }
}
