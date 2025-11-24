using Microsoft.AspNetCore.Mvc;
using AlmacenS.Core.Interfaces;
using AlmacenS.Core.Mapeadores;
using AlmacenS.Core.DTOs;

namespace AlmacenS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertaReabastecimientoController : ControllerBase
    {
        private readonly IAlertaReabastecimientoRepository _alertaRepo;

        public AlertaReabastecimientoController(IAlertaReabastecimientoRepository alertaRepo)
        {
            _alertaRepo = alertaRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlertas()
        {
            var alertas = await _alertaRepo.GetAllAsync();
            return Ok(alertas.Select(a => a.ToDTO()));
        }

        [HttpPost]
        public async Task<IActionResult> CrearAlerta(AlertaReabastecimientoDTO dto)
        {
            var alerta = dto.ToEntity();
            await _alertaRepo.AddAsync(alerta);
            return Ok(alerta.ToDTO());
        }
    }
}
