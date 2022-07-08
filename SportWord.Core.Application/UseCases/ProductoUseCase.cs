using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Domain.Models;
using SportWord.Core.Application.Interfaces;
using SportWord.Core.Infraestructure.Repository.Abstract;

namespace SportWord.Core.Application.UseCases
{
    public class ProductoUseCase : IBaseUseCase<Productos, Guid>
    {
        private readonly IBaseRepository<Productos, Guid> repository;
        public ProductoUseCase(IBaseRepository<Productos, Guid> repository)
        {
            this.repository = repository;
        }
        public Productos Create(Productos entity)
        {
            if (entity != null)
            //verifica que el objeto sea valido
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                //devuelve nueva ecepcion en caso de ser error
                throw new Exception("Error. El producto no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Productos> GetAll()
        {
            return repository.GetAll();
        }

        public Productos GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Productos Update(Productos entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
