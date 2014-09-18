CREATE view [dbo].[rptRAHireGroupView]
as
-- Create: AR, Dated: Dec-16-2009
-- Modified: AR, Dated: Mar-03-2010
select	 RM.RAMainID, RM.OperationID, RM.PaymentTermID, RM.StartDtTime
		,RM.EndDtTime,RM.RAStatusID,RM.CloseLocation,RM.OpenLocation
		,RM.TotalVehicleCharge,RM.TotalInsuranceCharge,RM.SeasonalDiscount,RM.VoucherDiscount,RM.SpecialDiscount,RM.NetBillAfterDiscount
		,RM.TotalExcessMileageCharge,RM.TotalServiceCharge,RM.TotalDriverCharge,RM.TotalAdditionalCharge,RM.TotalOtherCharge,RM.AmountPaid,RM.Balance
		,RM.RentersName, RM.RentersLicenseNumber
		,O.OperationCode, O.OperationName
		,PT.PaymentTermCode, PT.PaymentTermName
		,RS.RAStatusCode, RS.RAStatusName
		,owpO.LocationCode as RAOpenLocationCode,owpC.LocationCode as RACloseLocationCode
		,RHG.VehicleID,RHG.AllocationStatusID, RHG.TariffTypeCode, RHG.AllowedMileage
		,RHG.StandardRate,RHG.TotalStandardCharge,TotalExcMileageCharge, RHG.ChargedDay,RHG.ChargedHour,RHG.ChargedMinute
		,RHG.GraceDay,RHG.GraceHour,RHG.GraceMinute
		,VMOL.LocationCode as VehicleOutLocationCode, VMO.Odometer as VehicleOutOdometer, VMO.DtTime as VehicleOutDateTime, VMO.FuelLevel as VehicleOutFuel
		,VMIL.LocationCode as VehicleInLocationCode, VMI.Odometer as VehicleInOdometer, VMI.DtTime as VehicleInDateTime, VMI.FuelLevel as VehicleInFuel 
		,isnull(VMI.VehicleStatusID,VMO.VehicleStatusID) as VehicleStatusID 
		,VH.VehicleCode, VH.VehicleName, VH.Modelyear,VH.PlateNumber,VH.Color
		,VM.VehicleMakeCode, VM.VehicleMakeName
		,VMD.VehicleModelCode, VMD.VehicleModelName
		,VC.VehicleCategoryCode, VC.VehicleCategoryName
		,VS.VehicleStatusCode, VS.VehicleStatusName
		,ALS.AllocationStatusCode, ALS.AllocationStatusName
		,RHD.DiscountAmount,RHD.DiscountKey, RHD.DiscountPerc, 0 as ChargeType
		
from 
RAHireGroup RHG
inner join RAMain RM on RHG.RAMainID = RM.RAMainID
inner join Operation O on o.OperationID = RM.OperationID
inner join PaymentTerm PT on PT.PaymentTermID = RM.PaymentTermID
inner join RAStatus RS on RS.RAStatusID = Rm.RAStatusID
inner join OperationsWorkplace owpO on owpO.OperationsWorkplaceID = RM.OpenLocation
inner join OperationsWorkplace owpC on owpC.OperationsWorkplaceID = RM.CloseLocation
inner join Vehicle VH on RHG.VehicleID = VH.VehicleID
inner join VehicleMovement VMO on (RHG.RAHireGroupID = VMO.RAHireGroupID and VMO.Status = 1)
inner join VehicleMovement VMI on (RHG.RAHireGroupID = VMI.RAHireGroupID and VMI.Status = 0)
Inner join OperationsWorkplace VMOL on VMO.OperationsWorkplaceID = VMOL.OperationsWorkplaceID
Inner join OperationsWorkplace VMIL on VMO.OperationsWorkplaceID = VMIL.OperationsWorkplaceID
inner join VehicleMake VM on VM.VehicleMakeID = VH.VehicleMakeID
inner join VehicleModel VMD on VMD.VehicleModelID = VH.VehicleModelID
inner join VehicleCategory VC on VC.VehicleCategoryID = VH.VehicleCategoryID
inner join VehicleStatus VS on VS.VehicleStatusID = isnull(VMI.VehicleStatusID,VMO.VehicleStatusID)
left outer join RAHireGroupDiscount RHD on RHD.RAHireGroupID = RHG.RAHireGroupID
inner join AllocationStatus ALS on ALS.AllocationStatusID = RHG.AllocationStatusID