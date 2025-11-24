namespace AlmacenS.Core.Entities
{
    public class DevolucionProducto
    {
        public int Id { get; set; }

        public string CodigoProducto { get; set; } = ""; // Producto
        public string Codigo { get; set; } = "";         // Código de devolución
        public int CantidadBuena { get; set; }

        public string Estado { get; set; } = "";
        public string? Descripcion { get; set; }

        public DateTime Fecha { get; set; } = DateTime.UtcNow;
    }
}
