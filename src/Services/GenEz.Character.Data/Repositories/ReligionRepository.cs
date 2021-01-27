using Distrib.Core.Data.Repositories;
using GenEz.Character.Domain.Entities;
using GenEz.Character.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenEz.Character.Data.Repositories
{
    public class ReligionRepository : RepositoryBase<CharacterDbContext>, IReligionRepository
    {
        #region Constructors

        public ReligionRepository(CharacterDbContext context)
            : base(context)
        {
        }

        #endregion

        public Task<List<Religion>> GetAllAsync()
        {
            return Context.Religions.ToListAsync();
        }
    }
}
