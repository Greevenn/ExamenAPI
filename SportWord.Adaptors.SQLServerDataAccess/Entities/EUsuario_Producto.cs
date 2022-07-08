using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SportWord.Core.Domain.Models;

namespace SportWord.Adaptors.SQLServerDataAccess.Entities
{
    public class EUsuario_Producto : IEntityTypeConfiguration<User_Producto>
    {
        public void Configure(EntityTypeBuilder<User_Producto> builder)
        {
            builder.ToTable("User_Producto");
            builder.HasKey(up => new { up.usuario_id, up.producto_id });

            builder

               .HasOne(u => u.User)
               .WithMany(up => up.user_producto);

            builder
               .HasOne(u => u.Productos)
               .WithMany(pu => pu.user_producto);
        }
    }
}
