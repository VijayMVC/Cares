
CREATE VIEW [dbo].[HireGroupDetailView]
AS
SELECT  HGD.*,
VMK.VehicleMakeCode+'-'+VMK.VehicleMakeName VehicleMakeCodeName,
VMO.VehicleModelCode+'-'+VMO.VehicleModelName VehicleModelCodeName,
VC.VehicleCategoryCode+'-'+VC.VehicleCategoryName VehicleCategoryCodeName,
HG.HireGroupCode+'-'+HG.HireGroupName HireGroupCodeName, HG.CompanyID
from HireGroupDetail HGD
inner join VehicleMake VMK on HGD.VehicleMakeID=VMK.VehicleMakeID
inner join VehicleModel VMO on VMO.VehicleModelID=HGD.VehicleModelID
inner join VehicleCategory VC on VC.VehicleCategoryID=HGD.VehicleCategoryID
inner join HireGroup HG on HGD.HireGroupID=HG.HireGroupID