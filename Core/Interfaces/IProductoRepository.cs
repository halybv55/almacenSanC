using AlmacenS.Core.Entities;

namespace AlmacenS.Core.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto?> GetByCodigoAsync(string codigo);
        Task<bool> ExistsAsync(string codigo);
        Task AddAsync(Producto producto);
        Task UpdateAsync(Producto producto);
    }
}
