using Distrib.Core.Data.Mappings;
using GenEz.Character.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenEz.Character.Data.Mappings.ReligionMapping
{
    internal partial class ReligionRelationalMapping : IEntityTypeConfiguration<Religion>
    {
        private const string Table = "tb_religion";

        public void Configure(EntityTypeBuilder<Religion> b)
        {
            b.ToTable(Table);
            b.HasGuidPk(x => x.Id);

            b.Property(x => x.Name).IsVarChar(Religion.NameMaxSize, true);
            b.HasIndex(x => x.Name).IsUnique();

            b.Property(x => x.NeutralText).IsVarChar(Religion.NameMaxSize, true);

            b.Property(x => x.Adjective).IsVarChar(Religion.AdjectiveMaxSize, true);

            Seed(b);
        }
    }
}
