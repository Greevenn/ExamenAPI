using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Infraestructure.Repository.Abstract;
using SportWord.Core.Domain.Models;
using SportWord.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;
namespace SportWord.Core.Infraestructure.Repository.Concrete
{
    public class CompraRepository : IBaseRepository<Compra, Guid>
    {
        private DB db; //Constructor
        public CompraRepository(DB db)
        {
            this.db = db;
        }
        public Compra Create(Compra compra)
        {
            compra.compra_id = Guid.NewGuid();
            //define nuevo identificador unico
            db.Compras.Add(compra);
            return compra;
        }

        public void Delete(Guid entityId)
        {
            var selectedCompra = db.Compras
              .Where(u => u.compra_id == entityId).FirstOrDefault();
            //selecciona el producto a traves del Id
            if (selectedCompra != null)
                //verificar si el producto existe
                db.Compras.Remove(selectedCompra);
        }

        public List<Compra> GetAll()
        {
            return db.Compras.ToList();
        }

        public Compra GetById(Guid entityId)
        {
            var selectedCompra = db.Compras
                .Where(u => u.compra_id == entityId).FirstOrDefault();
            return selectedCompra;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Compra Update(Compra entity)
        {
            throw new NotImplementedException();
        }
    }
}
