using System.Reflection;
using HealthCareManagement.Models.Constants;

namespace HealthCareManagement.BusinessLogic
{
    public class QueryBuilder
    {
        private ILogger _logger;
        private IConfiguration _configuration;
        public QueryBuilder(ILogger<QueryBuilder> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public string GetQueryFromResouce(string sourceName)
        {
            var queryString = string.Empty;
            var assembly = Assembly.GetExecutingAssembly();

            var sourceItem = assembly.GetManifestResourceNames().First(s => s.EndsWith(sourceName));
            using (var stream = new StreamReader(assembly.GetManifestResourceStream(sourceItem)))
            {
                queryString = stream?.ReadToEnd();
            }

            return queryString;
        }

        public string GetQueryFromQueryDictionary(string keyName)
        {
            var strQuery = string.Empty;
            return QueryDictionary.QueryLookUp.TryGetValue(keyName, out strQuery)
                ? strQuery
                : throw new Exception("Query not found");
        }

    }
}
