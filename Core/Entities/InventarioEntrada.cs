namespace AlmacenS.Core.Entities
{
    public class InventarioEntrada
    {
        public int Id { get; set; }

        public string CodigoProducto { get; set; } = "";  // Código del producto
        public int Cantidad { get; set; }

        public string Observaciones { get; set; } = "";
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
    }
}
