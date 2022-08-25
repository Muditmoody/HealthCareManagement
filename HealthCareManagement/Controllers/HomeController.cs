using Microsoft.AspNetCore.Mvc;
using HealthCareManagement.Models;
using Microsoft.AspNetCore.Components;
using HealthCareManagement.BusinessLogic;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace HealthCareManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        private readonly IActionDescriptorCollectionProvider _actionProvider;
        private readonly string _baseUrl;

        public HomeController(IActionDescriptorCollectionProvider actionProvider, ILogger<HomeController> logger, IConfiguration configuration, DatabaseProvider databaseProvider, QueryBuilder queryBuilder)
        {
            _logger = logger;
            _configuration = configuration;
            _databaseProvider = databaseProvider;
            _queryBuilder = queryBuilder;
            _actionProvider = actionProvider;
            _baseUrl = _configuration.GetConnectionString("BaseUrl");
        }

        public IActionResult Index()
        {
            var routes = _actionProvider.ActionDescriptors.Items.Where(x => x.AttributeRouteInfo == null);
            var paths = routes.Select(r =>
            {
                var a = r as Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor;
                return $"{_baseUrl}/{a.ControllerName}/{a.ActionName}/";
            }
            );
            return View(paths);
        }

        public IActionResult ViewP()
        {

            var returnObj = new List<Patient>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync($"{_baseUrl}/api/Patient/GetPatients").Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    returnObj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Patient>>(data);
                }
            }
            return View(returnObj);
        }

        public IActionResult View2()
        {
            //_logger.LogDebug("Get patient info");
            //var a = Enumerable.Range(1, 5).Select(index => new Patient
            //{
            //    PatientId = Random.Shared.Next(),
            //    PatientName = "abcd",
            //    //Age = new Random().Next(10, 50)

            //    //Date = DateTime.Now.AddDays(index),
            //    //TemperatureC = Random.Shared.Next(-20, 55),
            //    //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();

            var sql = _queryBuilder.GetQueryFromResouce("Patient.sql");

            var a = _databaseProvider.ExecuteQuery(sql, Patient.Map).ToArray();

            return View(a);
        }

    }
}
