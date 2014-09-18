
--select * from rptInsuranceRtView
CREATE VIEW [dbo].[rptInsuranceRtView]
AS
select IR.InsuranceRtID,IR.ChildInsuranceRtID,IR.InsuranceRtMainID,IR.InsuranceRate,IR.StartDt,IR.
IsActive,IR.RevisionNumber,IR.IsDeleted,IR.IsPrivate,IR.IsReadOnly,IR.RowVersion,IR.RecCreatedDt,IR.
RecLastUpdatedDt,IR.RecLastUpdatedBy,IR.RecCreatedBy, IRM.InsuranceRtMainCode,IRM.InsuranceRtMainName,IRM.StartDt InsuranceRTMainStartDt,
TT.TariffTypeID,TT.TariffTypeCode,O.OperationID,
O.OperationCode,O.OperationName,DT.DepartmentID,DT.DepartmentCode,
DT.DepartmentName, 
TT.ChildTariffTypeID,TT.RevisionNumber TariffRevisionNumber,
DT.DepartmentType,
C.CompanyID,C.CompanyCode,C.CompanyName,
IT.InsuranceTypeCode,IT.InsuranceTypeName,IT.InsuranceTypeID,
HGD.HireGroupDetailID,HGD.ModelYear,
HG.HireGroupID,HG.HireGroupCode,HG.HireGroupName,
VM.VehicleMakeID,VM.VehicleMakeCode,VM.VehicleMakeName,
VMO.VehicleModelID,VMO.VehicleModelCode,VMO.VehicleModelName,
VC.VehicleCategoryID,VC.VehicleCategoryCode,VC.VehicleCategoryName,
isnull(IR.IsDeleted,0) InsuranceRtIsDeleted, isnull(IRM.IsDeleted,0) InsuranceRtMainIsDeleted,isnull(TT.IsDeleted,0) TariffTypeIsDeleted

--select * 
from InsuranceType IT

cross join HireGroupDetail HGD
cross join TariffType TT

left outer join InsuranceRtMain IRM on IRM.TariffTypeCode=TT.TariffTypeCode
left outer join InsuranceRt IR on IRM.InsuranceRtMainID= IR.InsuranceRtMainID and  IR.InsuranceTypeID=IT.InsuranceTypeID and IR.HireGroupDetailID=HGD.HireGroupDetailID
inner join Operation O on TT.OperationID = O.OperationID
inner join Department DT on DT.DepartmentID = O.DepartmentId
inner join Company C on C.CompanyID = DT.CompanyID
inner join HireGroup HG on HGD.HireGroupID = HG.HireGroupID
inner join VehicleMake VM on VM.VehicleMakeID= HGD.VehicleMakeID
inner join VehicleModel VMO on VMO.VehicleModelID = HGD.VehicleModelID
inner join VehicleCategory VC on VC.VehicleCategoryID = HGD.VehicleCategoryID