using Distrib.Core.Data.Mappings;
using Distrib.Core.Domain.Configurations;
using GenEz.Character.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenEz.Character.Data.Mappings
{
    internal partial class NicknameRelationalMapping : IEntityTypeConfiguration<Nickname>
    {
        private const string Table = "tb_nickname";

        public void Configure(EntityTypeBuilder<Nickname> b)
        {
            b.ToTable(Table);
            b.HasGuidPk(x => x.Id);

            b.Property(x => x.Name).IsVarChar(CoreConstSizes.PersonNameMax, true);
            b.HasIndex(x => x.Name).IsUnique();
        }
    }
}
