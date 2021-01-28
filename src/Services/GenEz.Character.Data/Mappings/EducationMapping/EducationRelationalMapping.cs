using Distrib.Core.Data.Mappings;
using GenEz.Character.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenEz.Character.Data.Mappings.EthnicityMapping
{
    internal partial class EducationRelationalMapping : IEntityTypeConfiguration<Education>
    {
        private const string Table = "tb_education";

        public void Configure(EntityTypeBuilder<Education> b)
        {
            b.ToTable(Table);
            b.HasGuidPk(x => x.Id);

            b.Property(x => x.Name).IsVarChar(Education.NameMaxSize, true);
            b.HasIndex(x => x.Name).IsUnique();

            Seed(b);
        }
    }
}
