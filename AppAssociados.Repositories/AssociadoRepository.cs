using System.Collections.Generic;
using System.Linq;
using AppAssociados.Domain;
using AppAssociados.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppAssociados.Repositories
{
    public class AssociadoRepository : IAssociadoRepository
    {

        private DataContext context;

        public AssociadoRepository(DataContext context)
        {
            this.context = context;
        }

        public void Create(Associado obj)
        {
            obj.estadoCivil = context.EstadoCivil.Find(obj.estadoCivil.id);
            context.Associado.Add(obj);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Associado.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<Associado> GetAll()
        {
            return context.Associado.Include(e => e.estadoCivil).ToList();
        }

        public Associado GetById(int id)
        {
            return context.Associado.Include(e => e.estadoCivil).SingleOrDefault(x => x.id == id);
        }

        public void Update(Associado obj)
        {
            obj.estadoCivil = context.EstadoCivil.Find(obj.estadoCivil.id);
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}