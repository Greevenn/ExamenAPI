using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SportWord.Core.Domain.Models;
namespace SportWord.Adaptors.SQLServerDataAccess.Entities
{
    public class EProducto : IEntityTypeConfiguration<Productos>
    {
        public void Configure(EntityTypeBuilder<Productos> builder)
        {
            builder.ToTable("Productos");
            builder.HasKey(c => c.producto_id);

            builder
                .HasMany(p => p.carrito_productos)
                .WithOne(c => c.Productos);

            builder
                .HasMany(p => p.productos_Categorias)
                .WithOne(c => c.Productos);
        }
    }
}
