using Distrib.Core.Data.Mappings;
using GenEz.Character.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenEz.Character.Data.Mappings
{
    internal partial class CharacteristicRelationalMapping : IEntityTypeConfiguration<Characteristic>
    {
        private const string Table = "tb_characteristic";

        public void Configure(EntityTypeBuilder<Characteristic> b)
        {
            b.ToTable(Table);
            b.HasGuidPk(x => x.Id);

            b.Property(x => x.Name).IsVarChar(Characteristic.NameMaxSize, true);

            b.Property(x => x.NeutralName).IsVarChar(Characteristic.NameMaxSize, true);
            b.HasIndex(x => x.NeutralName).IsUnique();

            b.HasMany(x => x.CharacteristicsOpposedTo)
                .WithMany(y => y.CharacteristicsOpposedFrom)
                .UsingEntity(join => join.ToTable("tb_opposed_characteristic"));
        }
    }
}
