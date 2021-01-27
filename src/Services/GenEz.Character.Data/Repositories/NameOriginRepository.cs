using Distrib.Core.Data.Repositories;
using Distrib.Helper.Extensions;
using GenEz.Character.Domain.Entities;
using GenEz.Character.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenEz.Character.Data.Repositories
{
    public class NameOriginRepository : RepositoryBase<CharacterDbContext>, INameOriginRepository
    {
        #region Constructors

        public NameOriginRepository(CharacterDbContext context)
            : base(context)
        {
        }

        public Task<List<NameOrigin>> GetAllAsync()
        {
            return Context.NameOrigins.ToListAsync();
        }

        #endregion

        public Task<List<NameOrigin>> GetNameOriginsByIdsAsync(List<Guid> nameOriginsIds)
        {
            return Context.NameOrigins.Where(x => nameOriginsIds.Contains(x.Id)).ToListAsync();
        }

        public Task<bool> NameOriginsExists(string nameOriginName)
        {
            return Context.NameOrigins.AnyAsync(x => x.NeutralName == nameOriginName.ToNeutral());
        }
    }
}
