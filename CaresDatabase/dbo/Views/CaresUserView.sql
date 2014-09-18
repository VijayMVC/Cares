
CREATE view [dbo].[CaresUserView]
as
SELECT     
		CU.UserID, CU.LoginID, CU.UserName, CU.Description, CU.LoweredUserName, CU.Password, 
		CU.IsLockedOut, CU.EmployeeID, CU.RoleID, CU.FailedPasswordAttemptCount,
        CU.MaxPasswordAttemptAllowed, CU.RowVersion, CU.IsActive, CU.IsDeleted, CU.IsReadOnly, CU.IsPrivate, 
		CU.RecCreatedDt, CU.RecCreatedBy, CU.RecLastUpdatedDt, CU.RecLastUpdatedBy, 
		EMP.EmpCode+'-'+EMP.EmpFName as EmpCodeName, ROL.RoleCode+'-'+ROL.RoleName as RoleCodeName
		
FROM    CaresUser CU
		inner join Employee EMP on CU.EmployeeID = EMP.EmployeeID
		inner join [Role] ROL on ROL.RoleID = CU.RoleID