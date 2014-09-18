
CREATE View [dbo].[WorkplaceView]
as
SELECT     
		WP.WorkplaceID, WP.WorkplaceCode, WP.WorkplaceName, WP.WorkplaceDescription, WP.ParentWorkplaceID, WP.WorkplaceTypeID, 
		WP.WorkLocationID, WP.RowVersion, WP.IsActive, WP.IsDeleted, WP.IsPrivate, WP.IsReadOnly, WP.RecCreatedDt, WP.RecCreatedBy, WP.RecLastUpdatedDt, WP.RecLastUpdatedBy,
		WL.WorkLocationCode+'-'+WL.WorkLocationName as WorkLocationCodeName, WL.CompanyID, 
		WPT.WorkPlaceTypeCode+'-'+WPT.WorkplaceTypeName as WorkplaceTypeCodeName, PWP.WorkPlaceCode+'-'+PWP.WorkPlaceName as ParentWorkplaceCodeName,
		CMP.CompanyCode+'-'+CMP.CompanyName as CompanyCodeName
FROM       
		Workplace WP
		inner join WorkLocation WL on WL.WorkLocationID = WP.WorkLocationID
		inner join WorkPlaceType WPT on WPT.WorkPlaceTypeID = WP.WorkPlaceTypeID		
		left outer join WorkPlace PWP on WP.ParentWorkPlaceID = PWP.WorkPlaceID
		inner join Company CMP on CMP.CompanyID = WL.CompanyID