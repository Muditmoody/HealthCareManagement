using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Text.Json.Serialization;

namespace HealthCareManagement.Models
{
    public class Patient
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "PatientId")]
        public int PatientId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "PatientName")]
        public string PatientName { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "Gender")]
        public string Gender { get; set; } = string.Empty;

        public string PrimaryContact { get; set; } = string.Empty;

        public string SecondaryContact { get; set; } = string.Empty;

        public Patient()
        {
        }

        public static Patient Map(SqlDataReader reader) => new Patient
        {
            PatientId = (int)reader.GetValue(reader.GetOrdinal("patient_id"))
        };
    }
}