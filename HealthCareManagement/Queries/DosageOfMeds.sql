--To show the total usage of a certain medicine within a time range (to find the info for drugs with similar composition)

--Ylfa

SELECT m.Medicine_ID, m.Medicine_Name, CONVERT(float,sum(pr.Dosage)) AS 'Total_Usage'
FROM Prescription pr
JOIN Medicine m ON (pr.Medicine_ID = m.Medicine_ID)
WHERE
	pr.Prescription_Start_Date >= '{0}'
	AND pr.Prescription_End_Date <= '{1}'
GROUP BY m.Medicine_ID, m.Medicine_Name