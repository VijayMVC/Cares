
CREATE view [dbo].[BPCustomerIndividualView]
as
select BPI.FirstName,BPI.LastName,BPI.LiscenseNumber,BPI.LiscenseExpiryDate, BPMainCode,BPMainName, BPM.PaymentTermID,
BPM.BPMainID,BPM.NonSystemGuarantor, BPI.DateOfBirth, BPI.NIDNumber, BPI.NICExpDt, BPI.PassportNumber, BPI.PassportExpDt,
BRT.BPRatingTypeID,BRT.BPRatingTypeCode+'-'+BRT.BPRatingTypeName BPRatingTypeCodeName, BPM.BPEmailAddress, BPM.BPIsValid

from BPIndividual BPI
inner join BPMain BPM on BPM.BPMainID=BPI.BPMainID and BPM.IsIndividual=1 --and BPM.BPIsValid = 1
left outer join BPRatingType BRT on BPM.BPRatingTypeID=BRT.BPRatingTypeID