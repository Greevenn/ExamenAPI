using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Infraestructure.Repository.Abstract;
using SportWord.Core.Domain.Models;
using SportWord.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;


namespace SportWord.Core.Infraestructure.Repository.Concrete
{
   
    public class TiendasRepository : IBaseRepository<Tiendas, Guid>
    {
        private DB db; //Constructor
        public TiendasRepository(DB db)
        {
            this.db = db;
        }
        public Tiendas Create(Tiendas tienda)
        {
            tienda.tienda_id = Guid.NewGuid();
            //define nuevo identificador unico
            db.Tiendas.Add(tienda);
            return tienda;
        }

        public void Delete(Guid entityId)
        {
            var selectedTienda = db.Tiendas
               .Where(u => u.tienda_id == entityId).FirstOrDefault();
            //selecciona el producto a traves del Id
            if (selectedTienda != null)
                //verificar si el producto existe
                db.Tiendas.Remove(selectedTienda);
        }

        public List<Tiendas> GetAll()
        {
            return db.Tiendas.ToList();
        }

        public Tiendas GetById(Guid entityId)
        {
            var selectedTienda = db.Tiendas
               .Where(u => u.tienda_id == entityId).FirstOrDefault();
            return selectedTienda;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Tiendas Update(Tiendas entity)
        {
            throw new NotImplementedException();
        }
    }
}
