using Microsoft.EntityFrameworkCore;
using uniaraxaMinimundo.Dominio.Entidades;
using uniaraxaMinimundo.Infra.Data.EntityFramework.Configuration;

namespace uniaraxaMinimundo.Infra.Data.EntityFramework.Context
{
    public class myContext : DbContext
    {

        public DbSet<userToken> userToken{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=sql4.porta80.com.br;Initial Catalog=lojasparati;user id=lojasparati;password=5117556");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<userToken>(new userTokenConfiguration().Configure);
        }
    }
}
