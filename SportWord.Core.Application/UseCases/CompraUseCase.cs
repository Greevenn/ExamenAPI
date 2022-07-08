using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Domain.Models;
using SportWord.Core.Application.Interfaces;
using SportWord.Core.Infraestructure.Repository.Abstract;

namespace SportWord.Core.Application.UseCases
{
    public class CompraUseCase : IBaseRepository<Compra, Guid>
    {
        private readonly IBaseRepository<Compra, Guid> repository;
        public CompraUseCase(IBaseRepository<Compra, Guid> repository)
        {
            this.repository = repository;
        }

        public Compra Create(Compra entity) //definir la logica del negocio
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
        public List<Compra> GetAll() //metodo de listar todos los registros
        {
            return repository.GetAll();
        }
        public Compra GetById(Guid entityId) //metodo para listar por Id
        {
            return repository.GetById(entityId);
        }
        public void saveAllChanges()
        {
            throw new NotImplementedException();
        }

        public Compra Update(Compra entity)
        {
            throw new NotImplementedException();
        }
    }
}
