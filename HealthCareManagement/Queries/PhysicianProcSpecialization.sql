--Find doctors that can perform procedures, working in a specific department and have a specific specialization – from a patient perspective

SELECT p.Physician_ID, Concat(p.First_Name, ' ' , p.Last_Name) AS Physician_Name,
mp.Procedure_Name, s.Name AS Specialization, s.Department
FROM Physician p
JOIN Physician_Procedure pp ON (p.Physician_ID = pp.Physician_ID)
JOIN Medical_Procedure mp ON (mp.Procedure_ID = pp.Procedure_ID)
JOIN Physician_Specilization ps ON (p.Physician_ID = ps.Specialization_ID)
JOIN Specialization s ON (ps.Specialization_ID = s.Specialization_ID)
--WHERE mp.Procedure_Name like '%_%'
--WHERE s.Name like '%_%'
--WHERE s.Department like '%_%'