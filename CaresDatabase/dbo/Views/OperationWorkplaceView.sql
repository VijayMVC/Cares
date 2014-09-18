
CREATE view [dbo].[OperationWorkplaceView]
as
SELECT		
		OWP.OperationsWorkplaceID, OWP.LocationCode, OWP.WorkplaceID, OWP.OperationID,OWP.FleetPoolID,OWP.CostCenter, OWP.RowVersion, OWP.IsActive, OWP.IsDeleted, OWP.IsPrivate, 
		OWP.IsReadOnly, OWP.RecCreatedDt, OWP.RecCreatedBy, OWP.RecLastUpdatedDt, OWP.RecLastUpdatedBy,
		WP.WorkPlaceCode+'-'+WorkPlaceName as WorkplaceCodeName, 
		WPT.WorkPlaceTypeCode+'-'+WorkPlaceTypeName as WorkplaceTypeCodeName,
		OP.OperationCode+'-'+ OP.OperationName as OperationCodeName,
		FLp.FleetPoolCode+'-'+FLP.FleetPoolname as FleetPoolCodeName
		
FROM       
		OperationsWorkplace OWP 
		inner join WorkPlace WP on OWP.WorkPlaceID = WP.WorkPlaceID
		inner join WorkPlaceType WPT on WPT.WorkPlaceTypeID = WP.WorkPlaceTypeID
		Inner join Operation OP on OWP.OperationID = OP.OperationID
		inner join Department DP on OP.DepartmentID = DP.DepartmentID
		left outer join FleetPool FLP on FLP.FleetPoolID = OWP.FleetPoolID