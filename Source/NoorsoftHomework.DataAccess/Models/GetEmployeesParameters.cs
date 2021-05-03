namespace NoorsoftHomework.DataAccess.Models
{
    public record GetEmployeesParameters
    {
        public string ColumnNameToOrderBy { get; }
        public string DirectionToOrderBy  { get; }
        public int    Offset              { get; }
        public int    Count               { get; }

        public GetEmployeesParameters(SortColumn    columnNameToOrderBy,
                                      SortDirection directionToOrderBy,
                                      int           offset,
                                      int           count)
        {
            DirectionToOrderBy  = directionToOrderBy.ToString();
            ColumnNameToOrderBy = columnNameToOrderBy.ToString();
            Offset              = offset;
            Count               = count;
        }
    }

    public enum SortColumn
    {
        Id,
        FirstName,
        LastName,
        BirthDate,
        RecruitmentDate,
        SupervisorId,
    }

    public enum SortDirection
    {
        ASC,
        DESC
    }
}