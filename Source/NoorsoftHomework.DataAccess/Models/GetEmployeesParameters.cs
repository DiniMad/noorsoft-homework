namespace NoorsoftHomework.DataAccess.Models
{
    public enum SortDirection
    {
        ASC,
        DESC
    }

    public record GetEmployeesParameters(string        ColumnNameToOrderBy,
                                        SortDirection DirectionToOrderBy,
                                        int           Offset,
                                        int           Count);
}