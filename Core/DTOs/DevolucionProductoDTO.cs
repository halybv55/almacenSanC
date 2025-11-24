namespace AlmacenS.Core.DTOs
{
    public class DevolucionProductoDTO
    {
        public string CodigoProducto { get; set; } = "";  // Producto devuelto
        public string Codigo { get; set; } = "";          // Código de operación de devolución
        public int CantidadBuena { get; set; }

        public string Estado { get; set; } = "";
        public string? Descripcion { get; set; }
    }
}
