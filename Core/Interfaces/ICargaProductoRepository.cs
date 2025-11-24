using AlmacenS.Core.Entities;

namespace AlmacenS.Core.Interfaces
{
    public interface ICargaProductoRepository
    {
        Task<IEnumerable<CargaProducto>> GetAllAsync();
        Task<CargaProducto?> GetByIdAsync(int id);
        Task<CargaProducto> AddAsync(CargaProducto carga);
    }
}
