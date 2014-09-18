
CREATE view [dbo].[CompanyView]
as
SELECT     CMP.CompanyID, CMP.ParentCompany, CMP.OrgGroupID, CMP.CompanyCode, 
                      CMP.CompanyName, CMP.CompanyDescription, CMP.CompanyLegalName, CMP.CRNumber, CMP.NTN, 
                      CMP.PaidUpCapital, CMP.BusinessSegmentID, CMP.RowVersion, CMP.IsActive, CMP.IsDeleted, 
                      CMP.IsPrivate, CMP.IsReadOnly, CMP.RecCreatedDt, CMP.RecCreatedBy, CMP.RecLastUpdatedDt, 
                      CMP.RecLastUpdatedBy, 
					  ORG.OrgGroupCode + '-' + ORG.OrgGroupName as OrgGroupCodeName ,
                      Org.IsActive as OrgGroupIsActive,
					  BS.BusinessSegmentCode +'-'+BS.BusinessSegmentName as BusinessSegmentcodeName,  BS.IsActive as BusinessSegmentIsActive,
					  PCMP.CompanyCode +'-'+PCMP.CompanyName as ParentCompanyCodeName, PCMP.IsActive as ParentCompanyIsActive
FROM         Company CMP 
			left outer JOIN OrgGroup ORG ON CMP.OrgGroupID = ORG.OrgGroupID
			INNER JOIN BusinessSegment BS ON CMP.BusinessSegmentID = BS.BusinessSegmentID
			left outer JOIN Company PCMP ON CMP.ParentCompany = PCMP.CompanyID