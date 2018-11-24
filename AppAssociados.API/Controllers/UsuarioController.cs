using System.Collections.Generic;
using AppAssociados.Domain;
using AppAssociados.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace AppAssociados.API.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {   
         private readonly IUsuarioRepository repository;

        public UsuarioController(IUsuarioRepository repository) {
            this.repository = repository;
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return this.repository.GetAll();
        }

        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            return this.repository.GetById(id);
        }

          [Authorize]
           [HttpPost]
        public IActionResult Post([FromBody]Usuario item)
            {
        if (ModelState.IsValid)
        {
                this.repository.Create(item);
                return Ok(item);
        }
        else
        {		
            var errors = new List<string>();
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }

            return BadRequest(new {
                message = errors
            });
        }
    }
        
            [HttpPut]
            public IActionResult Put([FromBody]Usuario usuario)
            {
                this.repository.Update(usuario);
                return Ok(usuario);
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                this.repository.Delete(id);
                return Ok(new {
                    message = "Deletado com sucesso!"
                });
            }
        
         [HttpPost("authenticate")]
         public IActionResult Authentication ([FromBody]Usuario user)
         {
             var usuario = this.repository.AuthUser(user);

             if (usuario == null)
                return BadRequest (new{
                    message = "Usuário Incorreto!"
                }
                );
            return Ok(new{
                token = BuildToken()
            });
         }
        public string BuildToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TokenLoginTeste123"));
            var creed = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                audience: "AppLoginAssociados",
                issuer: "AppLoginAssociados",
                signingCredentials: creed
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}