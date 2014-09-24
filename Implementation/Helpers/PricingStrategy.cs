using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cares.Models.DomainModels;
using Cares.Models.Common;

namespace Cares.Implementation.Helpers
{
    public abstract class PricingStrategy
    {
        TariffType _TariffType;
        private Int16 _DecimalRounding = 2;
        private const Int16 _DayConversionUnit = 1440;// 24*60;
        private const Int16 _HourConversionUnit = 60;// 60;

        public PricingStrategy()
        {
        }
        public PricingStrategy(TariffType tType)
        {
            _TariffType = tType;
        }

        public abstract RentalCharge CalculateRentalCharge(DateTime StartDate, DateTime EndDate, StandardRate tSTrate);
        public abstract RaHireGroupInsurance CalculateInsuranceCharge(DateTime StartDate, DateTime EndDate, InsuranceRt InsRate);
        public abstract RaServiceItem CalculateRAServiceItemCharge(DateTime StartDate, DateTime EndDate, Int32 ItemQuantity, ServiceRt ServiceItemRate);
        public abstract RaDriver CalculateAddDriverCharge(DateTime StartDate, DateTime EndDate, AdditionalDriverCharge AddDrvRate);
        public abstract RaDriver CalculateChaufferCharge(DateTime StartDate, DateTime EndDate, ChaufferCharge ChfRate);


        public Int16 DecimalRounding
        {
            get { return _DecimalRounding; }
        }
        public Int16 DayConversionUnit
        {
            get { return _DayConversionUnit; }
        }
        public Int16 HourConversionUnit
        {
            get { return _HourConversionUnit; }
        }

        public float GetDurationInMinutes(TimeSpan dtSpan, int mUnit)
        {
            if (mUnit == (int)MeasurementUnitEnum.Day)
                return (dtSpan.Days * DayConversionUnit + (dtSpan.Hours * HourConversionUnit) + dtSpan.Minutes);
            else if (mUnit == (int)MeasurementUnitEnum.Hour)
                return dtSpan.Days * DayConversionUnit + dtSpan.Hours * HourConversionUnit + dtSpan.Minutes;
            else
                return dtSpan.Days * DayConversionUnit + dtSpan.Hours * HourConversionUnit + dtSpan.Minutes;
        }
        public float GetDurationInMinutes(Int16 Value, int mUnit)
        {
            if (mUnit == (int)MeasurementUnitEnum.Day)
                return Value * DayConversionUnit;
            else if (mUnit == (int)MeasurementUnitEnum.Hour)
                return Value * HourConversionUnit;
            else
                return Value;
        }
        public float GetDurationInMinutes(float Value, int mUnit)
        {
            if (mUnit == (int)MeasurementUnitEnum.Day)
                return Value * DayConversionUnit;
            else if (mUnit == (int)MeasurementUnitEnum.Hour)
                return Value * HourConversionUnit;
            else
                return Value;
        }
        public float GetExcessMileageCharge(Int32 OutOdometer, Int32 InOdometer, Int32 AllowedMileage, float ExcessMileageRate)
        {
            Int32 OdometerDiff = InOdometer - OutOdometer;
            Int32 ExcessMileage = 0;
            if (OdometerDiff > AllowedMileage)
            {
                ExcessMileage = OdometerDiff - AllowedMileage;
                return ExcessMileage * ExcessMileageRate;
            }
            return 0;
        }
        public Int32 GetExcessMileage(Int32 OutOdometer, Int32 InOdometer, Int32 AllowedMileage)
        {
            Int32 OdometerDiff = InOdometer - OutOdometer;
            Int32 ExcessMileage = 0;
            if (OdometerDiff > AllowedMileage)
            {
                ExcessMileage = OdometerDiff - AllowedMileage;
            }
            return ExcessMileage;
        }
        public float GetExcessMileageCharge(Int32 ExcessMileage, float ExcessMileageRate)
        {
            if (ExcessMileage >= 0)
                return ExcessMileage * ExcessMileageRate;
            return 0;
        }
        public TariffType TariffType
        {
            get { return _TariffType; }
            set { _TariffType = value; }
        }

    }
}
