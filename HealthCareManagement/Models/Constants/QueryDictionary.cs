namespace HealthCareManagement.Models.Constants
{
    public static class QueryDictionary
    {
        private static readonly string TEST_QUERY = @" SELECT * FROM Patient";

        public static readonly IDictionary<string, string> QueryLookUp = new Dictionary<string, string>
        {
            {
                nameof(TEST_QUERY), TEST_QUERY
            }
        };
    }
}
