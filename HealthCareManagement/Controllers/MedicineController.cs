using System.Data;
using Microsoft.AspNetCore.Mvc;
using HealthCareManagement.Models;
using HealthCareManagement.BusinessLogic;

namespace HealthCareManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicineController : ControllerBase
    {
        private readonly ILogger<MedicineController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        public MedicineController(ILogger<MedicineController> logger, IConfiguration configuration, DatabaseProvider databaseProvider, QueryBuilder queryBuilder)
        {
            _logger = logger;
            _configuration = configuration;
            _databaseProvider = databaseProvider;
            _queryBuilder = queryBuilder;
        }

        [HttpGet("GetDosage")]
        public IEnumerable<DosagePeriods> GetDosage([FromQuery] DateTime startDate = default, [FromQuery] DateTime endDate = default)
        {

            _logger.LogDebug("Get Doage period`");
            var sql = _queryBuilder.GetQueryFromResouce("DosageOfMeds.sql");

            startDate = startDate == default ? DateTime.Today.AddYears(-10) : startDate;
            endDate = endDate == default ? DateTime.Today.AddYears(10) : endDate;

            sql = string.Format(sql, startDate.ToString("dd-MMM-yyyy"), endDate.ToString("dd-MMM-yyyy"));
            return _databaseProvider.ExecuteQuery(sql, DosagePeriods.Map);
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