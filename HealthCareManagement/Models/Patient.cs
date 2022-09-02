using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Text.Json.Serialization;

namespace HealthCareManagement.Models
{
    public class Patient : HealthManagamentObjects
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "PatientId")]
        [ModelViewColumn(DiplayName = "PatientId", ToDisplay = true)]
        public int PatientId { get; set; }

        [ModelViewColumn(DiplayName = "PatientName", ToDisplay = true)]
        public string PatientName { get => $"{FirstName} {LastName}"; }

        public string FirstName { get; set; }
        public string LastName { get; set; }


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

        public Patient(int patientId, string firstName, string lastName, DateTime dateOfBirth, string gender, string primaryContact, string secondaryContact)
        {
            PatientId = patientId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PrimaryContact = primaryContact;
            SecondaryContact = secondaryContact;
        }

        public static Patient Map(SqlDataReader reader) => new Patient
        {
            PatientId = reader.GetFieldValue<int>(reader.GetOrdinal("patient_id")),
            FirstName = reader.GetFieldValue<string>(reader.GetOrdinal("first_name")),
            LastName = reader.GetFieldValue<string>(reader.GetOrdinal("last_name")),
            DateOfBirth = reader.GetFieldValue<DateTime>(reader.GetOrdinal("date_of_birth")),
            Gender = reader.GetFieldValue<int>(reader.GetOrdinal("gender")).ToString(),
            PrimaryContact = reader.GetFieldValue<string>(reader.GetOrdinal("primary_contact")),
            SecondaryContact = reader.GetFieldValue<string>(reader.GetOrdinal("secondary_contact")),
        };
    }
}