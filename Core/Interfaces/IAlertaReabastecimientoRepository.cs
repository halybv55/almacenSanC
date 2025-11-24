using AlmacenS.Core.Entities;

namespace AlmacenS.Core.Interfaces
{
    public interface IAlertaReabastecimientoRepository
    {
        Task<IEnumerable<AlertaReabastecimiento>> GetAllAsync();
        Task<AlertaReabastecimiento?> GetByIdAsync(int id);
        Task<AlertaReabastecimiento> AddAsync(AlertaReabastecimiento alerta);
        Task<bool> DeleteAsync(int id);
    }
}
