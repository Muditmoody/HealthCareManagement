using System.Data.SqlClient;

namespace HealthCareManagement.Models
{
    public class DosagePeriods : HealthManagamentObjects
    {
        [ModelViewColumn(DiplayName = "MedicineId", ToDisplay = true)]
        public int MedicineId { get; set; }

        [ModelViewColumn(DiplayName = "MedicineName", ToDisplay = true)]
        public string MedicineName { get; set; }

        [ModelViewColumn(DiplayName = "Total_Usage", ToDisplay = true)]
        public double Dosage { get; set; }

        [ModelViewColumn(DiplayName = "PrescriptionStartDate", ToDisplay = false)]
        public DateTime PrescriptionStartDate { get; set; }

        [ModelViewColumn(DiplayName = "PrescriptionEndDate", ToDisplay = false)]
        public DateTime PrescriptionEndDate { get; set; }

        public DosagePeriods()
        {
        }

        public DosagePeriods(int medicineId, string medicineName, double dosage, DateTime prescriptionStartDate, DateTime prescriptionEndDate)
        {
            MedicineId = medicineId;
            MedicineName = medicineName;
            Dosage = dosage;
            PrescriptionStartDate = prescriptionStartDate;
            PrescriptionEndDate = prescriptionEndDate;
        }

        public static DosagePeriods Map(SqlDataReader reader) => new DosagePeriods
        {
            MedicineId = reader.GetFieldValue<int>(reader.GetOrdinal("Medicine_ID")),
            MedicineName = reader.GetFieldValue<string>(reader.GetOrdinal("Medicine_Name")),
            Dosage = reader.GetFieldValue<double>(reader.GetOrdinal("Total_Usage")),
        };
    }
}
