
Create VIEW [dbo].[ChaufferChargeMainView]	
AS
select DISTINCT  CCM.ChaufferChargeMainID, CCM.ChaufferChargeMainCode, CCM.TariffTypeCode, CCM.ChaufferChargeMainName, CCM.ChaufferChargeMainDescription,
	 CCM.StartDt, CCM.IsActive, CCM.IsDeleted, CCM.IsPrivate, CCM.IsReadOnly, 
	CCM.RowVersion, CCM.RecCreatedDt, CCM.RecLastUpdatedDt, CCM.RecLastUpdatedBy, CCM.RecCreatedBy,
TT.TariffTypeCode+'-'+TT.TariffTypeName TariffTypeCodeName,
O.OperationCode+'-'+O.OperationName OperationCodeName,
D.DepartmentCode+'-'+D.DepartmentName DepartmentCodeName,
C.CompanyCode+'-'+C.CompanyName CompanyCodeName,
TT.TariffTypeName,O.OperationID,D.DepartmentID,C.CompanyID


from ChaufferChargeMain CCM
inner join TariffType TT on CCM.TariffTypeCode=TT.TariffTypeCode
inner join Operation O on TT.OperationID=O.OperationID
inner join Department D on D.DepartmentID=O.DepartmentID
inner join Company C on  C.CompanyID=D.CompanyID
where CCM.ISDeleted=0