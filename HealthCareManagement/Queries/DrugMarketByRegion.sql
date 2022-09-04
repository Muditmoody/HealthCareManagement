-- By cities, provinces, ranking of drugs. And find competitors
-- Q: City_ID and Province_ID to be entered by user through API? Dosage should be int (mg)?

--Ylfa
SELECT raw_data.Medicine_ID, raw_data.Potential_Market, raw_data.PatientsCount, m.Medicine_Name, hc.City_Name, hp.Province_Name,
		m.Med_Price FROM
(SELECT pr.Medicine_ID, sum(pr.Dosage) AS Potential_Market, count(Distinct(mr.Patient_ID)) as PatientsCount,
		h.Province_ID Hospital_Province, h.City_ID AS Hospital_City
FROM Medical_Report mr
	 JOIN Hospital h ON (mr.Hospital_ID = h.Hospital_ID)
	 JOIN Prescription pr ON (mr.Report_ID = pr.Report_ID)

GROUP BY pr.Medicine_ID, h.Province_ID, h.City_ID
) AS raw_data
	JOIN Province hp ON (raw_data.Hospital_Province = hp.Province_ID)
	JOIN City hc ON (raw_data.Hospital_City = hc.City_ID)
	JOIN Medicine m ON (m.Medicine_ID = raw_data.Medicine_ID)
--WHERE  raw_data.Hospital_Province = 1
--    AND raw_data.Hospital_City = 1
