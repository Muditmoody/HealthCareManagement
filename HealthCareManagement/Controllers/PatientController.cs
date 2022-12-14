using System.Data;
using Microsoft.AspNetCore.Mvc;
using HealthCareManagement.Models;
using HealthCareManagement.BusinessLogic;

namespace HealthCareManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        public PatientController(ILogger<PatientController> logger, IConfiguration configuration, DatabaseProvider databaseProvider, QueryBuilder queryBuilder)
        {
            _logger = logger;
            _configuration = configuration;
            _databaseProvider = databaseProvider;
            _queryBuilder = queryBuilder;
        }

        [HttpGet("GetPatients")]
        public IEnumerable<Patient> GetP()
        {
            _logger.LogDebug("Get patient info");
            var sql = _queryBuilder.GetQueryFromResouce("Patient.sql");

            return _databaseProvider.ExecuteQuery(sql, Patient.Map);
        }

        [HttpGet("GetPatients2/{name}")]
        public IEnumerable<Patient> GetP2(string name)
        {
            _logger.LogDebug("Get patient info");
            return Enumerable.Range(1, 5).Select(index => new Patient
            {
                //PatientId = Random.Shared.Next(),
                //PatientName = Summaries[index],
                //Age = new Random().Next(10, 50)

                //Date = DateTime.Now.AddDays(index),
                //TemperatureC = Random.Shared.Next(-20, 55),
                //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).Where(p => p.PatientName.Contains(name))
            .ToArray();
        }
    }
}