using Distrib.Core.Data.Mappings;
using GenEz.Character.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenEz.Character.Data.Mappings.SocialClassMapping
{
    internal partial class SocialClassRelationalMapping : IEntityTypeConfiguration<SocialClass>
    {
        private const string Table = "tb_social_class";

        public void Configure(EntityTypeBuilder<SocialClass> b)
        {
            b.ToTable(Table);
            b.HasGuidPk(x => x.Id);

            b.Property(x => x.Name).IsVarChar(SocialClass.NameMaxSize, true);
            b.HasIndex(x => x.Name).IsUnique();

            Seed(b);
        }
    }
}
