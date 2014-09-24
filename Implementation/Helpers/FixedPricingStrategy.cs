using System;
using Cares.Models.DomainModels;

namespace Cares.Implementation.Helpers
{
    class FixedPricingStrategy : PricingStrategy
    {
        public FixedPricingStrategy()
            : base()
        {

        }
        public FixedPricingStrategy(TariffType tType)
            : base(tType)
        {
        }

        public override RentalCharge CalculateRentalCharge(DateTime StartDate, DateTime EndDate, StandardRate tSTrate)
        {
            RentalCharge oRentalCharge = null;
            //calculate total rental duration as a time span object
            TimeSpan dtSpan = EndDate - StartDate;
            TimeSpan ChargeSpan;
            TimeSpan GraceSpan;
            //convert rental duration to minutes for standardization
            float RentalDurationInMinutes = GetDurationInMinutes(dtSpan, Convert.ToInt32(TariffType.MeasurementUnitId));
            //convert tariff type FromDuration to Minute for standardization
            float TariffDurationFrom = GetDurationInMinutes(TariffType.DurationFrom, Convert.ToInt32(TariffType.MeasurementUnitId));
            //convert tariff type ToDuration to Minute for standardization
            float TariffDurationTo = GetDurationInMinutes(TariffType.DurationTo, Convert.ToInt32(TariffType.MeasurementUnitId));
            //convert tariff type GracePeriod to Minute for standardization
            float TariffGracePeriod = GetDurationInMinutes((float)TariffType.GracePeriod, Convert.ToInt32(TariffType.MeasurementUnitId));
            //set rental charge object common parameters
            oRentalCharge = new RentalCharge();
            oRentalCharge.RentalChargeStartDate = StartDate;
            oRentalCharge.RentalChargeEndDate = EndDate;
            oRentalCharge.TariffTypeCode = this.TariffType.TariffTypeCode;
            //condition 1: if rental duration lies between From and To
            if (RentalDurationInMinutes >= TariffDurationFrom && RentalDurationInMinutes <= TariffDurationTo)
            {
                oRentalCharge.StRate = (float)tSTrate.StandardRt;
                oRentalCharge.TotalStandardCharge = (float)tSTrate.StandardRt;
                //excess milage charge for edit case
                oRentalCharge.ExcessMileageRt = (float)tSTrate.ExcessMileageChrg;
                oRentalCharge.TotalExcMileageCharge = 0;
                oRentalCharge.AllowedMileage = tSTrate.AllowedMileage;
                oRentalCharge.GraceDay = 0;
                oRentalCharge.GraceHour = 0;
                oRentalCharge.GraceMinute = 0;
                oRentalCharge.ChargedDay = dtSpan.Days;
                oRentalCharge.ChargedHour = dtSpan.Hours;
                oRentalCharge.ChargedMinute = dtSpan.Minutes;

            }
            else
            {
                Int16 Quotient = Int16.Parse(Math.Floor(Convert.ToDouble(RentalDurationInMinutes / TariffDurationTo)).ToString());

                //check if grace is applicable or not
                float y = RentalDurationInMinutes % TariffDurationTo;
                // since RentalDurationInMinutes % TariffDurationTo gives us how many units the rental duration is greater than TariffDurationTo,
                // the y part gives us the remainder of those units.if y times this.TariffType.DurationTo is less than and equal to this.TariffType.Graceperiod , then grace is applicable

                //if (y * this.TariffType.DurationTo <= this.TariffType.GracePeriod)
                if (y <= this.TariffType.GracePeriod)
                    GraceSpan = GetGrace(RentalDurationInMinutes, TariffDurationTo, Quotient);
                else
                {
                    GraceSpan = new TimeSpan(0, 0, 0, 0);
                }
                ChargeSpan = new TimeSpan(dtSpan.Days - GraceSpan.Days, dtSpan.Hours - GraceSpan.Hours, dtSpan.Minutes - GraceSpan.Minutes, 0);
                float ChargeDuration = GetDurationInMinutes(ChargeSpan, Convert.ToInt32(this.TariffType.MeasurementUnitId));
                oRentalCharge.TotalStandardCharge = (float)Math.Round(((float)Math.Ceiling(Convert.ToDouble((ChargeDuration / TariffDurationTo)))) * tSTrate.StandardRt, base.DecimalRounding, MidpointRounding.AwayFromZero);
                oRentalCharge.StRate = (float)tSTrate.StandardRt;
                //excess milage charge for edit case
                //drop off charge 
                oRentalCharge.DropOffCharge = 0;
                oRentalCharge.ExcessMileageRt = (float)tSTrate.ExcessMileageChrg;
                oRentalCharge.TotalExcMileageCharge = 0;
                oRentalCharge.GraceDay = GraceSpan.Days;
                oRentalCharge.GraceHour = GraceSpan.Hours;
                oRentalCharge.GraceMinute = GraceSpan.Minutes;
                oRentalCharge.ChargedDay = ChargeSpan.Days;
                oRentalCharge.ChargedHour = ChargeSpan.Hours;
                oRentalCharge.ChargedMinute = ChargeSpan.Minutes;
                oRentalCharge.AllowedMileage = tSTrate.AllowedMileage;

            }
            return oRentalCharge;
        }

        public override RaHireGroupInsurance CalculateInsuranceCharge(DateTime StartDate, DateTime EndDate, InsuranceRt InsRate)
        {
            RaHireGroupInsurance oInsuranceCharge = null;
            //calculate total rental duration as a time span object
            TimeSpan dtSpan = EndDate - StartDate;

            //convert rental duration to minutes for standardization
            float InsDurationInMinutes = GetDurationInMinutes(dtSpan, Convert.ToInt32(TariffType.MeasurementUnitId));
            //convert tariff type FromDuration to Minute for standardization
            float TariffDurationFrom = GetDurationInMinutes(TariffType.DurationFrom, Convert.ToInt32(TariffType.MeasurementUnitId));
            //convert tariff type ToDuration to Minute for standardization
            float TariffDurationTo = GetDurationInMinutes(TariffType.DurationTo, Convert.ToInt32(TariffType.MeasurementUnitId));
            //convert tariff type GracePeriod to Minute for standardization
            float TariffGracePeriod = GetDurationInMinutes((float)TariffType.GracePeriod, Convert.ToInt32(TariffType.MeasurementUnitId));
            //set rental charge object common parameters
            oInsuranceCharge = new RaHireGroupInsurance();
            oInsuranceCharge.TariffType = this.TariffType.TariffTypeCode;
            if (InsDurationInMinutes >= TariffDurationFrom && InsDurationInMinutes <= TariffDurationTo)
            {
                oInsuranceCharge.InsuranceRate = InsRate.InsuranceRate;
                oInsuranceCharge.InsuranceCharge = InsRate.InsuranceRate;
                oInsuranceCharge.ChargedDay = dtSpan.Days;
                oInsuranceCharge.ChargedHour = dtSpan.Hours;
                oInsuranceCharge.ChargedMinute = dtSpan.Minutes;

            }
            else
            {
                float ChargeDuration = GetDurationInMinutes(dtSpan, Convert.ToInt32(this.TariffType.MeasurementUnitId));
                oInsuranceCharge.InsuranceCharge = (float)Math.Round(((float)Math.Ceiling(Convert.ToDouble((ChargeDuration / TariffDurationTo)))) * InsRate.InsuranceRate, base.DecimalRounding, MidpointRounding.AwayFromZero);
                oInsuranceCharge.InsuranceRate = InsRate.InsuranceRate;
                //excess milage charge for edit case
                oInsuranceCharge.ChargedDay = dtSpan.Days;
                oInsuranceCharge.ChargedHour = dtSpan.Hours;
                oInsuranceCharge.ChargedMinute = dtSpan.Minutes;
            }
            return oInsuranceCharge;
        }

        public override RaServiceItem CalculateRAServiceItemCharge(DateTime StartDate, DateTime EndDate, Int32 ItemQuantity, ServiceRt ServiceItemRate)
        {
            RaServiceItem oRASICharge = null;
            //calculate total rental duration as a time span object
            TimeSpan dtSpan = EndDate - StartDate;

            //convert rental duration to minutes for standardization
            float SIDurationInMinutes = GetDurationInMinutes(dtSpan, Convert.ToInt32(TariffType.MeasurementUnitId));
            //convert tariff type FromDuration to Minute for standardization
            float TariffDurationFrom = GetDurationInMinutes(TariffType.DurationFrom, Convert.ToInt32(TariffType.MeasurementUnitId));
            //convert tariff type ToDuration to Minute for standardization
            float TariffDurationTo = GetDurationInMinutes(TariffType.DurationTo, Convert.ToInt32(TariffType.MeasurementUnitId));
            //convert tariff type GracePeriod to Minute for standardization
            float TariffGracePeriod = GetDurationInMinutes((float)TariffType.GracePeriod, Convert.ToInt32(TariffType.MeasurementUnitId));
            //set rental charge object common parameters
            oRASICharge = new RaServiceItem();
            oRASICharge.TariffType = this.TariffType.TariffTypeCode;
            if (SIDurationInMinutes >= TariffDurationFrom && SIDurationInMinutes <= TariffDurationTo)
            {
                oRASICharge.ServiceRate = ServiceItemRate.ServiceRate;
                oRASICharge.ServiceCharge = ServiceItemRate.ServiceRate * ItemQuantity;
                oRASICharge.ChargedDay = dtSpan.Days;
                oRASICharge.ChargedHour = dtSpan.Hours;
                oRASICharge.ChargedMinute = dtSpan.Minutes;

            }
            else
            {
                float ChargeDuration = GetDurationInMinutes(dtSpan, Convert.ToInt32(TariffType.MeasurementUnitId));
                oRASICharge.ServiceCharge = (float)Math.Round(((float)Math.Ceiling(Convert.ToDouble((ChargeDuration / TariffDurationTo)))) * ServiceItemRate.ServiceRate * ItemQuantity, base.DecimalRounding, MidpointRounding.AwayFromZero);
                oRASICharge.ServiceRate = ServiceItemRate.ServiceRate;
                //excess milage charge for edit case
                oRASICharge.ChargedDay = dtSpan.Days;
                oRASICharge.ChargedHour = dtSpan.Hours;
                oRASICharge.ChargedMinute = dtSpan.Minutes;
            }
            return oRASICharge;
        }

        public override RaDriver CalculateAddDriverCharge(DateTime StartDate, DateTime EndDate, AdditionalDriverCharge AddDrvRate)
        {
            RaDriver oRADriver = null;
            //calculate total rental duration as a time span object
            TimeSpan dtSpan = EndDate - StartDate;

            //convert rental duration to minutes for standardization
            float AddDrvDurationInMinutes = GetDurationInMinutes(dtSpan, Convert.ToInt32(TariffType.MeasurementUnitId));
            //convert tariff type FromDuration to Minute for standardization
            float TariffDurationFrom = GetDurationInMinutes(TariffType.DurationFrom, Convert.ToInt32(TariffType.MeasurementUnitId));
            //convert tariff type ToDuration to Minute for standardization
            float TariffDurationTo = GetDurationInMinutes(TariffType.DurationTo, Convert.ToInt32(TariffType.MeasurementUnitId));
            //convert tariff type GracePeriod to Minute for standardization
            float TariffGracePeriod = GetDurationInMinutes((float)TariffType.GracePeriod, Convert.ToInt32(TariffType.MeasurementUnitId));
            //set rental charge object common parameters
            oRADriver = new RaDriver();
            oRADriver.TariffType = this.TariffType.TariffTypeCode;
            if (AddDrvDurationInMinutes >= TariffDurationFrom && AddDrvDurationInMinutes <= TariffDurationTo)
            {
                oRADriver.Rate = AddDrvRate.AdditionalDriverChargeRate;
                oRADriver.TotalCharge = AddDrvRate.AdditionalDriverChargeRate;
                oRADriver.ChargedDay = dtSpan.Days;
                oRADriver.ChargedHour = dtSpan.Hours;
                oRADriver.ChargedMinute = dtSpan.Minutes;

            }
            else
            {
                float ChargeDuration = GetDurationInMinutes(dtSpan, Convert.ToInt32(TariffType.MeasurementUnitId));
                oRADriver.TotalCharge = (float)Math.Round(((float)Math.Ceiling(Convert.ToDouble((ChargeDuration / TariffDurationTo)))) * AddDrvRate.AdditionalDriverChargeRate, base.DecimalRounding, MidpointRounding.AwayFromZero);
                oRADriver.Rate = AddDrvRate.AdditionalDriverChargeRate;
                //excess milage charge for edit case
                oRADriver.ChargedDay = dtSpan.Days;
                oRADriver.ChargedHour = dtSpan.Hours;
                oRADriver.ChargedMinute = dtSpan.Minutes;
            }
            return oRADriver;
        }
        public override RaDriver CalculateChaufferCharge(DateTime StartDate, DateTime EndDate, ChaufferCharge ChfRate)
        {
            RaDriver oRADriver = null;
            //calculate total rental duration as a time span object
            TimeSpan dtSpan = EndDate - StartDate;

            //convert rental duration to minutes for standardization
            float ChaufferDurationInMinutes = GetDurationInMinutes(dtSpan, Convert.ToInt32(TariffType.MeasurementUnitId));
            //convert tariff type FromDuration to Minute for standardization
            float TariffDurationFrom = GetDurationInMinutes(TariffType.DurationFrom, Convert.ToInt32(TariffType.MeasurementUnitId));
            //convert tariff type ToDuration to Minute for standardization
            float TariffDurationTo = GetDurationInMinutes(TariffType.DurationTo, Convert.ToInt32(TariffType.MeasurementUnitId));
            //convert tariff type GracePeriod to Minute for standardization
            float TariffGracePeriod = GetDurationInMinutes((float)TariffType.GracePeriod, Convert.ToInt32(TariffType.MeasurementUnitId));
            //set rental charge object common parameters
            oRADriver = new RaDriver();
            oRADriver.TariffType = TariffType.TariffTypeCode;
            if (ChaufferDurationInMinutes >= TariffDurationFrom && ChaufferDurationInMinutes <= TariffDurationTo)
            {
                oRADriver.Rate = ChfRate.ChaufferChargeRate;
                oRADriver.TotalCharge = ChfRate.ChaufferChargeRate;
                oRADriver.ChargedDay = dtSpan.Days;
                oRADriver.ChargedHour = dtSpan.Hours;
                oRADriver.ChargedMinute = dtSpan.Minutes;

            }
            else
            {
                float ChargeDuration = GetDurationInMinutes(dtSpan, Convert.ToInt32(TariffType.MeasurementUnitId));
                oRADriver.TotalCharge = (float)Math.Round(((float)Math.Ceiling(Convert.ToDouble((ChargeDuration / TariffDurationTo)))) * ChfRate.ChaufferChargeRate, base.DecimalRounding, MidpointRounding.AwayFromZero);
                oRADriver.Rate = ChfRate.ChaufferChargeRate;
                //excess milage charge for edit case
                oRADriver.ChargedDay = dtSpan.Days;
                oRADriver.ChargedHour = dtSpan.Hours;
                oRADriver.ChargedMinute = dtSpan.Minutes;
            }
            return oRADriver;

        }

        private TimeSpan GetGrace(float RentalDuration, float To, Int16 Quotient)
        {
            //here everthing is in minutes

            Double Grace = Math.Round(RentalDuration - (To * Quotient), base.DecimalRounding, MidpointRounding.AwayFromZero);
            Int16 DayPart = Convert.ToInt16(Math.Floor(Grace / base.DayConversionUnit));
            Double RemainderAfterDayPart = Math.Round(Grace - (DayPart * base.DayConversionUnit), base.DecimalRounding, MidpointRounding.AwayFromZero);
            Int16 HourPart = Convert.ToInt16(Math.Floor(RemainderAfterDayPart / base.HourConversionUnit));
            Int16 MinutePart = Convert.ToInt16(RemainderAfterDayPart - (HourPart * base.HourConversionUnit));
            TimeSpan objTS = new TimeSpan(DayPart, HourPart, MinutePart, 0);

            return objTS;
        }
    }
}
