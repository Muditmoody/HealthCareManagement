--Show the hospitals and the procedures they offer. Additionally, check if they have active physicians to perform that procedure.

SELECT h.Hospital_ID, h.Hospital_Name, mp.Procedure_Name, Count(pp.Physician_ID) AS PhysicianCount
FROM Hospital h
JOIN Hospital_Procedure hp ON (h.Hospital_ID = hp.Hospital_ID)
JOIN Medical_Procedure mp ON (hp.Procedure_ID =  mp.Procedure_ID)
LEFT JOIN Physician_Procedure pp ON (pp.Procedure_ID = mp.Procedure_ID)
GROUP BY h.Hospital_ID, h.Hospital_Name, mp.Procedure_Name