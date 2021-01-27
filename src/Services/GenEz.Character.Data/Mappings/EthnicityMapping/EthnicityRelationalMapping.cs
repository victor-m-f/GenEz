using Distrib.Core.Data.Mappings;
using GenEz.Character.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenEz.Character.Data.Mappings.EthnicityMapping
{
    internal partial class EthnicityRelationalMapping : IEntityTypeConfiguration<Ethnicity>
    {
        private const string Table = "tb_ethnicity";

        public void Configure(EntityTypeBuilder<Ethnicity> b)
        {
            b.ToTable(Table);
            b.HasGuidPk(x => x.Id);

            b.Property(x => x.Name).IsVarChar(Ethnicity.NameMaxSize, true);
            b.HasIndex(x => x.Name).IsUnique();

            Seed(b);
        }
    }
}
