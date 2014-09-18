
CREATE VIEW [dbo].[RAAdditionalChargeView]
AS
SELECT     RAC.*,ACT.AdditionalChargeTypeCode,ACT.AdditionalChargeTypeName,
HGV.HireGroupCodeName+' | '+ HGV.VehicleMakeCodeName+' | '+HGV.VehicleModelCodeName+' | '+ HGV.VehicleCategoryCodeName +' | '+Cast(ModelYear as nvarchar(10)) HireGroupDetailCodeName,
cast(RAC.AdditionalChargeTypeID as nvarchar(15))+ '-' +Cast(isnull(RAC.HireGroupDetailID,0) as nvarchar(15))AdditionalTypeChargeID  
from RAAdditionalCharge RAC
inner join AdditionalChargeType ACT on RAC.AdditionalChargeTypeID= ACT.AdditionalChargeTypeID
left outer join HireGroupDetailView HGV on RAC.HireGroupDetailID= HGV.HireGroupDetailID