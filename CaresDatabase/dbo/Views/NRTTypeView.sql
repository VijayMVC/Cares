
create VIEW [dbo].[NRTTypeView]
AS
SELECT NRT.*,VS.VehicleStatusCode+'-'+VS.VehicleStatusName VehicleStatusCodeName from NRTType NRT
left outer join VehicleStatus VS on NRT.VehicleStatusID=VS.VehicleStatusID