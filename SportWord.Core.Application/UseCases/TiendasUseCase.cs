using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Domain.Models;
using SportWord.Core.Application.Interfaces;
using SportWord.Core.Infraestructure.Repository.Abstract;

namespace SportWord.Core.Application.UseCases
{
    public class TiendasUseCase : IBaseRepository<Tiendas, Guid>
    {
        private readonly IBaseRepository<Tiendas, Guid> repository;
        public TiendasUseCase(IBaseRepository<Tiendas, Guid> repository)
        {
            this.repository = repository;
        }
        public Tiendas Create(Tiendas entity)
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
                throw new Exception("Error. El usuario no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Tiendas> GetAll()
        {
            return repository.GetAll();
        }

        public Tiendas GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public void saveAllChanges()
        {
            throw new NotImplementedException();
        }

        public Tiendas Update(Tiendas entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
