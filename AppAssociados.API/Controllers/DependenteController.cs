using System.Collections.Generic;
using AppAssociados.Domain;
using AppAssociados.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppAssociados.API.Controllers
{
    [Route("api/[controller]")]
    public class DependenteController : Controller
    {
        private readonly IDependenteRepository repository;

        public DependenteController(IDependenteRepository repository) {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Dependente> Get()
        {
            return this.repository.GetAll();
        }

        [HttpGet("{id}")]
        public Dependente Get(int id)
        {
            return this.repository.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Dependente dependente)
        {
            this.repository.Create(dependente);
            return Ok(dependente);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Dependente dependente)
        {
            this.repository.Update(dependente);
            return Ok(dependente);
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