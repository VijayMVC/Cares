
--select * from rptActionList
CREATE VIEW [dbo].[rptActionList]
AS
--declare @StDateTime datetime 
--set @StDateTime ='01/01/2010 11:11'

select 
RM.RAMainID as RANumber
,RHG.VehicleId
--,V.PlateNumber, RAS.RAStatusName
,RM.AmountPaid as Paid, RM.Balance as Balance
,RM.StartDtTime, RM.EndDtTime, RM.RAStatusID --to fetch columsn from 
,RAS.RAStatusCode, RAS.RAStatusName -- to fetch codes from RAStatus table
---
--to do Nationality below
, BPM.BPMainID,BPI.LastName +', '+BPI.Firstname as CustomerName,CellPhone.PhoneNumber as MobilePhone,PhoneLand.PhoneNumber as TelePhone
,C.CountryCode as Nationality
--hiregrup info below
, HG.HireGroupID,HG.HireGroupName,HG.HireGroupCode
--"FleetPool" 
, FP.FleetPoolName as FleetPool         --,FP.FleetPoolId, FP.FleetPoolCode 
---
, V.PlateNumber             --,V.VehicleId 
, VS.VehicleStatusName
, VMO.Odometer as Mileage
, OP.LocationCode as CurrentLocation
, VMO.DtTime as OutDate
, VMI.DtTime as InDate
, VM.VehicleMakeName as VehicleMake        --VM.VehicleMakeCode,
, VMD.VehicleModelName as VehicleModel       --VMD.VehicleModelCode, 
, V.ModelYear as ModelYear
, VC.VehicleCategoryName as VehicleCategory      --VC.VehicleCategoryCode,
--**************** Column ADDED
,RHG.RentalChargeStartDate,RHG.RentalChargeEndDate
--,* 
from RAMain as RM
inner join RAStatus as RAS on RAS.RAStatusId=RM.RAStatusId 
        and ( RM.RAStatusId=1 /*open*/ 
                 --or RM.RAStatusID=2 /*close*/
                 or RM.RAStatusID=3 /*Payment Pending*/ 
                 or RM.RAStatusID=4 /*System Generated Booking*/ 
                 or RM.RAStatusID=5 /*Online Booking*/ 
                 or RM.RAStatusID=6 /*Reservation*/
                )
------customer info starts ------------------
inner join BPMain as BPM on BPM.BPMainID = RM.BPMainID 
left  join Phone as CellPhone on CellPhone.BPMainId=BPM.BPMainId and CellPhone.PhoneTypeId=1  
left  join Phone as PhoneLand on PhoneLand.BPMainId=BPM.BPMainId and PhoneLand.PhoneTypeId=2
left  join BPIndividual as BPI on BPI.BPMainID = BPM.BPMainID AND BPM.IsIndividual = 1 
----my new changes starts
left join Country as C on C.CountryId= BPI.PassportCountryId
---my new changes ends

-------customer infor ends ------------------
-------HireGroup and FleetInfo starts -------


---***************Added just to get always the maximum DateTime HireGroup********
inner join (
select RAMainID,max([RentalChargeStartDate]) RentalChargeStartDate
from RAHireGroup  
group by RAMainID
)RHGMax on RHGMax.RAMainId=RM.RAMainId 
--END-***************Added just to get always the maximum DateTime HireGroup********

inner join RAHireGroup as RHG on RHG.RAMainId=RM.RAMainId and RHG.RentalChargeStartDate=RHGMax.RentalChargeStartDate
--inner join HireGroupDetail as HGD on HGD.HireGroupDetailId = RHG.HireGroupDetailId
left join HireGroupDetail as HGD on HGD.HireGroupDetailId = RHG.HireGroupDetailId
inner join HireGroup as HG on HG.HireGroupId=HGD.HireGroupId
-------HireGroup and FleetInfo ends ---------
-------Vehicle Data starts ------------------
left join Vehicle as V on V.VehicleID = RHG.VehicleID 

----my new changes starts
left join VehicleStatus as VS on VS.VehicleStatusId = V.VehicleStatusId
left join VehicleMovement as VMO on RHG.RAHireGroupID = VMO.RAHireGroupID and VMO.Status = 1  --out movement
left join VehicleMovement as VMI on RHG.RAHireGroupID = VMI.RAHireGroupID and VMI.Status = 0  --in movement
left join OperationsWorkplace as OP on OP.OperationsWorkplaceid=VMO.OperationsWorkplaceid

---my new changes ends


left join FleetPool as FP on FP.FleetPoolId=V.FleetPoolId
left join VehicleMake as VM on VM.VehicleMakeID = V.VehicleMakeID 
left join VehicleModel as VMD on VMD.VehicleModelID = V.VehicleModelID 
left join VehicleCategory as VC on VC.VehicleCategoryID = V.VehicleCategoryID 
-------Vehicle Data ends --------------------
--where RM.StartDtTime=@StDateTime
--order by RM.StartDtTime desc   --invalid in views