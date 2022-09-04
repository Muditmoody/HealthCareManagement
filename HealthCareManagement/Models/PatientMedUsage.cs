using System.Data.SqlClient;

namespace HealthCareManagement.Models
{
    public class PatientMedUsage : HealthManagamentObjects
    {
        [ModelViewColumn(DiplayName = "Patient Id", ToDisplay = true)]
        public int PatientId { get; set; }

        [ModelViewColumn(DiplayName = "Patient Name", ToDisplay = true)]
        public string PatientName { get; set; }

        [ModelViewColumn(DiplayName = "Patient Age", ToDisplay = true)]
        public string PatientAge { get; set; }

        [ModelViewColumn(DiplayName = "Medicine Name", ToDisplay = true)]
        public string MedicineName { get; set; }

        [ModelViewColumn(DiplayName = "Dosage", ToDisplay = true)]
        public double Dosage { get; set; }

        [ModelViewColumn(DiplayName = "Medicine Usage Period", ToDisplay = true)]
        public string UsagePeriod { get; set; }

        [ModelViewColumn(DiplayName = "Prescription Start", ToDisplay = true)]
        public DateTime PrescriptionStart { get; set; }

        [ModelViewColumn(DiplayName = "Prescription End", ToDisplay = true)]
        public DateTime PrescriptionEnd { get; set; }

        public PatientMedUsage()
        {
        }

        public PatientMedUsage(int patientId, string patientName, string patientAge, string usagePeriod, DateTime prescriptionStart, DateTime prescriptionEnd, string medicineName, double dosage)
        {
            PatientId = patientId;
            PatientName = patientName;
            UsagePeriod = usagePeriod;
            PatientAge = patientAge;
            Dosage = dosage;
            MedicineName = medicineName;
            PrescriptionStart = prescriptionStart;
            PrescriptionEnd = prescriptionEnd;
        }

        public static PatientMedUsage Map(SqlDataReader reader) => new PatientMedUsage
        {
            PatientId = reader.GetFieldValue<int>(reader.GetOrdinal("Patient_ID")),
            PatientName = reader.GetFieldValue<string>(reader.GetOrdinal("PatientName")),
            PatientAge = reader.GetFieldValue<string>(reader.GetOrdinal("Patient_Age")),
            MedicineName = reader.GetFieldValue<string>(reader.GetOrdinal("Medicine_Name")),
            Dosage = reader.GetFieldValue<double>(reader.GetOrdinal("Total_Dosage")),
            UsagePeriod = reader.GetFieldValue<string>(reader.GetOrdinal("UsagePeriod")),
            PrescriptionStart = reader.GetFieldValue<DateTime>(reader.GetOrdinal("Prescription_Start_Date")),
            PrescriptionEnd = reader.GetFieldValue<DateTime>(reader.GetOrdinal("Prescription_End_Date"))
        };
    }
}
