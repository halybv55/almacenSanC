using AlmacenS.Core.Entities;
using AlmacenS.Core.Interfaces;
using AlmacenS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AlmacenS.Infrastructure.Repositories
{
    public class AlertaReabastecimientoRepository : IAlertaReabastecimientoRepository
    {
        private readonly AlmacenSContext _context;

        public AlertaReabastecimientoRepository(AlmacenSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AlertaReabastecimiento>> GetAllAsync()
        {
            return await _context.AlertaReabastecimiento
                .OrderByDescending(x => x.Fecha)
                .ToListAsync();
        }

        public async Task<AlertaReabastecimiento?> GetByIdAsync(int id)
        {
            return await _context.AlertaReabastecimiento.FindAsync(id);
        }

        public async Task<AlertaReabastecimiento> AddAsync(AlertaReabastecimiento alerta)
        {
            _context.AlertaReabastecimiento.Add(alerta);
            await _context.SaveChangesAsync();
            return alerta;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var alerta = await _context.AlertaReabastecimiento.FindAsync(id);
            if (alerta == null) return false;

            _context.AlertaReabastecimiento.Remove(alerta);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
