using Distrib.Core.Data.Mappings;
using Distrib.Core.Domain.Configurations;
using GenEz.Character.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenEz.Character.Data.Mappings.NameOriginMapping
{
    internal partial class NameOriginRelationalMapping : IEntityTypeConfiguration<NameOrigin>
    {
        private const string Table = "tb_name_origin";

        public void Configure(EntityTypeBuilder<NameOrigin> b)
        {
            b.ToTable(Table);
            b.HasGuidPk(x => x.Id);

            b.Property(x => x.Name).IsVarChar(CoreConstSizes.PersonNameMax, true);
            b.HasIndex(x => x.Name).IsUnique();

            b.Property(x => x.NeutralName).IsVarChar(CoreConstSizes.PersonNameMax, true);

            Seed(b);
        }
    }
}
