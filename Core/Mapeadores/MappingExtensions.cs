using AlmacenS.Core.DTOs;
using AlmacenS.Core.Entities;

namespace AlmacenS.Core.Mapeadores
{
    public static class MappingExtensions
    {
        // ============================================================
        //  ALERTA REABASTECIMIENTO
        // ============================================================
        public static AlertaReabastecimientoDTO ToDTO(this AlertaReabastecimiento a)
            => new AlertaReabastecimientoDTO
            {
                CodigoProducto = a.CodigoProducto,
                Mensaje = a.Mensaje
            };

        public static AlertaReabastecimiento ToEntity(this AlertaReabastecimientoDTO dto)
            => new AlertaReabastecimiento
            {
                CodigoProducto = dto.CodigoProducto,
                Mensaje = dto.Mensaje
            };

        // ============================================================
        //  CARGA PRODUCTO
        // ============================================================
        public static CargaProductoDTO ToDTO(this CargaProducto c)
            => new CargaProductoDTO
            {
                CodigoProducto = c.CodigoProducto,
                Codigo = c.Codigo,
                CantidadBuena = c.CantidadBuena
            };

        public static CargaProducto ToEntity(this CargaProductoDTO dto)
            => new CargaProducto
            {
                CodigoProducto = dto.CodigoProducto,
                Codigo = dto.Codigo,
                CantidadBuena = dto.CantidadBuena
            };

        // ============================================================
        //  DEVOLUCIÓN PRODUCTO
        // ============================================================
        public static DevolucionProductoDTO ToDTO(this DevolucionProducto d)
            => new DevolucionProductoDTO
            {
                CodigoProducto = d.CodigoProducto,
                Codigo = d.Codigo,
                CantidadBuena = d.CantidadBuena,
                Estado = d.Estado,
                Descripcion = d.Descripcion
            };

        public static DevolucionProducto ToEntity(this DevolucionProductoDTO dto)
            => new DevolucionProducto
            {
                CodigoProducto = dto.CodigoProducto,
                Codigo = dto.Codigo,
                CantidadBuena = dto.CantidadBuena,
                Estado = dto.Estado,
                Descripcion = dto.Descripcion
            };

        // ============================================================
        //  INVENTARIO ENTRADA
        // ============================================================
        public static InventarioEntradaDTO ToDTO(this InventarioEntrada e)
            => new InventarioEntradaDTO
            {
                CodigoProducto = e.CodigoProducto,
                Cantidad = e.Cantidad,
                Observaciones = e.Observaciones,
                FechaEntrada = e.Fecha
            };

        public static InventarioEntrada ToEntity(this InventarioEntradaDTO dto)
            => new InventarioEntrada
            {
                CodigoProducto = dto.CodigoProducto,
                Cantidad = dto.Cantidad,
                Observaciones = dto.Observaciones,
                Fecha = dto.FechaEntrada
            };

        // ============================================================
        //  PRODUCTO
        // ============================================================
        public static ProductoDTO ToDTO(this Producto p)
            => new ProductoDTO
            {
                Codigo = p.Codigo,
                Nombre = p.Nombre,
                StockMinimo = p.StockMinimo
            };

        public static Producto ToEntity(this ProductoDTO dto)
            => new Producto
            {
                Codigo = dto.Codigo,
                Nombre = dto.Nombre,
                StockMinimo = dto.StockMinimo
            };
        public static ProductoCatalogoDTO ToCatalogoDTO(this Producto p)
        {
            return new ProductoCatalogoDTO
            {
                Codigo = p.Codigo,
                Nombre = p.Nombre
            };
        }

    }
}
