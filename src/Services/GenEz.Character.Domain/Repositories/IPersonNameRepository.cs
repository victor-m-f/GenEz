using Distrib.Core.Domain.Repositories;
using GenEz.Character.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenEz.Character.Domain.Repositories
{
    public interface IPersonNameRepository : IRepository
    {
        public Task<List<PersonName>> GetAllAsync();
        public Task<List<PersonName>> GetPersonNamesByIdsAsync(List<Guid> personNamesIds);
        public Task<List<Nickname>> GetNicknamesByNameAsync(List<string> nicknames);
    }
}
