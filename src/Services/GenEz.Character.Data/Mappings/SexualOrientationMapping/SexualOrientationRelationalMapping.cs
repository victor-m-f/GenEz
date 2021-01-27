using Distrib.Core.Data.Mappings;
using GenEz.Character.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenEz.Character.Data.Mappings.SexualOrientationMapping
{
    internal partial class SexualOrientationRelationalMapping : IEntityTypeConfiguration<SexualOrientation>
    {
        private const string Table = "tb_sexual_orientation";

        public void Configure(EntityTypeBuilder<SexualOrientation> b)
        {
            b.ToTable(Table);
            b.HasGuidPk(x => x.Id);

            b.Property(x => x.Name).IsVarChar(SexualOrientation.NameMaxSize, true);
            b.HasIndex(x => x.Name).IsUnique();

            Seed(b);
        }
    }
}
