
--select * from rptHireGroupDetailView
CREATE VIEW [dbo].[rptHireGroupDetailView]
AS
select V.PlateNumber,V.VehicleID,V.VehicleCategoryID,V.VehicleMakeID,V.VehicleModelID,V.ModelYear,v.FleetPoolID,
	VM.VehicleMakeCode,VM.VehicleMakeName,
	VMO.VehicleModelCode,VMO.VehicleModelName,
	VC.VehicleCategoryCode,VC.VehicleCategoryName,
	HG.HireGroupCode,HG.HireGroupName, HG.CompanyID,
	HG.HireGroupID HireGroupID,HG.ParentHireGroupID,HGD.HireGroupDetailID,
	case isnull(PHG.HireGroupID,0) when 0 then ''  else PHG.HireGroupCode end ParentHireGroupCode,
	FP.FleetPoolCode, FP.FleetPoolName,
	V.Color,V.CurrentOdometer,
		isnull(VPI.PurchaseDate,VLI.LeasedStartDate) DaysInService,
		V.VehicleStatusID,V.OperationsWorkPlaceID,
	VS.VehicleStatusCode,VS.VehicleStatusName,
	VS.VehicleStatusKey,VS.AvailabilityCheck,
	OWP.LocationCode
	
	from hiregroupdetail HGD
	inner join HireGroup HG on HG.HireGroupID = HGD.HireGroupID
	left outer join HireGroup PHG on HG.ParentHireGroupID = PHG.HireGroupID
	inner join Vehicle V on V.VehicleModelID = HGD.VehicleModelID and V.VehicleCategoryID = HGD.VehicleCategoryID
	and V.VehicleCategoryID=HGD.VehicleCategoryID and V.ModelYear = HGD.ModelYear
	inner join VehicleMake VM on VM.VehicleMakeID=V.VehicleMakeID
	inner join VehicleModel VMO on VMO.VehicleModelID = V.VehicleModelID
	inner join VehicleCategory VC on VC.VehicleCategoryID= V.VehicleCategoryID
	left outer join FleetPool FP on V.FleetPoolID = FP.FleetPoolID
	left outer join VehiclePurchaseInfo VPI on VPI.VehicleID=V.VehicleID
	left outer join VehicleLeasedInfo VLI on VLI.VehicleID=V.VehicleID
	inner join VehicleStatus VS on VS.VehicleStatusID=V.VehicleStatusID
	inner join OperationsWorkPlace OWP on OWP.OperationsWorkPlaceID = V.OperationsWorkPlaceID