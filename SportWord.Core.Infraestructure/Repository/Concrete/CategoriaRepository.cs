using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Infraestructure.Repository.Abstract;
using SportWord.Core.Domain.Models;
using SportWord.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;


namespace SportWord.Core.Infraestructure.Repository.Concrete
{
    public class CategoriaRepository : IBaseRepository<Categorias, Guid>
    {
        private DB db; //Constructor
        public CategoriaRepository(DB db)
        {
            this.db = db;
        }
        public Categorias Create(Categorias categoria)
        {
            categoria.categoria_id = Guid.NewGuid();
            //define nuevo identificador unico
            db.Categorias.Add(categoria);
            return categoria;
        }

        public void Delete(Guid entityId)
        {
            var selectedCategoria = db.Categorias
               .Where(u => u.categoria_id == entityId).FirstOrDefault();
            //selecciona el producto a traves del Id
            if (selectedCategoria != null)
                //verificar si el producto existe
                db.Categorias.Remove(selectedCategoria);
        }

        public List<Categorias> GetAll()
        {
            return db.Categorias.ToList();
        }

        public Categorias GetById(Guid entityId)
        {
            var selectedCategoria = db.Categorias
             .Where(u => u.categoria_id == entityId).FirstOrDefault();
            return selectedCategoria;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Categorias Update(Categorias entity)
        {
            throw new NotImplementedException();
        }
    }
}
