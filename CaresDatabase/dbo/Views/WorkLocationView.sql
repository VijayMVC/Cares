
CREATE view [dbo].[WorkLocationView] 
as
SELECT  
		WLC.WorkLocationID, WLC.WorkLocationCode, WLC.WorkLocationName, WLC.WorkLocationDescription, WLC.CompanyID, WLC.RowVersion, WLC.IsActive, 
		WLC.IsDeleted, WLC.IsPrivate, WLC.IsReadOnly, WLC.RecCreatedDt, WLC.RecCreatedBy, WLC.RecLastUpdatedDt, WLC.RecLastUpdatedBy,
		CMP.CompanyCode +'-'+CMP.CompanyName as CompanyCodeName, 
		ADR.AddressID, ADR.ContactPerson, ADR.StreetAddress, ADR.EmailAddress, ADR.WebPage, ADR.ZipCode, ADR.POBox, ADR.CountryID, 
		ADR.RegionID,ADR.SubRegionID,ADR.CityID, ADR.AreaID, ADR.AddressTypeID,
		CNT.CountryCode+'-'+CountryName as CountryCodeName, 
		CT.CityCode+'-'+CT.CityName as CityCodeName,
		AR.AreaCode+'-'+AreaName as AreaCodeName, 
		RG.RegionCode+'-'+RG.RegionName as RegionCodeName,
		SRG.SubRegionCode+'-'+SRG.SubRegionName as SubRegionCodeName
FROM    
		WorkLocation WLC
		inner join Company CMP on CMP.CompanyID = WLC.CompanyID
		left join Address ADR on WLC.AddressID = ADR.AddressID
		inner join Country	CNT on CNT.CountryID = ADR.CountryID
		left join Region RG on RG.RegionID = ADR.RegionID
		left join SubRegion SRG on SRG.SubRegionID = ADR.SubRegionID		
		left join City	CT on CT.CityID = ADR.CityID
		left join Area AR on AR.AreaID = ADR.AreaID