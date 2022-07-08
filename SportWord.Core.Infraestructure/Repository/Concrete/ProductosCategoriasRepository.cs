using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Infraestructure.Repository.Abstract;
using SportWord.Core.Domain.Models;
using SportWord.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace SportWord.Core.Infraestructure.Repository.Concrete
{
    public class ProductosCategoriasRepository : IDetailRepository<Productos_Categorias, Guid>
    {
        private DB db;
        public ProductosCategoriasRepository(DB db)
        {
            this.db = db;
        }
        public void Cancel(Guid trasactionId)
        {
            var selectedCategoria = GetDetailsByTransaction(trasactionId);
            if (selectedCategoria != null)
            {
                selectedCategoria.ForEach(detail =>
                {
                    db.productos_Categorias.Remove(detail);
                });
            }
            else
                throw new NullReferenceException("No se ha encontrado una categoria para eliminar");
        }

        public Productos_Categorias Create(Productos_Categorias entity)
        {
            db.productos_Categorias.Add(entity);
            return entity;
        }

        public List<Productos_Categorias> GetDetailsByTransaction(Guid trasactionId)
        {
            var selectedCategoria = db.productos_Categorias
            .Where(ads => ads.categoria_id == trasactionId)
            .ToList();
            return selectedCategoria;
        }

        public void saveAllChanges()
        {
            throw new NotImplementedException();
        }
    }
}
