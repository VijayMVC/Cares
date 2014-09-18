
CREATE view [dbo].[BPCustomerCompanyView]
as
select BPC.BPCompanyCode,BPC.BPCompanyName,BPM.BPMainID,BPMainCode, BPM.PaymentTermID,
BRT.BPRatingTypeID,BRT.BPRatingTypeCode+'-'+BRT.BPRatingTypeName BPRatingTypeCodeName, BPM.BPEmailAddress, BPM.BPIsvalid
--,BPM.BPRatingTypeID, 
--BPR.BPRatingTypeCode+'-'+BPR.BPRatingTypeName RatingType
from BPCompany BPC
inner join BPMain BPM on BPM.BPMainID=BPC.BPMainID and BPM.IsIndividual=0
left outer join BPRatingType BRT on BPM.BPRatingTypeID=BRT.BPRatingTypeID