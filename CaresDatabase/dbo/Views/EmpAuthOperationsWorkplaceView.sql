
---------  Employee Authorized Operations Workplace begin ---------------------
---select * from EmpAuthOperationsWorkplaceView
-- Create View EmpAuthOperationsWorkplaceView
-- Dated: 24-Nov-09

CREATE VIEW [dbo].[EmpAuthOperationsWorkplaceView]
as
SELECT     
		EAOW.EmpAuthOperationsWorkplaceID, EAOW.EmployeeID, EAOW.OperationsWorkplaceID, EAOW.IsDefault, EAOW.RowVersion, EAOW.IsActive, 
		EAOW.IsPrivate,EAOW.IsOperationDefault, EAOW.IsDeleted, EAOW.IsReadOnly, EAOW.RecCreatedDt, EAOW.RecCreatedBy, EAOW.RecLastUpdatedDt, EAOW.RecLastUpdatedBy,
		OP.LocationCode as LocationCode, OP.OperationID ,O.OperationCode + '-' + O.OperationName as OperationCodeName
FROM    EmpAuthOperationsWorkplace EAOW inner join 
		OperationsWorkplace OP on OP.OperationsWorkplaceID = EAOW.OperationsWorkplaceID inner join 
		Operation O on O.OperationID = OP.OperationID

---------  Employee Authorized Operations Workplace begin ---------------------