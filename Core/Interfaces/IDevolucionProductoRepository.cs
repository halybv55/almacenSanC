using AlmacenS.Core.Entities;

namespace AlmacenS.Core.Interfaces
{
    public interface IDevolucionProductoRepository
    {
        Task<IEnumerable<DevolucionProducto>> GetAllAsync();
        Task<DevolucionProducto?> GetByIdAsync(int id);
        Task<DevolucionProducto> AddAsync(DevolucionProducto devolucion);
    }
}
