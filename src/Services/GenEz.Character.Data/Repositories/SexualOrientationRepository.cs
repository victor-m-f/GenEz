using Distrib.Core.Data.Repositories;
using GenEz.Character.Domain.Entities;
using GenEz.Character.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenEz.Character.Data.Repositories
{
    public class SexualOrientationRepository : RepositoryBase<CharacterDbContext>, ISexualOrientationRepository
    {
        #region Constructors

        public SexualOrientationRepository(CharacterDbContext context)
            : base(context)
        {
        }

        #endregion

        public Task<List<SexualOrientation>> GetAllAsync()
        {
            return Context.SexualOrientations.ToListAsync();
        }
    }
}
