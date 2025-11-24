namespace AlmacenS.Core.Entities
{
    public class Producto
    {
        public int Id { get; set; }

        public string Codigo { get; set; } = "";
        public string Nombre { get; set; } = "";

        public int Cantidad { get; set; }
        public int StockMinimo { get; set; }
    }
}
