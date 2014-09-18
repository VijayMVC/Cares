
--select * from rptStandardRtView where 
CREATE VIEW [dbo].[rptStandardRtView]
AS
select SR.StandardRtID,SR.ChildStandardRtID,SR.StandardRtMainID,SR.StandardRate,SR.AllowedMileage,SR.ExcessMileageChrg, SR.StandardRtStartDt,SR.StandardRtEndDt,
SR.IsActive,SR.RevisionNumber,SR.IsDeleted,SR.IsPrivate,SR.IsReadOnly,SR.RowVersion,SR.RecCreatedDt,SR.
RecLastUpdatedDt,SR.RecLastUpdatedBy,SR.RecCreatedBy, SRM.StandardRtMainCode,SRM.StandardRtMainName,SRM.StartDt StandardRTMainStartDt,
--SRM.StandardRtMainCode,SRM.StandardRtMainName,
SRM.EndDt StandardRTMainEndDt,
TT.TariffTypeID,TT.TariffTypeCode,O.OperationID,
O.OperationCode,O.OperationName,DT.DepartmentID,DT.DepartmentCode,
DT.DepartmentName, 
TT.ChildTariffTypeID,TT.RevisionNumber TariffRevisionNumber,
DT.DepartmentType,
C.CompanyID,C.CompanyCode,C.CompanyName,
--IT.InsuranceTypeCode,IT.InsuranceTypeName,IT.InsuranceTypeID,
HGD.HireGroupDetailID,HGD.ModelYear,
HG.HireGroupID,HG.HireGroupCode,HG.HireGroupName,
VM.VehicleMakeID,VM.VehicleMakeCode,VM.VehicleMakeName,
VMO.VehicleModelID,VMO.VehicleModelCode,VMO.VehicleModelName,
VC.VehicleCategoryID,VC.VehicleCategoryCode,VC.VehicleCategoryName,
isnull(SR.IsDeleted,0) StandardRtIsDeleted, isnull(SRM.IsDeleted,0) StandardRtMainIsDeleted,isnull(TT.IsDeleted,0) TariffTypeIsDeleted
--select * 
from HireGroupDetail HGD
cross join TariffType TT

left outer join StandardRtMain SRM on SRM.TariffTypeCode=TT.TariffTypeCode
left outer join StandardRt SR on SRM.StandardRtMainID= SR.StandardRtMainID and  SR.HireGroupDetailID=HGD.HireGroupDetailID
inner join Operation O on TT.OperationID = O.OperationID
inner join Department DT on DT.DepartmentID = O.DepartmentId
inner join Company C on C.CompanyID = DT.CompanyID
inner join HireGroup HG on HGD.HireGroupID = HG.HireGroupID
inner join VehicleMake VM on VM.VehicleMakeID= HGD.VehicleMakeID
inner join VehicleModel VMO on VMO.VehicleModelID = HGD.VehicleModelID
inner join VehicleCategory VC on VC.VehicleCategoryID = HGD.VehicleCategoryID