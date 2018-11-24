using AppAssociados.Domain;

namespace AppAssociados.Repositories.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
          Usuario AuthUser(Usuario user);
    }
}