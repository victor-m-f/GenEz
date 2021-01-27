using Distrib.Core.Domain.Repositories;
using GenEz.Character.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenEz.Character.Domain.Repositories
{
    public interface IReligionRepository : IRepository
    {
        public Task<List<Religion>> GetAllAsync();
    }
}
