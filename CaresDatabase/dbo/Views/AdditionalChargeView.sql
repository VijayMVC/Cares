--select * from additionalChargeView
CREATE VIEW [dbo].[AdditionalChargeView]
AS
Select AC.AdditionalChargeID,AC.ChildAdditionalChargeID,AC.AdditionalChargeTypeID,
AC.AdditionalChargeRate,AC.StartDt,AC.RowVersion,AC.RevisionNumber,
AC.IsActive, AC.IsDeleted, AC.IsPrivate,AC.IsReadOnly,AC.RecCreatedDt,
AC.RecLastUpdatedDt,AC.RecCreatedBy,AC.RecLastUpdatedBy, isnull(AC.HireGroupDetailID,0) HireGroupDetailID,
case isnull(AC.HireGroupDetailID,0) when 0 then 'All' 
else

HG.HireGroupCode+'-'+HG.HireGroupName +' | '+
VMK.VehicleMakeCode+'-'+VMK.VehicleMakeName +' | '+
VMO.VehicleModelCode+'-'+VMO.VehicleModelName +' | '+
VC.VehicleCategoryCode+'-'+VC.VehicleCategoryName +' | '+ 
cast(HGD.ModelYear as varchar(4)) end as HireGroupDetailCodeName


from AdditionalCharge AC
left outer join HireGroupDetail HGD  on AC.HireGroupDetailID = HGD.HireGroupDetailID
--inner join AdditionalChargeType ACT on ACT.AdditionalChargeTypeId = AC.AdditionalChargeTypeID
left outer join VehicleMake VMK on HGD.VehicleMakeID=VMK.VehicleMakeID
left outer join VehicleModel VMO on VMO.VehicleModelID=HGD.VehicleModelID
left outer join VehicleCategory VC on VC.VehicleCategoryID=HGD.VehicleCategoryID
left outer join HireGroup HG on HGD.HireGroupID=HG.HireGroupID