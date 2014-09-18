
CREATE VIEW [dbo].[VehicleMaintenanceTypeFrequencyView]
AS
SELECT     VMF.*,MT.MaintenanceTypeCode+'-'+MT.MaintenanceTypeName MaintenanceTypeCodeName
FROM    VehicleMaintenanceTypeFrequency VMF INNER JOIN
		MaintenanceType MT 
		on   MT.MaintenanceTypeID=VMF.MaintenanceTypeID