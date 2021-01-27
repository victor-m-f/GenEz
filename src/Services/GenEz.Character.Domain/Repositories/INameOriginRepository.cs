using Distrib.Core.Domain.Repositories;
using GenEz.Character.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenEz.Character.Domain.Repositories
{
    public interface INameOriginRepository : IRepository
    {
        public Task<List<NameOrigin>> GetAllAsync();
        public Task<List<NameOrigin>> GetNameOriginsByIdsAsync(List<Guid> nameOriginsIds);
        public Task<bool> NameOriginsExists(string nameOriginName);
    }
}
