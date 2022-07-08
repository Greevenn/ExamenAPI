using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SportWord.Core.Domain.Models;

namespace SportWord.Adaptors.SQLServerDataAccess.Entities
{
    public class ETiendas : IEntityTypeConfiguration<Tiendas>
    {
        public void Configure(EntityTypeBuilder<Tiendas> builder)
        {
            builder.ToTable("Tiendas");
            builder.HasKey(t => t.tienda_id);

            builder
                .HasMany(p => p.User_Tienda)
                .WithOne(t => t.Tiendas);
        }
    }
}
