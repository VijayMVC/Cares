
CREATE VIEW [dbo].[VehicleCheckListItemView]
AS
select VCLI.*,
VCL.VehicleCheckListCode+'-'+VCL.VehicleCheckListName VehicleCheckListCodeName,
VCL.VehicleCheckListCode,VCL.VehicleCheckListName,1 as ChkVehicleCheckList,VCL.IsInterior -- this line is used for RA POP up Vehicle checklist
 from VehicleCheckListItem VCLI 
inner join VehicleCheckList VCL on VCLI.VehicleCheckListID= VCL.VehicleCheckListID