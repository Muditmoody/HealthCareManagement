-- To find valid reports for a patient having a particular disease
-- Q: Patient_ID and MedicalCondition_ID to be entered by user through API?

--Ylfa

SELECT mr.Report_ID, p.patient_id, CONCAT(p.first_name, ' ', p.last_name) AS PatientName, mr.Report_Date,
CONCAT(ph.first_name, ' ', ph.last_name) AS PhysicianName, h.Hospital_Name,
mc.Condition_Name,
	CASE WHEN mr.IsValid = 1 THEN 'Yes' ELSE 'No' END AS isValid
FROM Patient p
JOIN Medical_Report mr ON (p.Patient_ID = mr.Patient_ID)
JOIN Physician ph ON (ph.Physician_ID = mr.Physician_ID)
JOIN MedicalCondition mc ON (mc.MedicalCondition_ID = mr.MedicalCondition_ID)
JOIN Hospital h ON (mr.Hospital_ID = h.Hospital_ID)

--WHERE mr.IsValid = 1
--WHERE p.Patient_ID = 1
--WHERE PatientName like '%%'
--WHERE PhysicianName like '%%'
--WHERE Hospital_Name like '%%'
--WHERE mc.Condition_Name like '%%'
--WHERE mr.Report_Date >= '{Date}'
