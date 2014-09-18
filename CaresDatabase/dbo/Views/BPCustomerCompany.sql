
create view [dbo].[BPCustomerCompany]
as
select BPC.BPCompanyCode,BPC.BPCompanyName,BPM.BPMainID,BPM.BPRatingTypeID, BPMainCode,
BPR.BPRatingTypeCode+'-'+BPR.BPRatingTypeName RatingType
from BPCompany BPC
inner join BPMain BPM on BPM.BPMainID=BPC.BPMainID
inner join BPRatingType BPR on BPM.BPRatingTypeID=BPR.BPRatingTypeID