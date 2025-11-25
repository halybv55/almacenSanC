using AlmacenS.Core.DTOs;
using System.Net.Http.Json;

namespace AlmacenS.Core.Services
{
    public class PresupuestosExternosService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PresupuestosExternosService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<object> CrearPresupuestoAsync(PresupuestoCrearDto dto)
        {
            var client = _httpClientFactory.CreateClient("PresupuestosApi");

            var response = await client.PostAsJsonAsync("api/Presupuestos", dto);

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadFromJsonAsync<object>();
            return data!;
        }
    }
}
