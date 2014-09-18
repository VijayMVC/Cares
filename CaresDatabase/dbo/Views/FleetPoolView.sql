
--select * from FleetPool
CREATE VIEW [dbo].[FleetPoolView]
AS
select FP.*, 
 Reg.RegionCode+'-'+Reg.RegionName RegionCodeName,
CT.CountryID,CT.CountryCode+'-'+CT.CountryName CountryCodeName,
OP.OperationCode+ '-' +OP.OperationName OperationCodeName,
DT.DepartmentID, DT.DepartmentCode+ '-' + DT.DepartmentName DepartmentCodeName,
CP.CompanyID,CP.CompanyCode+ '-' + CP.CompanyName CompanyCodeName,
Reg.IsActive IsRegionActive,
CP.IsActive IsCompanyActive,
OP.IsActive IsOperationActive,
DT.IsActive IsDepartmentActive,
CT.IsActive IsCountryActive


from FleetPool FP
left outer join Region Reg on FP.RegionID=Reg.RegionID
left outer join Country CT on CT.CountryID=Reg.CountryID
inner join Operation OP on FP.OperationID=OP.OperationID
inner join Department DT on OP.DepartmentID=DT.DepartmentID
inner join Company CP on CP.CompanyID=DT.CompanyID