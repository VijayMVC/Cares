create VIEW [dbo].[EmpCompanyInfoView]
as
SELECT      
		Emp.CompanyID,Emp.EmployeeID,
		EAOW.EmpAuthOperationsWorkplaceID, EAOW.OperationsWorkplaceID, EAOW.IsDefault, EAOW.RowVersion, EAOW.IsActive, 
		EAOW.IsPrivate,EAOW.IsOperationDefault, EAOW.IsDeleted, EAOW.IsReadOnly, EAOW.RecCreatedDt, EAOW.RecCreatedBy, EAOW.RecLastUpdatedDt, EAOW.RecLastUpdatedBy,
		OP.LocationCode as LocationCode, OP.OperationID ,O.OperationCode + '-' + O.OperationName as OperationCodeName

FROM    Employee EMP
		left outer join EmpAuthOperationsWorkplace EAOW on EAOW.EmployeeID=Emp.EmployeeID
		left outer join OperationsWorkplace OP on OP.OperationsWorkplaceID = EAOW.OperationsWorkplaceID 
		left outer join 		Operation O on O.OperationID = OP.OperationID



---------  Employee Authorized Operations Workplace begin ---------------------