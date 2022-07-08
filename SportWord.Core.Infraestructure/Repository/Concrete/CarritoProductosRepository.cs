using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Infraestructure.Repository.Abstract;
using SportWord.Core.Domain.Models;
using SportWord.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace SportWord.Core.Infraestructure.Repository.Concrete
{
    public class CarritoProductosRepository : IDetailRepository<Carrito_Productos, Guid>
    {
        private DB db;
        public CarritoProductosRepository(DB db)
        {
            this.db = db;
        }

        public void Cancel(Guid trasactionId)
        {
            var selectedCarrito = GetDetailsByTransaction(trasactionId);
            if (selectedCarrito != null)
            {
                selectedCarrito.ForEach(detail =>
                {
                    db.carrito_productos.Remove(detail);
                });
            }
            else
                throw new NullReferenceException("No se ha encontrado carrito para eliminar");
        }

        public Carrito_Productos Create(Carrito_Productos entity)
        {
            db.carrito_productos.Add(entity);
            return entity;
        }

        public List<Carrito_Productos> GetDetailsByTransaction(Guid trasactionId)
        {
            var selectedCarrito = db.carrito_productos
                .Where(ads => ads.carrito_id == trasactionId)
                .ToList();
            return selectedCarrito;
        }

        public void saveAllChanges()
        {
            throw new NotImplementedException();
        }
    }
}
