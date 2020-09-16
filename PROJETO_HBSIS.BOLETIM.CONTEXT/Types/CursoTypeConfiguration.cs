using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_HBSIS.BOLETIM.MODELS;

namespace PROJETO_HBSIS.BOLETIM.CONTEXT.Types
{
    public class CursoTypeConfiguration : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(30);
            builder.HasMany(q => q.Alunos).WithOne().HasForeignKey(q => q.IdCurso);

        }
    }
}
