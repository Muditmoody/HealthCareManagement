using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Text.Json.Serialization;

namespace HealthCareManagement.Models
{
    public class Patient
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "PatientId")]
        [ModelViewColumn(DiplayName = "PatientId", ToDisplay = true)]
        public int PatientId { get; set; }

        [ModelViewColumn(DiplayName = "PatientName", ToDisplay = true)]
        public string PatientName { get; set; } = string.Empty;

        [ModelViewColumn(DiplayName = "DateOfBirth", ToDisplay = true)]
        public DateTime DateOfBirth { get; set; }

        [ModelViewColumn(DiplayName = nameof(Gender), ToDisplay = true)]
        public string Gender { get; set; } = string.Empty;

        [ModelViewColumn(DiplayName = nameof(PrimaryContact), ToDisplay = true)]
        public string PrimaryContact { get; set; } = string.Empty;

        [ModelViewColumn(DiplayName = nameof(SecondaryContact), ToDisplay = true)]
        public string SecondaryContact { get; set; } = string.Empty;

        public Patient()
        {
        }

        public Patient(int patientId, string patientName, DateTime dateOfBirth, string gender, string primaryContact, string secondaryContact)
        {
            PatientId = patientId;
            PatientName = patientName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PrimaryContact = primaryContact;
            SecondaryContact = secondaryContact;
        }

        public static Patient Map(SqlDataReader reader) => new Patient
        {
            PatientId = reader.GetFieldValue<int>(reader.GetOrdinal("patient_id")),
            PatientName = reader.GetFieldValue<string>(reader.GetOrdinal("patient_name")),
            DateOfBirth = reader.GetFieldValue<DateTime>(reader.GetOrdinal("date_of_birth")),
            Gender = reader.GetFieldValue<string>(reader.GetOrdinal("gender"))
        };
    }
}