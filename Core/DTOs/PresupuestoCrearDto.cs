namespace AlmacenS.Core.DTOs
{
    public class PresupuestoCrearDto
    {
        public string Departamento { get; set; }
        public decimal MontoTotal { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
    }
}
