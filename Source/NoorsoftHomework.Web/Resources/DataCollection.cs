using System.Collections.Generic;
using NoorsoftHomework.Web.Handlers.Employee.Queries;

namespace NoorsoftHomework.Web.Resources
{
    public class DataCollection<TData>
    {
        public           IEnumerable<TData>     Collection { get; }
        public           int                    TotalCount { get; }
        public           string?                Next       { get; }
        public           string?                Previous   { get; }
        private readonly string                 _baseUrl;
        private readonly SortingAndPagingResource _sortingAndPagingResource;

        public DataCollection(IReadOnlyList<TData>   collection,
                                      int                    totalCount,
                                      string                 baseUrl,
                                      SortingAndPagingResource sortingAndPagingResource)
        {
            Collection              = collection;
            TotalCount              = totalCount;
            _baseUrl                = baseUrl;
            _sortingAndPagingResource = sortingAndPagingResource;

            var hasNext = _sortingAndPagingResource.Offset + _sortingAndPagingResource.PageSize < totalCount;
            Next = hasNext ? CreateNavigationLink(1) : null;

            var hasPrevious = _sortingAndPagingResource.Offset > 0;
            Previous = hasPrevious ? CreateNavigationLink(-1) : null;
        }

        private string CreateNavigationLink(sbyte amount)
        {
            var (sortColumn, sortDirection, pageSize, pageNumber) = _sortingAndPagingResource;
            var sortColumnParameter    = CreateQueryParameterPair(nameof(sortColumn),    sortColumn);
            var sortDirectionParameter = CreateQueryParameterPair(nameof(sortDirection), sortDirection);
            var pageSizeParameter      = CreateQueryParameterPair(nameof(pageSize),      pageSize);
            var pageNumberParameter    = CreateQueryParameterPair(nameof(pageNumber),    pageNumber + amount);
            var parameters = CreateQueryParameters(sortColumnParameter,
                                                   sortDirectionParameter,
                                                   pageSizeParameter,
                                                   pageNumberParameter);
            var link = $"{_baseUrl}?{parameters}";
            return link;
        }

        private string CreateQueryParameterPair(string name, object value) => $"{name}={value}";

        private string CreateQueryParameters(params string[] parameters)
        {
            var joinedParameters = string.Join('&', parameters);
            return joinedParameters;
        }
    }
}