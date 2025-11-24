using Microsoft.AspNetCore.Mvc;
using AlmacenS.Core.Interfaces;
using AlmacenS.Core.Mapeadores;
using AlmacenS.Core.DTOs;

namespace AlmacenS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioEntradasController : ControllerBase
    {
        private readonly IInventarioEntradaRepository _entradaRepo;
        private readonly ICargaProductoRepository _cargaRepo;
        private readonly IProductoRepository _productoRepo;

        public InventarioEntradasController(
            IInventarioEntradaRepository entradaRepo,
            ICargaProductoRepository cargaRepo,
            IProductoRepository productoRepo)
        {
            _entradaRepo = entradaRepo;
            _cargaRepo = cargaRepo;
            _productoRepo = productoRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetEntradas()
        {
            var entradas = await _entradaRepo.GetAllAsync();
            return Ok(entradas.Select(e => e.ToDTO()));
        }

        // Registrar la entrada
        [HttpPost]
        public async Task<IActionResult> RegistrarEntrada(InventarioEntradaDTO dto)
        {
            var producto = await _productoRepo.GetByCodigoAsync(dto.CodigoProducto);

            if (producto == null)
                return NotFound("Producto no encontrado.");

            var entrada = dto.ToEntity();
            await _entradaRepo.AddAsync(entrada);

            return Ok(entrada.ToDTO());
        }

        // 🟩 Inventario real: Entradas - Salidas
        [HttpGet("inventario")]
        public async Task<IActionResult> GetInventario()
        {
            var productos = await _productoRepo.GetAllAsync();
            var entradas = await _entradaRepo.GetAllAsync();
            var salidas = await _cargaRepo.GetAllAsync();

            var inventario = productos.Select(p => new
            {
                codigo = p.Codigo,
                nombre = p.Nombre,
                stockMinimo = p.StockMinimo,

                cantidad =
                    entradas.Where(e => e.CodigoProducto == p.Codigo).Sum(e => e.Cantidad)
                    -
                    salidas.Where(s => s.CodigoProducto == p.Codigo).Sum(s => s.CantidadBuena)
            });

            return Ok(inventario);
        }
    }
}
