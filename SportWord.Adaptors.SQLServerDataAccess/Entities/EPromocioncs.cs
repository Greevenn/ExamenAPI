using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SportWord.Core.Domain.Models;

namespace SportWord.Adaptors.SQLServerDataAccess.Entities
{
    public class EPromocion : IEntityTypeConfiguration<Promocion>
    {
        public void Configure(EntityTypeBuilder<Promocion> builder)
        {
            builder.ToTable("Promocion");
            builder.HasKey(prom => prom.promocion_id);

            builder
                .HasMany(p => p.Productos)
                .WithOne(prom => prom.Promocion);
        }
    }
}
