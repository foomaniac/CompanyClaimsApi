namespace CompanyClaimsApi.Shared
{
    public static class DaysBetweenDates
    {
        public static int Get(DateTime startDate, DateTime endDate)
        {
            TimeSpan spanBetweenDates = endDate - startDate;
            return spanBetweenDates.Days;
        }
    }
}