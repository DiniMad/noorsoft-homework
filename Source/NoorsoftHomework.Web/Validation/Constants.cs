namespace NoorsoftHomework.Web.Validation
{
    public static class Constants
    {
        public const string DateFormatRegex = @"^(13|14)\d\d/(0{0,1}[1-9]|1[012])/(0{0,1}[1-9]|[12][0-9]|3[01])$";
        public const string DateFormatErrorMessage = "Valid format for date is 'yyyy/MM/dd' such as '1400/0/0'.";
    }
}