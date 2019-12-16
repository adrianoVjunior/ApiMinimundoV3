using Microsoft.EntityFrameworkCore;
using uniaraxaMinimundo.Dominio.Entidades;
using uniaraxaMinimundo.Infra.Data.EntityFramework.Configuration;

namespace uniaraxaMinimundo.Infra.Data.EntityFramework.Context
{
    public class myContext : DbContext
    {

        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Empresa> empresa { get; set; }
        public DbSet<Funcionario> funcionario { get; set; }
        public DbSet<Avaliador> avaliador { get; set; }
        public DbSet<Campanha> campanha { get; set; }
        public DbSet<AvaliacaoSugestao> avaliacaoSugestao { get; set; }
        public DbSet<Sugestao> sugestao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=sql4.porta80.com.br;Initial Catalog=lojasparati;user id=lojasparati;password=5117556");
            optionsBuilder.EnableSensitiveDataLogging(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>(new UsuarioConfiguration().Configure);
            modelBuilder.Entity<Empresa>(new EmpresaConfiguration().Configure);
            modelBuilder.Entity<Funcionario>(new FuncionarioConfiguration().Configure);
            modelBuilder.Entity<Avaliador>(new AvaliadorConfiguration().Configure);
            modelBuilder.Entity<Campanha>(new CampanhaConfiguration().Configure);
            modelBuilder.Entity<AvaliacaoSugestao>(new AvaliacaoSugestaoConfiguration().Configure);
            modelBuilder.Entity<Sugestao>(new SugestaoConfiguration().Configure);
        }
    }
}
