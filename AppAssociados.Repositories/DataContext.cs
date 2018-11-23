using AppAssociados.Domain;
using Microsoft.EntityFrameworkCore;

namespace AppAssociados.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {}

        public DbSet<Associado> Associado { get; set; }
        public DbSet<EstadoCivil> EstadoCivil { get; set; }
        public DbSet<Parentesco> Parentesco { get; set; }
        public DbSet<Dependente> Dependente { get; set; }
    }
}