using Distrib.Core.Domain.Filters;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distrib.Core.Data.Filters
{
    public class PaginatedList<T> : PaginatedListBase<T>
    {
        #region Constructors

        public PaginatedList()
        {
        }

        private PaginatedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
            : base(items, count, pageNumber, pageSize)
        {
        }

        #endregion

        public static async Task<PaginatedListBase<T>> CreateAsync(
            IQueryable<T> source,
            int pageNumber,
            int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }

        public static PaginatedListBase<T> Create(
            IEnumerable<T> source,
            int pageNumber,
            int pageSize)
        {
            var sourceEnumerated = source.ToList();
            var count = sourceEnumerated.Count();
            var items = sourceEnumerated.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
