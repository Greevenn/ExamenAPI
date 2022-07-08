using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SportWord.Core.Domain.Models;

namespace SportWord.Adaptors.SQLServerDataAccess.Entities
{
    public class ECarrito_Producto : IEntityTypeConfiguration<Carrito_Productos>
    {
        public void Configure(EntityTypeBuilder<Carrito_Productos> builder)
        {
            builder.ToTable("Carrito_Productos");
            builder.HasKey(p => new { p.producto_id, p.carrito_id });

            builder
               .HasOne(p => p.Productos)
               .WithMany(car => car.carrito_productos);

            builder
                .HasOne(p => p.Carrito)
               .WithMany(ca => ca.carrito_productos);
        }
    }
}
