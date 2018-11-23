using System.Collections.Generic;
using System.Linq;
using AppAssociados.Domain;
using AppAssociados.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppAssociados.Repositories
{
    public class ParentescoRepository : IParentescoRepository
    {
        private DataContext context;

        public ParentescoRepository(DataContext context)
        {
            this.context = context;
        }

        public void Create(Parentesco obj)
        {
            context.Parentesco.Add(obj);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Parentesco.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<Parentesco> GetAll()
        {
            return context.Parentesco.ToList();
        }

        public Parentesco GetById(int id)
        {
            return context.Parentesco.SingleOrDefault(x => x.id == id);
        }

        public void Update(Parentesco obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}