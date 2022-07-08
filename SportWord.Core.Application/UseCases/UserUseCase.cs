using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Domain.Models;
using SportWord.Core.Application.Interfaces;
using SportWord.Core.Infraestructure.Repository.Abstract;

namespace SportWord.Core.Application.UseCases
{
    public class UserUseCase : IBaseUseCase<User, Guid> //extender caso de uso base
    {
        private readonly IBaseRepository<User, Guid> repository;

        public UserUseCase(IBaseRepository<User, Guid> repository)
        {
            this.repository = repository;
        }

        public User Create(User entity) //definir la logica del negocio
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

        public List<User> GetAll() //metodo de listar todos los registros
        {
            return repository.GetAll();
        }

        public User GetById(Guid entityId) //metodo para listar por Id
        {
            return repository.GetById(entityId);
        }

        public User Update(User entity)
        {
           repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
       
}
}
