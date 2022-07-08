using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SportWord.Core.Domain.Models;

namespace SportWord.Adaptors.SQLServerDataAccess.Entities
{
    public class EProducto_Categoria : IEntityTypeConfiguration<Productos_Categorias>
    {
        public void Configure(EntityTypeBuilder<Productos_Categorias> builder)
        {
            builder.ToTable("Productos_Categorias");
            builder.HasKey(p => new { p.producto_id, p.categoria_id });

            builder
                .HasOne(p => p.Productos)
                .WithMany(prom => prom.productos_Categorias);

            builder
                .HasOne(p => p.Categorias)
                .WithMany(ca => ca.Productos_Categorias);
        }
    }
}
