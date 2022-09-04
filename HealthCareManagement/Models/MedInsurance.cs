using System.Data.SqlClient;

namespace HealthCareManagement.Models
{
    public class MedInsurance : HealthManagamentObjects
    {
        [ModelViewColumn(DiplayName = "MedicineId", ToDisplay = true)]
        public int MedicineId { get; set; }

        [ModelViewColumn(DiplayName = "MedicineName", ToDisplay = true)]
        public string MedicineName { get; set; }

        [ModelViewColumn(DiplayName = "HasInsurance", ToDisplay = true)]
        public string HasInsurance { get; set; }

        [ModelViewColumn(DiplayName = "Dosage (Demand)", ToDisplay = true)]
        public double Dosage { get; set; }

        public MedInsurance()
        {
        }
        public MedInsurance(int medicineId, string medicineName, string hasInsurance, double dosage)
        {
            MedicineId = medicineId;
            MedicineName = medicineName;
            HasInsurance = hasInsurance;
            Dosage = dosage;
        }

        public static MedInsurance Map(SqlDataReader reader) => new MedInsurance
        {
            MedicineId = reader.GetFieldValue<int>(reader.GetOrdinal("Medicine_ID")),
            MedicineName = reader.GetFieldValue<string>(reader.GetOrdinal("Medicine_Name")),
            Dosage = reader.GetFieldValue<double>(reader.GetOrdinal("Total_Usage")),
            HasInsurance = reader.GetFieldValue<string>(reader.GetOrdinal("hasInsurance"))
        };
    }
}