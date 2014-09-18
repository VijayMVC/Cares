
--select * from StandardDiscount
CREATE view [dbo].[StandardDiscountView]
as
select SD.*,
SDM.TariffTypeCode,SDM.StandardDiscountMainCode,SDM.StandardDiscountMainName,
SDM.StartDt,SDM.EndDt,
OWP.LocationCode,
VM.VehicleMakeCode +'-'+VM.VehicleMakeName VehicleMakeCodeName,
BRT.BPRatingTypeCode+'-'+BRT.BPRatingTypeName BPRatingTypeCodeName,
VC.VehicleCategoryCode+'-'+VC.VehicleCategoryName VehicleCategoryCodeName,
VMO.VehicleModelCode+'-'+VMO.VehicleModelName VehicleModelCodeName,
HG.HireGroupCode+'-'+HG.HireGroupName HireGroupCodeName,
RI.RoleCode+'-'+RI.RoleName RoleCodeName

from StandardDiscount SD
inner join StandardDiscountMain SDM on SDM.StandardDiscountMainID=SD.StandardDiscountMainID
left outer join OperationsWorkPlace OWP on SD.OperationsWorkPlaceID=OWP.OperationsWorkPlaceID
left outer join VehicleMake VM on VM.VehicleMakeID = SD.VehicleMakeID
left outer join BPRatingType BRT on BRT.BPRatingTypeID= SD.BPRatingTypeID
left outer join VehicleCategory VC on VC.VehicleCategoryID= SD.VehicleCategoryID
left outer join VehicleModel VMO on VMO.VehicleModelID = SD.VehicleModelID
left outer join HireGroup HG on HG.HireGroupID=SD.HireGroupID
left outer join Role RI on SD.RoleID = RI.RoleID
where SD.IsDeleted=0 and SD.ChildStandardDiscountID is null and SDM.IsDeleted=0