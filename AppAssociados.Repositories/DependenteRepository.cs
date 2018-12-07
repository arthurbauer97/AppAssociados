using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAssociados.Domain;
using AppAssociados.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppAssociados.Repositories
{
    public class DependenteRepository : IDependenteRepository
    {
        private DataContext context;

        public DependenteRepository(DataContext context)
        {
            this.context = context;
        }

        public void Create(Dependente obj)
        {
            obj.associado = context.Associado.Find(obj.associado.id);
            obj.parentesco = context.Parentesco.Find(obj.parentesco.id);
            context.Dependente.Add(obj);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Dependente.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<Dependente> GetAll()
        {
            return context.Dependente.Include(a => a.associado).Include(p => p.parentesco).ToList();
        }
        public Dependente GetById(int id)
        {
            return context.Dependente.Include(a => a.associado).Include(p => p.parentesco).SingleOrDefault(x => x.id == id);
        }

          public Task<List<Dependente>> GetAllAsync()
        {
            return context.Dependente.ToListAsync();
        }

         public Task<Dependente> GetByIdAsync(int id)
        {
            return context.Dependente.SingleOrDefaultAsync(x => x.id == id);
        }

        public void Update(Dependente obj)
        {
            obj.associado = context.Associado.Find(obj.associado.id);
            obj.parentesco = context.Parentesco.Find(obj.parentesco.id);
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}