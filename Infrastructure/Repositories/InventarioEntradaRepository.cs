using AlmacenS.Core.Entities;
using AlmacenS.Core.Interfaces;
using AlmacenS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AlmacenS.Infrastructure.Repositories
{
    public class InventarioEntradaRepository : IInventarioEntradaRepository
    {
        private readonly AlmacenSContext _context;

        public InventarioEntradaRepository(AlmacenSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InventarioEntrada>> GetAllAsync()
        {
            return await _context.InventarioEntrada
                .OrderByDescending(e => e.Fecha)
                .ToListAsync();
        }

        public async Task AddAsync(InventarioEntrada entrada)
        {
            _context.InventarioEntrada.Add(entrada);
            await _context.SaveChangesAsync();
        }

        // NUEVO → devuelve inventario acumulado por código
        public async Task<IEnumerable<object>> GetInventarioTotalAsync()
        {
            return await _context.InventarioEntrada
                .GroupBy(e => e.CodigoProducto)
                .Select(g => new
                {
                    CodigoProducto = g.Key,
                    Total = g.Sum(x => x.Cantidad)
                })
                .ToListAsync();
        }
    }
}
