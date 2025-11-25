using System.Net.Http.Json;
using AlmacenS.Core.DTOs;

namespace AlmacenS.Core.Services
{
    public class PedidosExternosService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PedidosExternosService(IHttpClientFactory factory)
        {
            _httpClientFactory = factory;
        }

        public async Task<List<PedidoExternoDto>> ObtenerPedidosAsync()
        {
            var client = _httpClientFactory.CreateClient("PedidosApi");

            var response = await client.GetAsync("api/Pedidos/ListaDePedidos");

            response.EnsureSuccessStatusCode();

            var pedidos = await response.Content
                .ReadFromJsonAsync<List<PedidoExternoDto>>();

            return pedidos ?? new List<PedidoExternoDto>();
        }
    }
}
