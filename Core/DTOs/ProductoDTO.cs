namespace AlmacenS.Core.DTOs
{
    public class ProductoDTO
    {
        public string Codigo { get; set; } = "";
        public string Nombre { get; set; } = "";
        
        public int StockMinimo { get; set; }
    }
}
