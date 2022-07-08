using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Infraestructure.Repository.Abstract;
using SportWord.Core.Domain.Models;
using SportWord.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace SportWord.Core.Infraestructure.Repository.Concrete
{
    public class UserTiendasRepository : IDetailRepository<User_Tienda, Guid>
    {
        private DB db;
        public UserTiendasRepository(DB db)
        {
            this.db = db;
        }
        public void Cancel(Guid trasactionId)
        {
            var selectedTienda = GetDetailsByTransaction(trasactionId);
            if (selectedTienda != null)
            {
                selectedTienda.ForEach(detail =>
                {
                    db.User_Tienda.Remove(detail);
                });
            }
            else
                throw new NullReferenceException("No se ha encontrado una tineda para eliminar");
        }

        public User_Tienda Create(User_Tienda entity)
        {
            db.User_Tienda.Add(entity);
            return entity;
        }

        public List<User_Tienda> GetDetailsByTransaction(Guid trasactionId)
        {
            var selectedTienda = db.User_Tienda
            .Where(ads => ads.tienda_id == trasactionId)
            .ToList();
            return selectedTienda;
        }

        public void saveAllChanges()
        {
            throw new NotImplementedException();
        }
    }
}
