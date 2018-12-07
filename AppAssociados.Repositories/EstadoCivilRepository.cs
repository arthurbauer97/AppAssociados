using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAssociados.Domain;
using AppAssociados.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppAssociados.Repositories
{
    public class EstadoCivilRepository : IEstadoCivilRepository
    {

        private DataContext context;

        public EstadoCivilRepository(DataContext context)
        {
            this.context = context;
        }

        public void Create(EstadoCivil obj)
        {
            context.EstadoCivil.Add(obj);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.EstadoCivil.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<EstadoCivil> GetAll()
        {
            return context.EstadoCivil.ToList();
        }

        public EstadoCivil GetById(int id)
        {
            return context.EstadoCivil.SingleOrDefault(x => x.id == id);
        }

          public Task<List<EstadoCivil>> GetAllAsync()
        {
            return context.EstadoCivil.ToListAsync();
        }

         public Task<EstadoCivil> GetByIdAsync(int id)
        {
            return context.EstadoCivil.SingleOrDefaultAsync(x => x.id == id);
        }
        public void Update(EstadoCivil obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}