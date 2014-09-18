
CREATE view [dbo].[DepartmentView]
as
SELECT		DP.DepartmentID, DP.DepartmentCode, DP.DepartmentName, DP.DepartmentDescription, DP.DepartmentType, DP.CompanyID, 
			DP.RowVersion, DP.IsActive, DP.IsDeleted, DP.IsPrivate, 
			DP.IsReadOnly, DP.RecCreatedDt, DP.RecCreatedBy, DP.RecLastUpdatedDt, DP.RecLastUpdatedBy,
			CMP.CompanyCode+'-'+CMP.CompanyName as CompanyCodeName
FROM        Department DP
			inner join Company CMP on CMP.CompanyID = DP.CompanyID