using System;
using System.Collections.Generic;

namespace Distrib.Core.Domain.Filters
{
    public class PaginatedListBase<T> : List<T>
    {
        #region Properties

        public int PageNumber { get; set; }
        public int PageQty { get; set; }
        public int PageSize { get; set; }
        public int TotalQty { get; set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < PageQty;

        #endregion

        #region Constructors

        // Required for newtonsoft
        public PaginatedListBase()
        {
        }

        protected PaginatedListBase(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            TotalQty = count;
            PageSize = pageSize;
            PageNumber = pageNumber;
            PageQty = (int)Math.Ceiling(count / (double)PageSize);
            AddRange(items);
        }

        #endregion
    }
}
