using AlmacenS.Core.Entities;
using AlmacenS.Core.Interfaces;
using AlmacenS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AlmacenS.Infrastructure.Repositories
{
    public class CargaProductoRepository : ICargaProductoRepository
    {
        private readonly AlmacenSContext _context;

        public CargaProductoRepository(AlmacenSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CargaProducto>> GetAllAsync()
        {
            return await _context.CargaProducto
                .OrderByDescending(x => x.Fecha)
                .ToListAsync();
        }

        public async Task<CargaProducto?> GetByIdAsync(int id)
        {
            return await _context.CargaProducto.FindAsync(id);
        }

        public async Task<CargaProducto?> AddAsync(CargaProducto carga)
        {
            var producto = await _context.Producto
                .FirstOrDefaultAsync(p => p.Codigo == carga.CodigoProducto);

            if (producto == null)
                return null;


            // Registrar carga
            _context.CargaProducto.Add(carga);

            // Generar alerta si cae por debajo del stock mínimo
            if (producto.Cantidad <= producto.StockMinimo)
            {
                _context.AlertaReabastecimiento.Add(new AlertaReabastecimiento
                {
                    CodigoProducto = producto.Codigo,
                    Mensaje = "El inventario está por debajo del stock mínimo.",
                    Estado = "Pendiente"
                });
            }

            await _context.SaveChangesAsync();
            return carga;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var carga = await _context.CargaProducto.FindAsync(id);
            if (carga == null) return false;

            _context.CargaProducto.Remove(carga);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
