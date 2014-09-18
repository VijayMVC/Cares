
CREATE view [dbo].[OperationView]
as
SELECT     
		OPR.OperationID, OPR.OperationCode, OPR.OperationName, OPR.OperationDescription, OPR.DepartmentID, OPR.RowVersion, OPR.IsActive, 
		OPR.IsDeleted, OPR.IsPrivate, OPR.IsReadOnly, OPR.RecCreatedDt, OPR.RecCreatedBy, OPR.RecLastUpdatedDt, OPR.RecLastUpdatedBy,
		DP.DepartmentCode+'-'+DP.DepartmentName as DepartmentCodeName,
		DP.DepartmentType, 
		CMP.CompanyID, CMP.CompanyCode +'-'+CMP.CompanyName as CompanyCodeName,
		ORG.OrgGroupID,ORG.OrgGroupCode+'-'+ORG.OrgGroupName as OrgGroupCodeName
FROM    
		Operation OPR
		inner join Department DP on OPR.DepartmentID = DP.DepartmentID
		inner join Company CMP on CMP.CompanyID = DP.CompanyID
		left outer join OrgGroup ORG on CMP.OrgGroupID = ORG.OrgGroupID