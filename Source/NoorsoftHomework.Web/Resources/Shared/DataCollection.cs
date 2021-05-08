using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NoorsoftHomework.Web.Controllers;

namespace NoorsoftHomework.Web.Resources.Shared
{
    public record DataCollection<TData>
    {
        public           IEnumerable<TData>       Collection { get; }
        public           int                      TotalCount { get; }
        public           string?                  Next       { get; }
        public           string?                  Previous   { get; }
        private readonly SortingAndPagingResource _sortingAndPagingResource;
        private readonly IUrlHelper               _urlHelper;

        public DataCollection(IReadOnlyList<TData>     collection,
                              int                      totalCount,
                              SortingAndPagingResource sortingAndPagingResource,
                              IUrlHelper               urlHelper)
        {
            Collection                = collection;
            TotalCount                = totalCount;
            _sortingAndPagingResource = sortingAndPagingResource;
            _urlHelper                = urlHelper;

            var hasNext = _sortingAndPagingResource.Offset + _sortingAndPagingResource.PageSize < totalCount;
            Next = hasNext ? CreateNavigationLink(1) : null;

            var hasPrevious = _sortingAndPagingResource.Offset > 0;
            Previous = hasPrevious ? CreateNavigationLink(-1) : null;
        }

        private string CreateNavigationLink(sbyte amount)
        {
            var (column, direction, pageSize, pageNumber) = _sortingAndPagingResource;
            var option = new SortingAndPagingResource(column, direction, pageSize, pageNumber + amount);
            var link   = _urlHelper.ActionLink(nameof(EmployeeController.Get), "Employee", option);
            return link;
        }
    }
}