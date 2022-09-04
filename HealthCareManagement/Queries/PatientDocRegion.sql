--Which patients are seeing the same doctor? And find the ones living in nearby areas.

SELECT CONCAT(p.first_name, ' ', p.Last_Name) AS PatientName, pp.Province_Name AS PatientProvince, pc.City_Name AS PatientCity,
CONCAT(d.first_name, ' ', d.Last_Name) AS PhysicianName, mr.Report_Date AS Since, dp.Province_Name AS DocProvince, dc.City_Name AS DocCity
FROM Patient p
JOIN Medical_Report mr ON (p.Patient_ID = mr.Patient_ID)
JOIN Province pp ON (pp.Province_ID = p.Province_ID)
JOIN City pc ON (pc.City_ID = p.City_ID)
JOIN Physician d ON (mr.Physician_ID = d.Physician_ID)
JOIN Province dp ON (dp.Province_ID = d.Province_ID)
JOIN City dc ON (dc.City_ID = p.City_ID)
ORDER BY PhysicianName, PatientName