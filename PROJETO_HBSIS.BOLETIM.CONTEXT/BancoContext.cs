using Microsoft.EntityFrameworkCore;
using PROJETO_HBSIS.BOLETIM.MODELS;
using PROJETO_HBSIS.BOLETIM.MODELS.ClassesAssociativas;

namespace PROJETO_HBSIS.BOLETIM.CONTEXT
{
    public class BancoContext : DbContext
    {
        public BancoContext()
        {

        }
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=NT-04777\\SQLEXPRESS;Initial Catalog=BancoBoletim;Integrated Security=True;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(BancoContext).Assembly);

            //Definindo foreginKey muitos pra muitos
            modelBuilder.Entity<MateriaCurso>().HasKey(sc => new { sc.CursoId, sc.MateriaId });
            modelBuilder.Entity<ProfessorMateria>().HasKey(sc => new { sc.ProfessorId, sc.MateriaId });

        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Administrador> Administradors{ get; set; }
    }
}
