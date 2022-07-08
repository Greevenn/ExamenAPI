using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SportWord.Core.Domain.Models;


namespace SportWord.Adaptors.SQLServerDataAccess.Entities
{
    public class EUser_Tienda : IEntityTypeConfiguration<User_Tienda>
    {
        public void Configure(EntityTypeBuilder<User_Tienda> builder)
        {
            builder.ToTable("User_Tienda");
            builder.HasKey(u => new { u.usuario_id, u.tienda_id });

            builder
                .HasOne(u => u.User)
                .WithMany(prom => prom.User_Tienda);

            builder
                .HasOne(u => u.Tiendas)
                .WithMany(ut => ut.User_Tienda);
        }
    }
}
