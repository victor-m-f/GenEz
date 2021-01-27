using Distrib.Core.Application.Communication.Errors;
using Distrib.Core.Domain.Filters;
using System;
using System.Collections.Generic;

namespace Distrib.Core.Api.Controllers.Responses
{
    public class PaginatedApiResponse<T> : ApiResponseWithResult<PaginatedListBase<T>>
    {
        #region Properties

        public int PageNumber { get; set; }
        public int PageQty { get; set; }
        public int PageSize { get; set; }
        public int TotalQty { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }

        #endregion

        public PaginatedApiResponse(PaginatedListBase<T> result, IEnumerable<ErrorNotification> errors)
            : base(result, errors)
        {
            if (result == null)
            {
                throw new ArgumentNullException();
            }

            PageNumber = result.PageNumber;
            PageQty = result.PageQty;
            PageSize = result.PageSize;
            TotalQty = result.TotalQty;
            HasPreviousPage = result.HasPreviousPage;
            HasNextPage = result.HasNextPage;
        }
    }
}
