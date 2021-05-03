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
        private readonly SortingAndPagingOption _sortingAndPagingOption;

        public DataCollection(IReadOnlyList<TData>   collection,
                                      int                    totalCount,
                                      string                 baseUrl,
                                      SortingAndPagingOption sortingAndPagingOption)
        {
            Collection              = collection;
            TotalCount              = totalCount;
            _baseUrl                = baseUrl;
            _sortingAndPagingOption = sortingAndPagingOption;

            var hasNext = _sortingAndPagingOption.Offset + _sortingAndPagingOption.PageSize < totalCount;
            Next = hasNext ? CreateNavigationLink(1) : null;

            var hasPrevious = _sortingAndPagingOption.Offset > 0;
            Previous = hasPrevious ? CreateNavigationLink(-1) : null;
        }

        private string CreateNavigationLink(sbyte amount)
        {
            var (sortColumn, sortDirection, pageSize, pageNumber) = _sortingAndPagingOption;
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