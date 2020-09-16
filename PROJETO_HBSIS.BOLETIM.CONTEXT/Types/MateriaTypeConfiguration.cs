using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO_HBSIS.BOLETIM.MODELS;

namespace PROJETO_HBSIS.BOLETIM.CONTEXT.Types
{
    public class MateriaTypeConfiguration : IEntityTypeConfiguration<Materia>
    {
        public void Configure(EntityTypeBuilder<Materia> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(80);
        }
    }
}
