CREATE VIEW AppointmentsHighlights AS
SELECT A.Id, AT.Code  + P.Name +  C.FullName As Title 
FROM Patients P INNER JOIN
Appointments A ON P.Id = A.PatientId INNER JOIN
Clients C ON P.ClientId = C.Id INNER JOIN
AppointmentTypes AT ON A.AppointmentTypeId = AT.Id;