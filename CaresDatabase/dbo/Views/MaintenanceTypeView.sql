
CREATE VIEW [dbo].[MaintenanceTypeView]
AS
SELECT     MT.*,
MTG.MaintenanceTypeGroupCode +'-'+ MTG.MaintenanceTypeGroupCode AS MaintenanceTypeGroupCodeName, 
                      MTG.IsActive AS MaintenanceTypeGroupIsActive
from MaintenanceType MT 
inner join  MaintenanceTypeGroup MTG 
on MT.MaintenanceTypeGroupID=MTG.MaintenanceTypeGroupID