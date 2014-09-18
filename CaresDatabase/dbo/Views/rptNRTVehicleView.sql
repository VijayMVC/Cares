CREATE VIEW [dbo].[rptNRTVehicleView]
AS
-- Created : MAR, Dated:27-Dec-09
select 
	NM.NRTMainID, NM.NRTTypeID,
	NV.NRTVehicleID, NV.VehicleID, 
	V.PlateNumber, V.ModelYear, V.VehicleMakeID, V.TankSize,
    VC.VehicleCategoryID, VMD.VehicleModelID, VM.VehicleMakeCode, VM.VehicleMakeName,
    VC.VehicleCategoryCode, VC.VehicleCategoryName, 
    VMD.VehicleModelCode, VMD.VehicleModelName,
	OWPO.LocationCode as VehicleOutLocationCode, NVMO.DtTime as VehicleOutDtTime, NVMO.Odometer as VehicleOutOdometer,
	NVMO.FuelLevel as VehicleOutFuelLevel, NVMO.VehicleMovementDescription as VehicleOutMovementDes,
	VSO.VehicleStatusCode as VehicleOutStatusCode, VSO.VehicleStatusName as VehicleOutStatusName,
	OWPI.LocationCode as VehicleINLocationCode, NVMI.DtTime as VehicleINDtTime, NVMI.Odometer as VehicleINOdometer,
	NVMI.FuelLevel as VehicleINFuelLevel, NVMI.VehicleMovementDescription as VehicleINMovementDes,
	VSI.VehicleStatusCode as VehicleINStatusCode, VSI.VehicleStatusName as VehicleINStatusName

from NRTVehicle NV
inner join NRTMain NM on NV.NRTMainID = NV.NRTMainID
INNER JOIN Vehicle V ON NV .VehicleID = V.VehicleID 
INNER JOIN VehicleMake VM ON V.VehicleMakeID = VM.VehicleMakeID 
INNER JOIN VehicleCategory VC ON V.VehicleCategoryID = VC.VehicleCategoryID 
INNER JOIN VehicleModel VMD ON V.VehicleModelID = VMD.VehicleModelID
inner join NRTVehicleMovement NVMO on NV.NRTVehicleID = NVMO.NRTVehicleID and NVMO.MovementStatus = 0
inner join OperationsWorkplace OWPO on OWPO.OperationsWorkplaceID = NVMO.OperationsWorkplaceID 
inner join VehicleStatus VSO on NVMO.VehicleStatusID = VSO.VehicleStatusID 
inner join NRTVehicleMovement NVMI on NV.NRTVehicleID = NVMI.NRTVehicleID and NVMI.MovementStatus = 1
inner join OperationsWorkplace OWPI on OWPI.OperationsWorkplaceID = NVMO.OperationsWorkplaceID 
inner join VehicleStatus VSI on NVMO.VehicleStatusID = VSI.VehicleStatusID