
CREATE view [dbo].[EmployeeView]
as
SELECT  EMP.EmployeeID, EMP.EmpCode, EMP.EmpFName,EMP.CompanyID, EMP.EmpStatusID, EMP.EmpMName, EMP.EmpLName, EMP.DOB, EMP.Gender, EMP.Nationality, EMP.Notes, 
		EMP.AddNotes1, EMP.AddNotes2, EMP.AddNotes3, 
		EMP.AddNotes4, EMP.AddNotes5, EMP.RowVersion, EMP.IsActive, EMP.IsDeleted, EMP.IsPrivate, EMP.IsReadOnly, EMP.RecCreatedDt, 
		EMP.RecCreatedBy,EMP.RecLastUpdatedDt, EMP.RecLastUpdatedBy,
		EMS.EmpStatusCode +'-'+ EmpStatusName as EmpStatusCodeName,
		CMP.CompanyCode +'-'+ CMP.CompanyName as CompanyCodeName,
		CNT.CountryCode +'-'+ CNT.CountryName as NationalityCodeName
from Employee EMP
inner join EmpStatus EMS on EMP.EmpStatusID = EMS.EmpStatusID
inner join Company CMP on EMP.CompanyID = CMP.CompanyID
left join Country CNT on EMP.Nationality = CNT.CountryID