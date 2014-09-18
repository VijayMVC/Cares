
--select * from LoadHireGroupStandardRtView
CREATE VIEW [dbo].[LoadHireGroupStandardRtView]
AS
select SR.StandardRtID, SR.ChildStandardRtID, SR.StandardRtMainID,SR.AllowedMileage, 
	SR.ExcessMileageChrg, SR.StandardRate, SR.RevisionNumber, SR.IsActive, SR.IsDeleted, 
                      SR.IsPrivate, SR.IsReadOnly, SR.RowVersion, SR.RecCreatedDt, SR.RecLastUpdatedDt, SR.RecCreatedBy, SR.RecLastUpdatedBy,
HG.HireGroupID,HG.HireGroupCode,HG.HireGroupName,HG.ParentHireGroupID,HG.CompanyID,C.CompanyCode+'-'+C.CompanyName CompanyCodeName,
VMK.VehicleMakeCode+'-'+VMK.VehicleMakeName VehicleMakeCodeName,
VMO.VehicleModelCode+'-'+VMO.VehicleModelName VehicleModelCodeName,
VC.VehicleCategoryCode+'-'+VC.VehicleCategoryName VehicleCategoryCodeName,
case isnull(SR.StandardRtID,0) when  0 then 0 else 1 end ChkStandardRt
from HireGroupDetail	 HGD 
left outer join StandardRt SR on SR.HireGroupDetailID=HGD.HireGroupDetailID
inner join HireGroup HG on HG.HireGroupID=HGD.HireGroupID
inner join Company C on C.CompanyID=HG.CompanyID
inner join VehicleMake VMK on HGD.VehicleMakeID=VMK.VehicleMakeID
inner join VehicleModel VMO on VMO.VehicleModelID=HGD.VehicleModelID
inner join VehicleCategory VC on VC.VehicleCategoryID=HGD.VehicleCategoryID

where HG.IsParent=0 and SR.ChildStandardRtID is null