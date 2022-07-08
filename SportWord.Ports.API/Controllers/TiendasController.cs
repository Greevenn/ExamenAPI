using Microsoft.AspNetCore.Mvc;
using SportWord.Adaptors.SQLServerDataAccess.Contexts;
using SportWord.Core.Application.UseCases;
using SportWord.Core.Infraestructure.Repository.Concrete;
using SportWord.Core.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
namespace SportWord.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendasController : Controller
    {
        public TiendasUseCase CreateService()
        {
            DB db = new DB();
            //INSTANCIANDO EL CONTEXTO
            TiendasRepository repository = new TiendasRepository(db);
            //llamando al repositorio concreto y mandando como argumento el contexto
            TiendasUseCase service = new TiendasUseCase(repository);
            //Definiedo el servicio y pasandolo como parametro el repositorio
            return service;
        }
        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<IEnumerable<Tiendas>> Get()
        {
            TiendasUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<Tiendas> Get(Guid id)
        {
            TiendasUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<Tiendas> Post([FromBody] Tiendas tienda)
        {
            TiendasUseCase service = CreateService();
            var result = service.Create(tienda);
            return Ok(result);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Tiendas tienda)
        {

            TiendasUseCase service = CreateService();
            tienda.tienda_id = id;
            service.Update(tienda);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            TiendasUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}