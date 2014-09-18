
--select * from FleetPool
CREATE  VIEW [dbo].[HireGroupView]
AS
select HG.*,PHG.HireGroupCode ParentHireGroupCode,PHG.HireGroupNAme ParentHireGroupName,PHG.HireGroupCode +'-'+PHG.HireGroupName ParentHireGroupCodeName,
C.CompanyCode, C.CompanyName,C.CompanyCode+'-' +C.CompanyName CompanyCodeName
from HireGroup HG left outer join HireGroup PHG on HG.ParentHireGroupID=PHG.HireGroupID
inner join Company C on HG.CompanyID =C.CompanyID