--By cities, provinces, ranking of diseases. And find the number of patients
-- Q: City_ID and Province_ID to be entered by user through API?
--Ylfa

SELECT * FROM
(
	SELECT mc.Condition_Name, pr.Province_Name, c.City_Name , count(DISTINCT mr.Patient_ID) AS 'PatientCount'
	FROM Medical_Report mr
		JOIN MedicalCondition mc ON (mr.MedicalCondition_ID = mc.MedicalCondition_ID)
		JOIN Hospital h ON (mr.Hospital_ID = h.Hospital_ID)
		JOIN Province pr ON (h.Province_ID = pr.Province_ID)
		JOIN City c ON (h.City_ID = c.City_ID)

	WHERE mr.IsValid = 1
	GROUP BY mc.Condition_Name, pr.Province_Name, c.City_Name
) AS raw_data
--WHERE raw_data.Province_Name like '%%'
--WHERE raw_data.City_Name like '%%'
--WHERE raw_data.Condition_Name like '%%'
