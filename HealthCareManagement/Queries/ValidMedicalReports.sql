-- To find valid reports for a patient having a particular disease
-- Q: Patient_ID and MedicalCondition_ID to be entered by user through API? 


SELECT * FROM Medical_Report WHERE Patient_ID = 1 AND MedicalCondition_ID = 1 AND IsValid = "Y";