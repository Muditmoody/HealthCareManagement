--Find the mix if patients with certain disease opt for procedures or go for medicines.

SELECT p.Patient_ID, CONCAT(p.First_Name, ' ', p.Last_Name) AS Patient_Name,
mc.Condition_Name,
	IsNUll(rp.Procedure_Name,'-') AS Procedure_Name,
	IsNUll(rp.Procedure_Date,cast(-53690 as datetime)) AS Procedure_Date,
	IsNUll(pr.Medicine_Name,'-') AS Medicine_Name,
	IsNUll(pr.Prescription_Start_Date,cast(-53690 as datetime)) AS Prescription_Start_Date,
	IsNUll(pr.Prescription_End_Date,cast(-53690 as datetime)) AS Prescription_End_Date
FROM Patient p
JOIN Medical_Report mr ON (p.Patient_ID = mr.Patient_ID)
JOIN MedicalCondition mc ON (mr.MedicalCondition_ID = mc.MedicalCondition_ID)
LEFT JOIN
	(
		SELECT rp.Procedure_Date, rp.Report_ID, mp.Procedure_Name
		FROM Report_Procedure rp
		JOIN Medical_Procedure mp ON (rp.Procedure_ID = mp.Procedure_ID)
	)
	AS rp ON (rp.Report_ID= mr.Report_ID)
LEFT JOIN
	(
		SELECT pr.Prescription_Start_Date, pr.Prescription_End_Date,m.Medicine_Name , pr.Report_ID
		FROM Prescription pr
		JOIN Medicine m ON (m.Medicine_ID = pr.Medicine_ID)
	)
	AS pr ON (pr.Report_ID = mr.Report_ID)
-- WHERE mc.Condition_Name like '%_%'