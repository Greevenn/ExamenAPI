using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SportWord.Core.Domain.Models;

namespace SportWord.Adaptors.SQLServerDataAccess.Entities
{
    public class ECarrito : IEntityTypeConfiguration<Carrito>
    {
        public void Configure(EntityTypeBuilder<Carrito> builder)
        {
            builder.ToTable("Carrito");
            builder.HasKey(c => c.carrito_id);

            builder
                .HasMany(p => p.carrito_productos)
                .WithOne(c => c.Carrito);
        }
    }
}
