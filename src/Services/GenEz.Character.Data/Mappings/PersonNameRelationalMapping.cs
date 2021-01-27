using Distrib.Core.Data.Mappings;
using GenEz.Character.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenEz.Character.Data.Mappings
{
    internal partial class PersonNameRelationalMapping : IEntityTypeConfiguration<PersonName>
    {
        private const string Table = "tb_person_name";

        public void Configure(EntityTypeBuilder<PersonName> b)
        {
            b.ToTable(Table);
            b.HasGuidPk(x => x.Id);

            b.HasMany(x => x.RelatedPersonNamesTo)
                .WithMany(y => y.RelatedPersonNamesFrom)
                .UsingEntity(join => join.ToTable("tb_related_person_name"));

            b.HasMany(x => x.NameOrigins)
                .WithMany(y => y.PersonNames)
                .UsingEntity(join => join.ToTable("tb_person_name_origin"));

            b.HasMany(x => x.Nicknames)
                .WithMany(y => y.PersonNames)
                .UsingEntity(join => join.ToTable("tb_person_name_nickname"));
        }
    }
}
