-- Show the patient and list the medicine have a taking a medicine long term (consuming it more than 6 months)

SELECT p.Patient_ID ,Concat(p.First_Name, ' ', p.Last_Name) AS PatientName, m.Medicine_Name, Convert(float,pr.Dosage) As Total_Dosage ,
Concat(CONVERT(int,ROUND(DATEDIFF(hour,p.Date_of_birth,GETDATE())/8766.0,0)),' Years') AS Patient_Age,
Concat(DATEDIFF(MONTH,pr.Prescription_Start_Date, pr.Prescription_End_Date) ,' Months') AS UsagePeriod,
pr.Prescription_Start_Date, pr.Prescription_End_Date
FROM Patient p
JOIN Medical_Report mr ON (p.Patient_ID = mr.Patient_ID)
JOIN Prescription pr ON (mr.Report_ID = pr.Report_ID)
JOIN Medicine m ON (pr.Medicine_ID = m.Medicine_ID)
--WHERE DATEDIFF(MONTH,pr.Prescription_Start_Date, pr.Prescription_End_Date) > 6