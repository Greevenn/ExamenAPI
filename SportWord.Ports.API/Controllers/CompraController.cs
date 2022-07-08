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
    public class CompraController : ControllerBase
    {

        public CompraUseCase CreateService()
        {
            DB db = new DB();
            //INSTANCIANDO EL CONTEXTO
            CompraRepository repository = new CompraRepository(db);
            //llamando al repositorio concreto y mandando como argumento el contexto
            CompraUseCase service = new CompraUseCase(repository);
            //Definiedo el servicio y pasandolo como parametro el repositorio
            return service;
        }
        // GET: api/<UserController>
        [HttpGet]
       
      
        public ActionResult<IEnumerable<Compra>> Get()
        {
            CompraUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<Compra> Get(Guid id)
        {
            CompraUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<Compra> Post([FromBody] Compra compra)
        {
            CompraUseCase service = CreateService();
            var result = service.Create(compra);
            return Ok(result);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Compra compra)
        {
            CompraUseCase service = CreateService();
            compra.compra_id = id;
            service.Update(compra);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            CompraUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }


    }
}
