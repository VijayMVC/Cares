
--select * from vehicle
--select * from VehicleView
--select * from vehicleSubStatus
CREATE VIEW [dbo].[VehicleView]
AS
select V.*,
C.CompanyID,C.CompanyCode,C.CompanyName,C.CompanyCode+'-'+C.CompanyName CompanyCodeName,
F.FleetPoolCode,F.FleetPoolName,F.FleetPoolCode+'-'+F.FleetPoolName FleetPoolCodeName,
OWP.LocationCode,
VM.VehicleMakeCode,VM.VehicleMakeName,VM.VehicleMakeCode+'-'+VM.VehicleMakeName VehicleMakeCodeName,
VC.VehicleCategoryCode,VC.VehicleCategoryName,VC.VehicleCategoryCode+'-'+VC.VehicleCategoryName VehicleCategoryCodeName,
--VSS.VehicleSubStatusCode,VSS.VehicleSubStatusName,VSS.VehicleSubStatusCode+'-'+VSS.VehicleSubStatusName VehicleSubStatusCodeName,
FT.FuelTypeCode,TT.TransmissionTypeCode,
D.DepartmentCode,D.DepartmentName,D.DepartmentCode+'-'+D.DepartmentName DepartmentCodeName,
O.OperationCode,O.OperationName,O.OperationCode+'-'+O.OperationName OperationCodeName,
R.RegionCode,R.RegionName,R.RegionCode+'-'+R.RegionName RegionCodeName,
R.RegionID,O.OperationID,D.DepartmentID,
VS.VehicleStatusCode+'-'+VS.VehicleStatusName VehicleStatusCodeName



from vehicle V


left outer join FleetPool F on V.FleetPoolID=F.FleetPoolID

left outer join OperationsWorkPlace OWP on OWP.OperationsWorkPlaceID=V.OperationsWorkPlaceID

inner join VehicleMake VM on VM.VehicleMakeID=V.VehicleMakeID
inner join VehicleCategory VC on VC.VehicleCategoryID=V.VehicleCategoryID
--inner join VehicleSubStatus VSS on VSS.VehicleSubStatusID=V.VehicleSubStatusID
inner join VehicleStatus VS on VS.VehicleStatusID=V.VehicleStatusID
INNER JOIN FuelType FT on FT.FuelTypeID=V.FuelTypeID
inner join TransmissionType TT on TT.TransmissionTypeID=V.TransmissionTypeID
left outer join Operation O on O.OperationID=F.OperationID 
left outer join Department D on D.DepartmentID = O.DepartmentID
left outer join Company C on D.CompanyID=C.CompanyID
left outer join Region R on F.RegionID=R.RegionID