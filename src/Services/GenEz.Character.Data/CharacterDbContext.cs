using Distrib.Core.Data;
using GenEz.Character.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenEz.Character.Data
{
    public class CharacterDbContext : DbContextBase<CharacterDbContext>
    {
        #region Properties

        public DbSet<PersonName> PersonNames { get; set; }
        public DbSet<NameOrigin> NameOrigins { get; set; }
        public DbSet<Nickname> Nicknames { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<SocialClass> SocialClasses { get; set; }
        public DbSet<Ethnicity> Ethnicities { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<SexualOrientation> SexualOrientations { get; set; }
        public DbSet<Education> Educations { get; set; }

        #endregion

        #region Constructors

        public CharacterDbContext(DbContextOptions<CharacterDbContext> options)
            : base(options)
        {
        }

        #endregion
    }
}
