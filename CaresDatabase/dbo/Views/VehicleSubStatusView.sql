
CREATE VIEW [dbo].[VehicleSubStatusView]
AS
SELECT     VSS.*,
VS.VehicleStatusCode +'-'+ VS.VehicleStatusCode AS VehicleStatusCodeName
from VehicleSubStatus VSS 
inner join  VehicleStatus VS 
on VSS.VehicleStatusID=VS.VehicleStatusID