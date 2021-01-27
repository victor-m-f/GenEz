using Distrib.Core.Data.Repositories;
using GenEz.Character.Domain.Entities;
using GenEz.Character.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenEz.Character.Data.Repositories
{
    public class SocialClassRepository : RepositoryBase<CharacterDbContext>, ISocialClassRepository
    {
        #region Constructors

        public SocialClassRepository(CharacterDbContext context)
            : base(context)
        {
        }

        #endregion

        public Task<List<SocialClass>> GetAllAsync()
        {
            return Context.SocialClasses.ToListAsync();
        }
    }
}
