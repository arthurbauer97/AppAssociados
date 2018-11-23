using System.Collections.Generic;
using AppAssociados.Domain;
using AppAssociados.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppAssociados.API.Controllers
{
    [Route("api/[controller]")]
    public class AssociadoController : Controller
    {
        private readonly IAssociadoRepository repository;

        public AssociadoController(IAssociadoRepository repository) {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Associado> Get()
        {
            return this.repository.GetAll();
        }

        [HttpGet("{id}")]
        public Associado Get(int id)
        {
            return this.repository.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Associado associado)
        {
            this.repository.Create(associado);
            return Ok(associado);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Associado associado)
        {
            this.repository.Update(associado);
            return Ok(associado);
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