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
    public class ProductoController : Controller
    {
        public ProductoUseCase CreateService()
        {
            DB db = new DB();
            //INSTANCIANDO EL CONTEXTO
            ProductoRepository repository = new ProductoRepository(db);
            //llamando al repositorio concreto y mandando como argumento el contexto
            ProductoUseCase service = new ProductoUseCase(repository);
            //Definiedo el servicio y pasandolo como parametro el repositorio
            return service;
        }
        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<IEnumerable<Productos>> Get()
        {
            ProductoUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<Productos> Get(Guid id)
        {
            ProductoUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<Productos> Post([FromBody] Productos productos)
        {
            var base64array = Convert.FromBase64String(productos.imagen);
            Guid name = Guid.NewGuid();
            string filePashString = $"Content/img/{name}.png";
            var filePath = Path.Combine($"Content/img/{name}.png");
            System.IO.File.WriteAllBytes(filePath, base64array);

            ProductoUseCase service = CreateService();
            productos.imagen = filePashString;
            var result = service.Create(productos);

            return Ok(result);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Productos productos)
        {
            var base64array = Convert.FromBase64String(productos.imagen);
            Guid name = Guid.NewGuid();
            string filePashString = $"Content/img/{name}.png";
            var filePath = Path.Combine($"Content/img/{name}.png");
            System.IO.File.WriteAllBytes(filePath, base64array);

            ProductoUseCase service = CreateService();
            productos.imagen = filePashString;
            productos.producto_id = id;
            service.Update(productos);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            ProductoUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
