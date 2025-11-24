using AlmacenS.Core.Entities;

namespace AlmacenS.Core.Interfaces
{
    public interface IInventarioEntradaRepository
    {
        Task<IEnumerable<InventarioEntrada>> GetAllAsync();
        Task AddAsync(InventarioEntrada entrada);

        // NUEVO → cálculo de inventario acumulado
        Task<IEnumerable<object>> GetInventarioTotalAsync();
    }
}
