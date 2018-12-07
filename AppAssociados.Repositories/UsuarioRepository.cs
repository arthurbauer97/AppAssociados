using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAssociados.Domain;
using AppAssociados.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppAssociados.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        
        private DataContext context;

        public UsuarioRepository(DataContext context)
        {
            this.context = context;
        }

        public void Create(Usuario obj)
        {
            context.Usuario.Add(obj);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Usuario.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<Usuario> GetAll()
        {
            return context.Usuario.ToList();
        }

        public Usuario GetById(int id)
        {
            return context.Usuario.SingleOrDefault(x => x.id == id);
        }

          public Task<List<Usuario>> GetAllAsync()
        {
            return context.Usuario.ToListAsync();
        }

         public Task<Usuario> GetByIdAsync(int id)
        {
            return context.Usuario.SingleOrDefaultAsync(x => x.id == id);
        }

        public void Update(Usuario obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public Usuario AuthUser(Usuario user)
        {
            return context
                .Usuario
                .SingleOrDefault(i => i.usuario == user.usuario &&
                                        i.senha == user.senha);
        }
    }
}