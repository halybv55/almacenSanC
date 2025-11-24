namespace AlmacenS.Core.Entities
{
    public class CargaProducto
    {
        public int Id { get; set; }

        public string CodigoProducto { get; set; } = "";  // Producto real
        public string Codigo { get; set; } = "";          // Código de la operación
        public int CantidadBuena { get; set; }

        public DateTime Fecha { get; set; } = DateTime.UtcNow;
    }
}
