create view [dbo].[rptRAVehicleCheckListView]
as
--Created: AR, Dated: Mar-04-2010
SELECT 
RM.RAMainID , 
RHG.RAHireGroupID,RVC.RAVehicleChecklistID, RHG.VehicleID, VH.PlateNumber,
VC.VehicleChecklistCode, VC.VehicleChecklistName

      
FROM 
RAMain RM
inner join RAHireGroup RHG on RM.RAMainID = RHG.RAMainID
inner join RAVehicleChecklist RVC on RVC.RAHireGroupID = RHG.RAHireGroupID and RVC.Status=1
inner join Vehicle VH on VH.VehicleID = RHG.VehicleID
inner join VehicleChecklist VC on VC.VehicleChecklistID = RVC.VehicleChecklistID