using Distrib.Core.Data.Repositories;
using GenEz.Character.Domain.Entities;
using GenEz.Character.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenEz.Character.Data.Repositories
{
    public class PersonNameRepository : RepositoryBase<CharacterDbContext>, IPersonNameRepository
    {
        #region Constructors

        public PersonNameRepository(CharacterDbContext context) : base(context)
        {
        }

        #endregion

        public Task<List<PersonName>> GetAllAsync()
        {
            return Context.PersonNames
                .Include(x => x.Spellings)
                .Include(x => x.NameOrigins)
                .Include(x => x.RelatedPersonNamesTo)
                .Include(x => x.RelatedPersonNamesFrom)
                .Include(x => x.Nicknames)
                .AsSingleQuery()
                .ToListAsync();
        }

        public Task<List<PersonName>> GetPersonNamesByIdsAsync(List<Guid> personNamesIds)
        {
            return Context.PersonNames.Where(x => personNamesIds.Contains(x.Id)).ToListAsync();
        }

        public Task<List<Nickname>> GetNicknamesByNameAsync(List<string> nicknames)
        {
            return Context.Nicknames.Where(x => nicknames.Contains(x.Name)).ToListAsync();
        }
    }
}
