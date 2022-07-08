using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SportWord.Core.Domain.Models;

namespace SportWord.Adaptors.SQLServerDataAccess.Entities
{
    public class ECategoria : IEntityTypeConfiguration<Categorias>
    {
        public void Configure(EntityTypeBuilder<Categorias> builder)
        {
            builder.ToTable("Categorias");
            builder.HasKey(ca => ca.categoria_id);

            builder
                .HasMany(p => p.Productos_Categorias)
                .WithOne(ca => ca.Categorias);
        }
    }
}
