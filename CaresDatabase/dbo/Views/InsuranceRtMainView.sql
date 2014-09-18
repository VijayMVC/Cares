
create VIEW [dbo].[InsuranceRtMainView]
AS
select DISTINCT  SRM.InsuranceRtMainID, SRM.InsuranceRtMainCode, SRM.TariffTypeCode, SRM.InsuranceRtMainName, SRM.InsuranceRtMainDescription,
	 SRM.StartDt, SRM.IsActive, SRM.IsDeleted, SRM.IsPrivate, SRM.IsReadOnly, 
	SRM.RowVersion, SRM.RecCreatedDt, SRM.RecLastUpdatedDt, SRM.RecLastUpdatedBy, SRM.RecCreatedBy,
TT.TariffTypeCode+'-'+TT.TariffTypeName TariffTypeCodeName,
O.OperationCode+'-'+O.OperationName OperationCodeName,
D.DepartmentCode+'-'+D.DepartmentName DepartmentCodeName,
C.CompanyCode+'-'+C.CompanyName CompanyCodeName,
TT.TariffTypeName,O.OperationID,D.DepartmentID,C.CompanyID


from InsuranceRtMain SRM
inner join TariffType TT on SRM.TariffTypeCode=TT.TariffTypeCode
inner join Operation O on TT.OperationID=O.OperationID
inner join Department D on D.DepartmentID=O.DepartmentID
inner join Company C on  C.CompanyID=D.CompanyID
where SRM.ISDeleted=0