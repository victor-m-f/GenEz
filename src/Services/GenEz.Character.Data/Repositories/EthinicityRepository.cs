using Distrib.Core.Data.Repositories;
using GenEz.Character.Domain.Entities;
using GenEz.Character.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenEz.Character.Data.Repositories
{
    public class EthinicityRepository : RepositoryBase<CharacterDbContext>, IEthinicityRepository
    {
        #region Constructors

        public EthinicityRepository(CharacterDbContext context)
            : base(context)
        {
        }

        #endregion

        public Task<List<Ethnicity>> GetAllAsync()
        {
            return Context.Ethnicities.ToListAsync();
        }
    }
}
