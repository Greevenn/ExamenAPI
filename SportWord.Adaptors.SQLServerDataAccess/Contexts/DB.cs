using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SportWord.Core.Domain.Models;
using SportWord.Adaptors.SQLServerDataAccess.Entities;
using SportWord.Adaptors.SQLServerDataAccess.Utils;

namespace SportWord.Adaptors.SQLServerDataAccess.Contexts
{
    public class DB : DbContext
    {
        public DbSet<User> Users { get; set;}
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<Carrito_Productos> carrito_productos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Productos_Categorias> productos_Categorias { get; set; }
        public DbSet<Promocion> Promocion { get; set; }
        public DbSet<Tiendas> Tiendas { get; set; }
        public DbSet<User_Producto> user_producto { get; set; }
        public DbSet<User_Tienda> User_Tienda { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new EUser());
            builder.ApplyConfiguration(new ECompra());
            builder.ApplyConfiguration(new ECarrito_Producto());
            builder.ApplyConfiguration(new ECategoria());
            builder.ApplyConfiguration(new EProducto_Categoria());
            builder.ApplyConfiguration(new ETiendas());
            builder.ApplyConfiguration(new ECarrito());
            builder.ApplyConfiguration(new EProducto());
            builder.ApplyConfiguration(new EPromocion());
            builder.ApplyConfiguration(new EUser_Tienda());
            builder.ApplyConfiguration(new EUsuario_Producto());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(GlobalSetting.sqlServerConnectionString);
        }
    }
}
