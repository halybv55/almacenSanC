using AlmacenS.Core.Entities;
using AlmacenS.Core.Interfaces;
using AlmacenS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AlmacenS.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AlmacenSContext _context;

        public ProductoRepository(AlmacenSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _context.Producto.ToListAsync();
        }

        public async Task<Producto?> GetByCodigoAsync(string codigo)
        {
            return await _context.Producto
                .FirstOrDefaultAsync(p => p.Codigo == codigo);
        }

        public async Task<bool> ExistsAsync(string codigo)
        {
            return await _context.Producto.AnyAsync(p => p.Codigo == codigo);
        }

        public async Task AddAsync(Producto producto)
        {
            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Producto producto)
        {
            _context.Producto.Update(producto);
            await _context.SaveChangesAsync();
        }
    }
}
