using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlmacenS.Core.Entities;

namespace AlmacenS.Infrastructure.Data
{
    public class AlmacenSContext : DbContext
    {
        public AlmacenSContext (DbContextOptions<AlmacenSContext> options)
            : base(options)
        {
        }

        public DbSet<AlertaReabastecimiento> AlertaReabastecimiento { get; set; } = default!;
        public DbSet<CargaProducto> CargaProducto { get; set; } = default!;
        public DbSet<DevolucionProducto> DevolucionProducto { get; set; } = default!;
        public DbSet<InventarioEntrada> InventarioEntrada { get; set; } = default!;
        public DbSet<Producto> Producto { get; set; } = default!;
    }
}
