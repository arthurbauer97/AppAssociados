using System.Collections.Generic;
using AppAssociados.Domain;
using AppAssociados.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppAssociados.API.Controllers
{
    [Route("api/[controller]")]
    public class ParentescoController : Controller
    {
        private readonly IParentescoRepository repository;

        public ParentescoController(IParentescoRepository repository) {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Parentesco> Get()
        {
            return this.repository.GetAll();
        }

        [HttpGet("{id}")]
        public Parentesco Get(int id)
        {
            return this.repository.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Parentesco parentesco)
        {
            this.repository.Create(parentesco);
            return Ok(parentesco);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Parentesco parentesco)
        {
            this.repository.Update(parentesco);
            return Ok(parentesco);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.repository.Delete(id);
            return Ok(new {
                message = "Deletado com sucesso!"
            });
        }
    }
}