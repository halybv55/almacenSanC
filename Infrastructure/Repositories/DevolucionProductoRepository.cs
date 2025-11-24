using AlmacenS.Core.Entities;
using AlmacenS.Core.Interfaces;
using AlmacenS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AlmacenS.Infrastructure.Repositories
{
    public class DevolucionProductoRepository : IDevolucionProductoRepository
    {
        private readonly AlmacenSContext _context;

        public DevolucionProductoRepository(AlmacenSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DevolucionProducto>> GetAllAsync()
        {
            return await _context.DevolucionProducto
                .OrderByDescending(x => x.Fecha)
                .ToListAsync();
        }

        public async Task<DevolucionProducto?> GetByIdAsync(int id)
        {
            return await _context.DevolucionProducto.FindAsync(id);
        }

        public async Task<DevolucionProducto> AddAsync(DevolucionProducto devolucion)
        {
            _context.DevolucionProducto.Add(devolucion);
            await _context.SaveChangesAsync();
            return devolucion;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var devolucion = await _context.DevolucionProducto.FindAsync(id);
            if (devolucion == null) return false;

            _context.DevolucionProducto.Remove(devolucion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
