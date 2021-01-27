using Distrib.Core.Data.Mappings;
using GenEz.Character.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenEz.Character.Data.Mappings
{
    internal partial class SpellingRelationalMapping : IEntityTypeConfiguration<Spelling>
    {
        private const string Table = "tb_spelling";

        public void Configure(EntityTypeBuilder<Spelling> b)
        {
            b.ToTable(Table);
            b.HasGuidPk(x => x.Id);

            b.Property(x => x.Text).IsVarChar(Spelling.TextMaxSize, true);
            b.HasIndex(x => x.Text).IsUnique();

            b.Property(x => x.NeutralText).IsVarChar(Spelling.TextMaxSize, true);
        }
    }
}
