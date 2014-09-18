
CREATE view [dbo].[rptRACustomerView]
as
-- Creaed: AR, Dated: Dec-18-09
-- Modified AR, Dated: Mar-03-10
select 
	RM.RAMainID, RM.BPMainID
	,isnull(isnull(isnull(isnull(isnull(isnull
	(ADC.AddressID,ADB.AddressID),ADA.AddressID),ADDD.AddressID),ADE.AddressID),ADF.AddressID),ADG.AddressID) as AddressID
	,isnull(isnull(isnull(isnull(isnull(isnull
	(ADC.StreetAddress,ADB.StreetAddress),ADA.StreetAddress),ADDD.StreetAddress),ADE.StreetAddress),ADF.StreetAddress),ADG.StreetAddress) as StreetAddress
	,isnull(PH.PhoneTypeID,PHC.PhoneTypeID) as PhoneTypeID
	,isnull(PH.PhoneNumber,PHC.PhoneNumber) as PhoneNumber
	,PT.PhoneTypeCode,PT.PhoneTypeName
	,C.CityID, C.CityCode, C.CityName, CNT.CountryID, CNT.CountryCode, CNT.CountryName
	,R.RegionID, R.RegionCode, R.RegionName,BPM.IsIndividual
	,case when BPC.BPMainID is null then BPI.FirstName else BPC.BPCompanyCode end as BPIndCompCode
	,case when BPC.BPMainID is null then BPI.LastName else BPC.BPCompanyName end as BPIndCompName
	,BPI.LiscenseNumber, BPI.LiscenseExpiryDate, BPI.NIDNumber, BPI.NICExpDt
	,BPI.PassportNumber,BPI.PassportExpDt, BPI.DateOfBirth
	,BPMainCode,BPMainName
	,ATC.AddressTypeName
	,ATC.AddressTypeID
from 
RAMain RM
inner join BPMain BPM on BPM.BPMainID = RM.BPMainID
left join Address ADA on ADA.BPMainID = BPM.BPMainID and ADA.AddressTypeID = 1
left join Address ADB on ADB.BPMainID = BPM.BPMainID and ADB.AddressTypeID = 2
left join Address ADC on ADC.BPMainID = BPM.BPMainID and ADC.AddressTypeID = 3
left join Address ADDD on ADDD.BPMainID = BPM.BPMainID and ADDD.AddressTypeID = 4
left join Address ADE on ADE.BPMainID = BPM.BPMainID and ADE.AddressTypeID = 5
left join Address ADF on ADF.BPMainID = BPM.BPMainID and ADF.AddressTypeID = 6
left join Address ADG on ADG.BPMainID = BPM.BPMainID and ADG.AddressTypeID = 7
left join AddressType ATC 
on ATC.AddressTypeID = isnull(isnull(isnull(isnull(isnull(isnull
(ADA.AddressTypeID,ADB.AddressTypeID),ADC.AddressTypeID),ADDD.AddressTypeID),ADE.AddressTypeID),ADF.AddressTypeID),ADG.AddressTypeID)
left join City C 
on C.CityID = isnull(isnull(isnull(isnull(isnull(isnull
(ADA.CityID,ADB.CityID),ADC.CityID),ADDD.CityID),ADE.CityID),ADF.CityID),ADG.CityID)
left join Country CNT 
on CNT.CountryID = isnull(isnull(isnull(isnull(isnull(isnull
(ADA.CountryID,ADB.CountryID),ADC.CountryID),ADDD.CountryID),ADE.CountryID),ADF.CountryID),ADG.CountryID)
left join Region R 
on R.RegionID = isnull(isnull(isnull(isnull(isnull(isnull
(ADA.RegionID,ADB.RegionID),ADC.RegionID),ADdD.RegionID),ADE.RegionID),ADF.RegionID),ADG.RegionID)
left join Phone PH on PH.BPMainID = BPM.BPMainID and PH.IsDefault = 1
left join Phone PHC on PHC.BPMainID = BPM.BPMainID 
left join PhoneType PT 
on PT.PhoneTypeID = isnull(PH.PhoneTypeID,PHC.PhoneTypeID)
left join BPIndividual BPI on BPI.BPMainID = BPM.BPMainID and BPM.IsIndividual = 1
left join BPCompany BPC on BPC.BPMainID = BPM.BPMainID and BPM.IsIndividual = 0