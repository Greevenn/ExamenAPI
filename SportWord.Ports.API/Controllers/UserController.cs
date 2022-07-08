using Microsoft.AspNetCore.Mvc;
using SportWord.Adaptors.SQLServerDataAccess.Contexts;
using SportWord.Core.Application.UseCases;
using SportWord.Core.Infraestructure.Repository.Concrete;
using SportWord.Core.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportWord.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public UserUseCase CreateService()
        {
            DB db = new DB();
            //INSTANCIANDO EL CONTEXTO
            UserRepository repository = new UserRepository(db);
            //llamando al repositorio concreto y mandando como argumento el contexto
            UserUseCase service = new UserUseCase(repository);
            //Definiedo el servicio y pasandolo como parametro el repositorio
            return service;
        }
        // GET: api/<UserController>
        [HttpGet]
       
        public ActionResult <IEnumerable<User>> Get()
        {
            UserUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult <User> Get(Guid id)
        {
            UserUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            UserUseCase service = CreateService();
            var result = service.Create(user);
            return Ok(result);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] User user)
        {
            UserUseCase service = CreateService();
            user.usuario_id = id;
            service.Update(user);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            UserUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
        
      
    }
}
