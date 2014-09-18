create view [dbo].[EmpJobProgView]
as

SELECT	
		EJP.EmpJobProgID, EJP.EmployeeID, EJP.DesignationID, EJP.WorkplaceID, EJP.DesigStDt, EJP.DesigEndDt, EJP.RowVersion, EJP.IsActive, 
		EJP.IsPrivate, EJP.IsDeleted, EJP.IsReadOnly, EJP.RecCreatedDt, EJP.RecCreatedBy, EJP.RecLastUpdatedDt, EJP.RecLastUpdatedBy,
		WPL.WorkplaceCode+'-'+WPL.WorkplaceName as WorkplaceCodeName, DSG.DesignationCode+'-'+DSG.DesignationName as DesignationCodeName
FROM	EmpJobProg EJP
		inner join Workplace WPL on EJP.WorkplaceID = WPL.WorkplaceID
		inner join Designation DSG on EJP.DesignationID = DSG.DesignationID