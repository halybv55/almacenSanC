namespace AlmacenS.Core.Entities
{
    public class AlertaReabastecimiento
    {
        public int Id { get; set; }

        public string CodigoProducto { get; set; } = "";
        public DateTime Fecha { get; set; } = DateTime.UtcNow;

        public string Estado { get; set; } = "Pendiente";
        public string? Mensaje { get; set; }
    }
}
