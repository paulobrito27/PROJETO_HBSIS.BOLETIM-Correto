


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_HBSIS.BOLETIM.MODELS;

namespace PROJETO_HBSIS.BOLETIM.CONTEXT.Types
{
    public class AlunoTypeConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Sobrenome).IsRequired().HasMaxLength(80);
            builder.Property(x => x.Cpf).IsRequired().HasMaxLength(16);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(12);
            builder.Property(x => x.Login).IsRequired().HasMaxLength(20);
            builder.HasOne(x => x.Curso).WithMany().HasForeignKey(x => x.IdCurso);
        }

    }
}
