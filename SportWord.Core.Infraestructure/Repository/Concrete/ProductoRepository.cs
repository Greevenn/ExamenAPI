using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Infraestructure.Repository.Abstract;
using SportWord.Core.Domain.Models;
using SportWord.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace SportWord.Core.Infraestructure.Repository.Concrete
{
    public class ProductoRepository : IBaseRepository<Productos, Guid>
    {
        private DB db; //Constructor
        public ProductoRepository(DB db)
        {
            this.db = db;
        }
        public Productos Create(Productos productos)
        {
            productos.producto_id = Guid.NewGuid();
            //define nuevo identificador unico
            db.Productos.Add(productos);
            return productos;
        }

        public void Delete(Guid entityId)
        {
            var selectedProducto = db.Productos
                .Where(u => u.producto_id == entityId).FirstOrDefault();
            //selecciona el producto a traves del Id
            if (selectedProducto != null)
                //verificar si el producto existe
                db.Productos.Remove(selectedProducto);
        }

        public List<Productos> GetAll()
        {
            return db.Productos.ToList();
        }

        public Productos GetById(Guid entityId)
        {
            var selectedproducto = db.Productos
                .Where(u => u.producto_id == entityId).FirstOrDefault();
            return selectedproducto;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Productos Update(Productos producto)
        {
            var selectedproducto = db.Productos
                .Where(u => u.producto_id == producto.producto_id)
                .FirstOrDefault();
            //selecciona el producto por el Id en la base de datos
            if(selectedproducto != null)
            //verifica que el producto exista
            {
                selectedproducto.nombre = producto.nombre;
                selectedproducto.imagen = producto.imagen;
                selectedproducto.descripcion = producto.descripcion;
                selectedproducto.precio = producto.precio;
                selectedproducto.stock = producto.stock;
                //modifica los datos del producto con los  valores del parametro
                db.Entry(selectedproducto).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                //Enmarcar el estado del producto como modificado
            }
            return selectedproducto;
        }
    }
}
