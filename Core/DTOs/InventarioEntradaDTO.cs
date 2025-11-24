namespace AlmacenS.Core.DTOs
{
    public class InventarioEntradaDTO
    {
        public string CodigoProducto { get; set; } = "";
        public int Cantidad { get; set; }
        public string Observaciones { get; set; } = "";
        public DateTime FechaEntrada { get; set; } = DateTime.UtcNow;
    }
}
