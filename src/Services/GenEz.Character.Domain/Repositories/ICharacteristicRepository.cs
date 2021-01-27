using Distrib.Core.Domain.Repositories;
using GenEz.Character.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenEz.Character.Domain.Repositories
{
    public interface ICharacteristicRepository : IRepository
    {
        public Task<List<Characteristic>> GetAllAsync();
        public Task<List<Characteristic>> GetCharacteristicsByNameAsync(List<string> characteristics);
    }
}
