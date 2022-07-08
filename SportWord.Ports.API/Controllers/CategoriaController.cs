using Microsoft.AspNetCore.Mvc;
using SportWord.Adaptors.SQLServerDataAccess.Contexts;
using SportWord.Core.Application.UseCases;
using SportWord.Core.Infraestructure.Repository.Concrete;
using SportWord.Core.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportWord.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        public CategoriaUseCasecs CreateService()
        {
            DB db = new DB();
            //INSTANCIANDO EL CONTEXTO
            CategoriaRepository repository = new CategoriaRepository(db);
            //llamando al repositorio concreto y mandando como argumento el contexto
            CategoriaUseCasecs service = new CategoriaUseCasecs(repository);
            //Definiedo el servicio y pasandolo como parametro el repositorio
            return service;
        }
        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<IEnumerable<Categorias>> Get()
        {
            CategoriaUseCasecs service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<Categorias> Get(Guid id)
        {
            CategoriaUseCasecs service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] Categorias categoria)
        {
            CategoriaUseCasecs service = CreateService();
            var result = service.Create(categoria);
            return Ok(result);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Categorias categoria)
        {
            CategoriaUseCasecs service = CreateService();
            categoria.categoria_id = id;
            service.Update(categoria);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            CategoriaUseCasecs service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }


    }
}
