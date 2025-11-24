using Microsoft.AspNetCore.Mvc;
using AlmacenS.Core.Interfaces;
using AlmacenS.Core.Mapeadores;
using AlmacenS.Core.DTOs;

namespace AlmacenS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _repo;

        public ProductoController(IProductoRepository repo)
        {
            _repo = repo;
        }

        // Lista el catálogo de productos
        [HttpGet]
        public async Task<IActionResult> GetCatalogoProductos()
        {
            var productos = await _repo.GetAllAsync();
            return Ok(productos.Select(p => p.ToDTO()));
        }

        // Crea productos – NO modifica inventario real
        [HttpPost]
        public async Task<IActionResult> CrearProducto(ProductoDTO dto)
        {
            if (await _repo.ExistsAsync(dto.Codigo))
                return BadRequest("El producto ya existe.");

            var producto = dto.ToEntity();

            // Cantidad aquí NO es inventario, así que se fuerza a 0
            producto.Cantidad = 0;

            await _repo.AddAsync(producto);

            return Ok(producto.ToDTO());
        }
        [HttpGet("catalogo-simple")]
        public async Task<IActionResult> GetCatalogoSimple()
        {
            var productos = await _repo.GetAllAsync();
            return Ok(productos.Select(p => p.ToCatalogoDTO()));
        }

    }
}
