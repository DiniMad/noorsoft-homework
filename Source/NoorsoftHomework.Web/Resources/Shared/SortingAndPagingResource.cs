using NoorsoftHomework.DataAccess.Models;

namespace NoorsoftHomework.Web.Resources.Shared
{
    public record SortingAndPagingResource(SortColumn    SortColumn,
                                           SortDirection SortDirection,
                                           int           PageSize   = 10,
                                           int           PageNumber = 1)
    {
        public int Offset => (PageNumber - 1) * PageSize;
    }
}