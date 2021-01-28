using Distrib.Core.Data.Repositories;
using GenEz.Character.Domain.Entities;
using GenEz.Character.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenEz.Character.Data.Repositories
{
    public class EducationRepository : RepositoryBase<CharacterDbContext>, IEducationRepository
    {
        #region Constructors

        public EducationRepository(CharacterDbContext context)
            : base(context)
        {
        }

        #endregion

        public Task<List<Education>> GetAllAsync()
        {
            return Context.Educations.ToListAsync();
        }
    }
}
