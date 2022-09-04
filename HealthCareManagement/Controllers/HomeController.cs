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

            var dict = paths.Select((value, index) => new { index, value }).ToDictionary(i => $"Query {i.index}", i => i.value);
            return View(dict);
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
            ViewData["Title"] = "Patient";
            return View("ViewP", returnObj);
        }

        public IActionResult GetDosages()
        {

            var returnObj = new List<DosagePeriods>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync($"{_baseUrl}/api/Medicine/GetDosage").Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    returnObj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DosagePeriods>>(data);
                }
            }
            ViewData["Title"] = "Dosages";
            return View("ViewP", returnObj);
        }

        public IActionResult GetDosageAndInsurance()
        {

            var returnObj = new List<MedInsurance>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync($"{_baseUrl}/api/Medicine/GetDosageAndInsurance?medicineReference=_").Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    returnObj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MedInsurance>>(data);
                }
            }
            ViewData["Title"] = "Dosage and Insurance";
            return View("ViewP", returnObj);
        }

        public IActionResult GetPatientMedUsage()
        {

            var returnObj = new List<PatientMedUsage>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync($"{_baseUrl}/api/Medicine/GetPatientMedUsage").Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    returnObj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PatientMedUsage>>(data);
                }
            }
            ViewData["Title"] = "Patient Med Dosage ";
            return View("ViewP", returnObj);
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

            var a = _databaseProvider.ExecuteQuery(sql, Patient.Map).ToList();

            ViewData["Title"] = "Patient2";

            return View("ViewP", a);
        }

    }
}
