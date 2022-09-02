﻿--Is some drug usage amount insurance policy dependent (groupBy policy_ref to see the usage amount of a certain drug)

SELECT raw_data.Medicine_ID, raw_data.hasInsurance, raw_data.total_uage, m.Medicine_Name from 
(
	SELECT pr.Medicine_ID,
		CASE WHEN count(irp.Policy_Reference_Number) >0 THEN 'Yes'
			 ELSE 'NO'
		END
		AS hasInsurance,
	   sum(pr.Dosage) AS total_uage
	FROM Prescription pr 
	JOIN Medical_report mr ON (pr.Report_ID = mr.Report_ID) 
	JOIN Patient p ON (mr.Patient_ID  =  p.Patient_ID)
	LEFT JOIN Insurance_Policy irp ON (irp.Patient_ID = p.Patient_ID)
	GROUP BY pr.Medicine_ID
) AS raw_data
JOIN Medicine m ON (raw_data.Medicine_ID= m.Medicine_ID)

-- WHERE m.Medicine_ID = {1}
-- WHERE m.Medicine_Name like '%{1}%'
