create VIEW [dbo].[rptNRTMaintenanceView]
AS
--	Created : MAR, Dated:27-Dec-09

select 
	NM.NRTMainID,NV.NRTVehicleID,NV.VehicleID,V.PlateNumber,NCT.AdditionalChargeTypeCode, NCT.AdditionalChargeTypeName,
	NRTChargeID, TotalNRTChargeRate, ContactPerson, Description, NRTChargeRate, Quantity	

from NRTCharge NC
inner join AdditionalChargeType NCT on NCT.AdditionalChargeTypeID = NC.AdditionalChargeTypeID
inner join NRTVehicle NV on NC.NRTVehicleID = NV.NRTVehicleID
inner join NRTMain NM on NM.NRTMainID = NV.NRTMainID
inner join Vehicle V on NV.VehicleID = V.VehicleID