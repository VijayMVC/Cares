
CREATE VIEW [dbo].[RAHireGroupView]
AS
select RAHG.*,HG.HireGroupCode,HG.HireGroupName ,VM.VehicleMakeCode,VM.VehicleMakeName ,VMO.VehicleModelCode,VMO.VehicleModelName,VC.VehicleCategoryCode,
VC.VehicleCategoryName ,ModelYear ,
HG.HireGroupCode+'-'+HG.HireGroupName +' | '+ VM.VehicleMakeCode+'-'+VM.VehicleMakeName +' | '+VMO.VehicleModelCode+'-'+VMO.VehicleModelName+' | '+
VC.VehicleCategoryCode+'-'+VC.VehicleCategoryName +' | '+Cast(ModelYear as nvarchar(10)) RAHireGroupCodeName,HG.HireGroupID

from RAHireGroup RAHG
inner join HireGroupDetail HGD on RAHG.HireGroupDetailID = HGD.HireGroupDetailID
inner join VehicleMake VM on VM.VehicleMakeID= HGD.VehicleMakeID
inner join VehicleModel VMO on VMO.VehicleModelID= HGD.VehicleModelID
inner join VehicleCategory VC on VC.VehicleCategoryID= HGD.VehicleCategoryID
inner join HireGroup HG on HG.HireGroupID = HGD.HireGroupID