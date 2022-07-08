using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Domain.Models;
using SportWord.Core.Application.Interfaces;
using SportWord.Core.Infraestructure.Repository.Abstract;


namespace SportWord.Core.Application.UseCases
{
    public class ProductoCategoriasUseCase : IDetailUseCase<Categorias, Guid>
    {
        private readonly IBaseRepository<Categorias, Guid> CategoriasRepository;
        private readonly IDetailRepository<Productos_Categorias, Guid> ProductosCategoriasRepository;
        public ProductoCategoriasUseCase(
            IBaseRepository<Categorias, Guid> CategoriasRepository,
            IDetailRepository<Productos_Categorias, Guid> ProductosCategoriasRepository
            )
        {
            this.CategoriasRepository = CategoriasRepository;
            this.ProductosCategoriasRepository = ProductosCategoriasRepository;
        }
        public void Cancel(Guid entityId)
        {
            ProductosCategoriasRepository.Cancel(entityId);
            ProductosCategoriasRepository.saveAllChanges();
        }

        public Categorias Create(Categorias categorias)
        {
            var CreateCategoria = CategoriasRepository.Create(categorias);
            categorias.Productos_Categorias.ForEach(detail => {
                ProductosCategoriasRepository.Create(detail);
            });
            CategoriasRepository.saveAllChanges();
            return CreateCategoria;
        }
    }
}
