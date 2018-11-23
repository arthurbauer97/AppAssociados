using System.Collections.Generic;

namespace AppAssociados.Repositories.Interfaces
{
    public interface IRepositoryBase<Entity>
        where Entity:class
    {
        void Create(Entity obj);
        Entity GetById(int id);
        List<Entity> GetAll();
        void Update(Entity obj);
        void Delete(int id);
    }
}