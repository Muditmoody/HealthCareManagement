--To show the total usage of a certain medicine within a time range (to find the info for drugs with similar composition)
SELECT Medicine.Medicine_ID, Medicine.Medicine_Name, CONVERT(float,sum(Prescription.Dosage)) AS 'Total_Usage'
FROM Prescription
JOIN Medicine ON (Prescription.Medicine_ID = Medicine.Medicine_ID)
WHERE
	Prescription.Prescription_Start_Date >= '{0}'
	AND Prescription.Prescription_End_Date <= '{1}'
GROUP BY Medicine.Medicine_ID, Medicine.Medicine_Name