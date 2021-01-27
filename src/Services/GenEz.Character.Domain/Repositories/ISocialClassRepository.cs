using Distrib.Core.Domain.Repositories;
using GenEz.Character.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenEz.Character.Domain.Repositories
{
    public interface ISocialClassRepository : IRepository
    {
        public Task<List<SocialClass>> GetAllAsync();
    }
}
