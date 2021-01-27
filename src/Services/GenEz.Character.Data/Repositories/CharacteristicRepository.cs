using Distrib.Core.Data.Repositories;
using GenEz.Character.Domain.Entities;
using GenEz.Character.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenEz.Character.Data.Repositories
{
    public class CharacteristicRepository : RepositoryBase<CharacterDbContext>, ICharacteristicRepository
    {
        #region Constructors

        public CharacteristicRepository(CharacterDbContext context)
            : base(context)
        {
        }

        #endregion

        Task<List<Characteristic>> ICharacteristicRepository.GetAllAsync()
        {
            return Context.Characteristics
                .Include(x => x.CharacteristicsOpposedTo)
                .Include(x => x.CharacteristicsOpposedFrom)
                .AsSingleQuery()
                .ToListAsync();
        }

        public Task<List<Characteristic>> GetCharacteristicsByNameAsync(List<string> characteristics)
        {
            return Context.Characteristics
                .Include(x => x.CharacteristicsOpposedTo)
                .Where(x => characteristics.Contains(x.Name)).ToListAsync();
        }
    }
}
