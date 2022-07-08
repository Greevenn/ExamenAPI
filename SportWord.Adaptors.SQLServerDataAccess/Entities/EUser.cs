using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SportWord.Core.Domain.Models;

namespace SportWord.Adaptors.SQLServerDataAccess.Entities
{
    public class EUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.usuario_id);

            builder
                .HasMany(comp => comp.Compras)
                .WithOne(u => u.Users);

            builder
               .HasMany(ut => ut.User_Tienda)
               .WithOne(u => u.User);

        }
    }
}
