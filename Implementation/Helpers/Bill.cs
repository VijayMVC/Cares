
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Cares.Interfaces.Helpers;
using Cares.Interfaces.IServices;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Microsoft.Practices.Unity;

namespace Cares.Implementation.Helpers
{
    /// <summary>
    /// Bill
    /// </summary>
    public class Bill : IBill
    {
        
        #region Private
        
        private static void MapRaHireGroupInsuranceCharge(RaHireGroupInsurance raHireGroupInsurance,
            RaHireGroupInsurance insurance)
        {
            raHireGroupInsurance.InsuranceRate = insurance.InsuranceRate;
            raHireGroupInsurance.InsuranceCharge = insurance.InsuranceCharge;
            raHireGroupInsurance.TariffType = insurance.TariffType;
            raHireGroupInsurance.ChargedDay = insurance.ChargedDay;
            raHireGroupInsurance.ChargedHour = insurance.ChargedHour;
            raHireGroupInsurance.ChargedMinute = insurance.ChargedMinute;
        }

        private static void MapRaHireGroupCharge(RaHireGroup item, RaHireGroup chargeHireGroup)
        {
            item.TariffTypeCode = chargeHireGroup.TariffTypeCode;
            item.RentalChargeStartDate = chargeHireGroup.RentalChargeStartDate;
            item.RentalChargeEndDate = chargeHireGroup.RentalChargeEndDate;
            item.StandardRate = chargeHireGroup.StandardRate;
            item.TotalStandardCharge = chargeHireGroup.TotalStandardCharge;
            item.DropOffCharge = chargeHireGroup.DropOffCharge;
            item.AllowedMileage = chargeHireGroup.AllowedMileage;
            item.ExcessMileageRt = chargeHireGroup.ExcessMileageRt;
            item.GraceDay = chargeHireGroup.GraceDay;
            item.GraceHour = chargeHireGroup.GraceHour;
            item.GraceMinute = chargeHireGroup.GraceMinute;
            item.ChargedDay = chargeHireGroup.ChargedDay;
            item.ChargedHour = chargeHireGroup.ChargedHour;
            item.ChargedMinute = chargeHireGroup.ChargedMinute;
        }

        /// <summary>
        /// Calculate Discount
        /// </summary>
        private double CalculateDiscount(double rentalCharge, double discountPerc)
        {
            return (discountPerc * rentalCharge) / 100;
        }

        private static void MapBilling(RaMain raMain, BillingSummary billingSummary)
        {
            raMain.TotalVehicleCharge = billingSummary.TotalVehicleCharge;
            raMain.TotalAdditionalCharge = billingSummary.TotalAdditionalCharge;
            raMain.TotalExcessMileageCharge = billingSummary.TotalExcessMileageCharge;
            raMain.TotalDropOffCharge = billingSummary.TotalDropOffCharge;
            raMain.TotalInsuranceCharge = billingSummary.TotalInsuranceCharge;
            raMain.SeasonalDiscount = billingSummary.SeasonalDiscount;
            raMain.StandardDiscount = billingSummary.StandardDiscount;
            raMain.SpecialDiscount = billingSummary.SpecialDiscount;
            raMain.NetBillAfterDiscount = billingSummary.NetBillAfterDiscount;
            raMain.AmountPaid = billingSummary.AmountPaid;
            raMain.TotalDriverCharge = billingSummary.TotalDriverCharge;
            raMain.TotalServiceCharge = billingSummary.TotalServiceCharge;
            raMain.TotalOtherCharge = billingSummary.TotalOtherCharge;
            raMain.Balance = billingSummary.Balance;
        }

        private static void MapServiceItemCharge(RaServiceItem item, RaServiceItem serviceItem)
        {
            item.ServiceCharge = serviceItem.ServiceCharge;
            item.TariffType = serviceItem.TariffType;
            item.ChargedDay = serviceItem.ChargedDay;
            item.ChargedHour = serviceItem.ChargedHour;
            item.ChargedMinute = serviceItem.ChargedMinute;
            item.ServiceRate = serviceItem.ServiceRate;
        }

        /// <summary>
        /// Get Desired Hire Group
        /// </summary>
        private static RaHireGroup GetDesiredHireGroup(List<RaHireGroup> raHireGroupList)
        {
            return raHireGroupList.Find(item => (item.AllocationStatusId == (short)AllocationStatusEnum.Desired));
        }

        /// <summary>
        /// Map RaDriver Charge
        /// </summary>
        private static void MapRaDriverCharge(RaDriver driver, RaDriver raDriver)
        {
            driver.TotalCharge = raDriver.TotalCharge;
            driver.Rate = raDriver.Rate;
            driver.TariffType = raDriver.TariffType;
            driver.ChargedDay = raDriver.ChargedDay;
            driver.ChargedHour = raDriver.ChargedHour;
            driver.ChargedMinute = raDriver.ChargedMinute;
        }


        private readonly IServiceRtService serviceRtService;

        private readonly IInsuranceRateService insuranceRateService;
        private readonly IRentalCharge rentalCharge;
        private readonly IRaDriverHelper raDriverHelper;

        #endregion

        #region Public

        public BillingSummary BillingSummary { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Bill(IServiceRtService serviceRtService, IInsuranceRateService insuranceRateService, IRentalCharge rentalCharge,
            IRaDriverHelper raDriverHelper)
        {
            if (serviceRtService == null) throw new ArgumentNullException("serviceRtService");
            if (insuranceRateService == null) throw new ArgumentNullException("insuranceRateService");
            if (rentalCharge == null) throw new ArgumentNullException("rentalCharge");
            if (raDriverHelper == null) throw new ArgumentNullException("raDriverHelper");

            this.serviceRtService = serviceRtService;
            this.insuranceRateService = insuranceRateService;
            this.rentalCharge = rentalCharge;
            this.raDriverHelper = raDriverHelper;
            BillingSummary = new BillingSummary();
        }

        /// <summary>
        /// Calculate Bill
        /// </summary>
        public void CalculateBill(ref RaMain raMain, List<TariffType> oTariffTypeList)
        {
            try
            {
                List<RaHireGroup> raHireGroupList = raMain.RaHireGroups.ToList();
                List<RaServiceItem> raServiceItems = raMain.RaServiceItems.ToList();
                List<RaDriver> raDrivers = raMain.RaDrivers.ToList();
                List<RaPayment> raPayments = raMain.RaPayments.ToList();
                List<RaAdditionalCharge> raAdditionalCharges = raMain.RaAdditionalCharges.ToList();
                
                CalculateHireGroupCharges(raMain.RecCreatedDt, raMain.StartDtTime, raMain.EndDtTime, raMain.OperationId, ref raHireGroupList, 
                    oTariffTypeList);
                CalculateRACharges(ref raServiceItems, ref raDrivers, raMain.RecCreatedDt, raMain.OperationId, oTariffTypeList);
                BillingSummary billingSummary = GenerateBillingSummary(raHireGroupList, raServiceItems, raDrivers, raPayments, raAdditionalCharges, raMain.SpecialDiscountPerc != null ? 
                    (float)raMain.SpecialDiscountPerc : 0, (float)raMain.SpecialDiscount, raMain.IsSpecialDiscountPerc);

                MapBilling(raMain, billingSummary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Calculate HireGroup Charges
        /// </summary>
        public void CalculateHireGroupCharges(DateTime RACreatedDate, DateTime StartDate, DateTime EndDate, Int64 OperationID, ref List<RaHireGroup> RAHireGroupList, List<TariffType> oTariffTypeList)
        {
            Int32 OutOdometer = 0, InOdometer = 0;
            Int64 DesiredHireGroupID = 0;
            RaHireGroup oRAHGDesired = GetDesiredHireGroup(RAHireGroupList);
            if (oRAHGDesired != null)
                DesiredHireGroupID = oRAHGDesired.HireGroupDetailId;
            foreach (RaHireGroup item in RAHireGroupList)
            {
                if (item.IsDeleted != true)
                {
                    VehicleMovement vehicleMovementOut = item.VehicleMovements.FirstOrDefault(vm => vm.Status == Convert.ToBoolean(VehicleMovementEnum.Out));
                    VehicleMovement vehicleMovementIn = item.VehicleMovements.FirstOrDefault(vm => vm.Status == Convert.ToBoolean(VehicleMovementEnum.In));
                    if (vehicleMovementOut != null && vehicleMovementOut.Odometer != null)
                        OutOdometer = Convert.ToInt32(vehicleMovementOut.Odometer);
                    if (vehicleMovementIn != null && vehicleMovementIn.Odometer != null)
                        InOdometer = Convert.ToInt32(vehicleMovementIn.Odometer);
                    if (vehicleMovementIn != null && vehicleMovementOut != null)
                    {
                        RaHireGroup chargeHireGroup = rentalCharge.CalculateCharge(RACreatedDate, StartDate, EndDate,
                                Convert.ToDateTime(vehicleMovementOut.DtTime),
                                Convert.ToDateTime(vehicleMovementIn.DtTime), OperationID,
                                (item.AllocationStatusId == (short)AllocationStatusEnum.Upgraded ?
                                DesiredHireGroupID : item.HireGroupDetailId), OutOdometer, InOdometer, oTariffTypeList);

                        MapRaHireGroupCharge(item, chargeHireGroup);
                    }

                    List<RaHireGroupInsurance> RAHireGroupInsList = item.RaHireGroupInsurances.ToList();
                    foreach (RaHireGroupInsurance raHireGroupInsurance in RAHireGroupInsList)
                    {
                        if (raHireGroupInsurance.IsDeleted)
                            continue;


                        RaHireGroupInsurance insurance = insuranceRateService.CalculateCharge(RACreatedDate, Convert.ToDateTime(raHireGroupInsurance.StartDtTime),
                               Convert.ToDateTime(raHireGroupInsurance.EndDtTime), OperationID, item.HireGroupDetailId,
                               raHireGroupInsurance.InsuranceTypeId, oTariffTypeList);

                        MapRaHireGroupInsuranceCharge(raHireGroupInsurance, insurance);
                    }
                    //Discount Scheme change
                    RaHireGroupDiscount standardDiscount = item.RaHireGroupDiscounts.
                        FirstOrDefault(discount => discount.DiscountKey == (short)DiscountTypeEnum.StandardDiscount);
                    RaHireGroupDiscount seasonalDiscount = item.RaHireGroupDiscounts.
                        FirstOrDefault(discount => discount.DiscountKey == (short)DiscountTypeEnum.SeasonalDiscount);

                    if (seasonalDiscount != null)
                    {
                        seasonalDiscount.DiscountAmount = CalculateDiscount(item.TotalStandardCharge, seasonalDiscount.DiscountPerc);
                    }
                    if (standardDiscount != null)
                    {
                        standardDiscount.DiscountAmount = CalculateDiscount(item.TotalStandardCharge, standardDiscount.DiscountPerc);
                    }

                }

            }
        }

        /// <summary>
        /// Calculae RaCharges
        /// </summary>
        public void CalculateRACharges(ref List<RaServiceItem> RAServiceItemList, ref List<RaDriver> RADriverList, DateTime RACreatedDate, Int64 OperationID, 
            List<TariffType> oTariffTypeList)
        {
            foreach (RaServiceItem item in RAServiceItemList)
            {
                if (item.IsDeleted != true)
                {
                    RaServiceItem serviceItem = serviceRtService.
                        CalculateCharge(RACreatedDate, item.StartDtTime, item.EndDtTime, item.ServiceItemId, item.Quantity, OperationID, oTariffTypeList);
                    
                    MapServiceItemCharge(item, serviceItem);
                }
            }
            foreach (RaDriver Driver in RADriverList)
            {
                if (Driver.IsDeleted != true)
                {
                    RaDriver raDriver = raDriverHelper.
                        CalculateCharge(RACreatedDate, Driver.StartDtTime, Driver.EndDtTime, Driver.DesigGradeId ?? 0, Driver.IsChauffer, OperationID, 
                        oTariffTypeList);

                    MapRaDriverCharge(Driver, raDriver);
                }
            }
        }
        
        /// <summary>
        /// Generate Billing Summary
        /// </summary>
        public BillingSummary GenerateBillingSummary(List<RaHireGroup> RAHireGroupList, List<RaServiceItem> RAServiceItemList, List<RaDriver> RADriverList, List<RaPayment> RAPayment, List<RaAdditionalCharge> RAAdditionalCharge, float SpecialDiscountPerc, float SpecialDiscountPercAmount, bool IsSpecialDiscountPerc)
        {
            BillingSummary.Reset();
            foreach (RaHireGroup hg in RAHireGroupList)
            {
                BillingSummary.TotalVehicleCharge += hg.TotalStandardCharge;
                BillingSummary.TotalExcessMileageCharge += hg.TotalExcMileageCharge;
                //update discount fields here
                BillingSummary.TotalDropOffCharge += hg.DropOffCharge;
                List<RaHireGroupInsurance> hgInsList = hg.RaHireGroupInsurances.ToList();
                for (int i = 0; i < hgInsList.Count; i++)
                {
                    if (hgInsList[i].IsDeleted == false)
                        BillingSummary.TotalInsuranceCharge += hgInsList[i].InsuranceCharge;
                }
                if (hg.RaHireGroupDiscounts.Count > 0)
                {
                    RaHireGroupDiscount seasonalDiscount = hg.RaHireGroupDiscounts.
                        FirstOrDefault(discount => discount.DiscountKey == (short)DiscountTypeEnum.SeasonalDiscount);
                    RaHireGroupDiscount standardDiscount = hg.RaHireGroupDiscounts.
                        FirstOrDefault(discount => discount.DiscountKey == (short)DiscountTypeEnum.StandardDiscount);
                    if (seasonalDiscount != null && seasonalDiscount.IsDeleted != true)
                        BillingSummary.SeasonalDiscount += seasonalDiscount.DiscountAmount;
                    if (standardDiscount != null && standardDiscount.IsDeleted != true)
                        BillingSummary.StandardDiscount += standardDiscount.DiscountAmount;
                }
            }
            if (IsSpecialDiscountPerc)
            {
                BillingSummary.SpecialDiscount = (SpecialDiscountPerc * BillingSummary.TotalVehicleCharge / 100);
            }
            else
            {
                BillingSummary.SpecialDiscount = SpecialDiscountPercAmount;
            }
            BillingSummary.NetBillAfterDiscount = BillingSummary.TotalVehicleCharge + BillingSummary.SeasonalDiscount + BillingSummary.SpecialDiscount - BillingSummary.VoucherDiscount + BillingSummary.StandardDiscount;

            foreach (RaDriver driver in RADriverList)
            {
                if (driver.IsDeleted != true)
                    BillingSummary.TotalDriverCharge += driver.TotalCharge;
            }
            foreach (RaServiceItem service in RAServiceItemList)
            {
                if (service.IsDeleted == false)
                    BillingSummary.TotalServiceCharge += service.ServiceCharge;
            }
            foreach (RaPayment Payment in RAPayment)
            {
                if (Payment.IsDeleted == false)
                    BillingSummary.AmountPaid += Payment.RaPaymentAmount;
            }
            foreach (RaAdditionalCharge AdditionalCharge in RAAdditionalCharge)
            {
                if (AdditionalCharge.IsDeleted == false)
                    BillingSummary.TotalAdditionalCharge += AdditionalCharge.Quantity * AdditionalCharge.AdditionalChargeRate;
            }


            BillingSummary.TotalOtherCharge = BillingSummary.TotalDropOffCharge + BillingSummary.TotalExcessMileageCharge + BillingSummary.TotalServiceCharge +
                BillingSummary.TotalInsuranceCharge + BillingSummary.TotalDriverCharge + BillingSummary.TotalAdditionalCharge;

            //this._Summary.AmountPaid = 0; // to be calculated by invoicing;
            BillingSummary.Balance = BillingSummary.NetBillAfterDiscount + BillingSummary.TotalOtherCharge - BillingSummary.AmountPaid;

            return BillingSummary;
        }

        #endregion
        
    }

}
