using System;
using System.Collections.Generic;
using Cares.ExceptionHandling;
using Cares.Models.DomainModels;

namespace Cares.Implementation.Helpers
{
    public class RentalCharge
    {
        private String _TariffTypeCode = string.Empty;
        private DateTime _RentalChargeStartDate;
        private DateTime _RentalChargeEndDate;
        private float _StRate = 0;
        private float _TotalStandardCharge = 0;
        private float _TotalExcMileageCharge = 0;
        private Int32 _TotalExcMileage = 0;
        private float _DropOffCharge = 0;
        private Int32 _AllowedMileage = 0;
        private float _ExcessMileageRt = 0;
        private Int32 _GraceDay = 0;
        private Int32 _GraceHour = 0;
        private Int32 _GraceMinute = 0;
        private Int32 _ChargedDay = 0;
        private Int32 _ChargedHour = 0;
        private Int32 _ChargedMinute = 0;

        public RentalCharge()
        {
        }

        public String TariffTypeCode
        {
            get { return _TariffTypeCode; }
            set { _TariffTypeCode = value; }
        }
        public DateTime RentalChargeStartDate
        {
            get { return _RentalChargeStartDate; }
            set { _RentalChargeStartDate = value; }
        }
        public DateTime RentalChargeEndDate
        {
            get { return _RentalChargeEndDate; }
            set { _RentalChargeEndDate = value; }
        }
        public float StRate
        {
            get { return _StRate; }
            set { _StRate = value; }
        }
        public float TotalStandardCharge
        {
            get { return _TotalStandardCharge; }
            set { _TotalStandardCharge = value; }
        }
        public float TotalExcMileageCharge
        {
            get { return _TotalExcMileageCharge; }
            set { _TotalExcMileageCharge = value; }
        }
        public Int32 TotalExcMileage
        {
            get { return _TotalExcMileage; }
            set { _TotalExcMileage = value; }
        }
        public float DropOffCharge
        {
            get { return _DropOffCharge; }
            set { _DropOffCharge = value; }
        }
        public Int32 AllowedMileage
        {
            get { return _AllowedMileage; }
            set { _AllowedMileage = value; }
        }
        public float ExcessMileageRt
        {
            get { return _ExcessMileageRt; }
            set { _ExcessMileageRt = value; }
        }
        public Int32 GraceDay
        {
            get { return _GraceDay; }
            set { _GraceDay = value; }
        }
        public Int32 GraceHour
        {
            get { return _GraceHour; }
            set { _GraceHour = value; }
        }
        public Int32 GraceMinute
        {
            get { return _GraceMinute; }
            set { _GraceMinute = value; }
        }
        public Int32 ChargedDay
        {
            get { return _ChargedDay; }
            set { _ChargedDay = value; }
        }
        public Int32 ChargedHour
        {
            get { return _ChargedHour; }
            set { _ChargedHour = value; }
        }
        public Int32 ChargedMinute
        {
            get { return _ChargedMinute; }
            set { _ChargedMinute = value; }
        }


        public void CalculateCharge(DateTime RecCreatedDate, DateTime RAStDate, DateTime RAEndDate, DateTime stDate, DateTime eDate, Int64 OperationID, Int64 HireGroupDetailID, Int32 OutOdometer, Int32 InOdometer, List<TariffType> oTariffTypeList)
        {
            PricingStrategy objPS = PricingStrategyFactory.GetPricingStrategy(RecCreatedDate, RAStDate, RAEndDate, OperationID, oTariffTypeList);
            if (objPS == null)
            {
                throw new CaresException("RentalAgreement-TarrifTypeNotDefined", null);
            }
            StandardRate otStRate = new StandardRate();
            //otStRate.LoadTariffStandardRate(objPS.TariffType.TariffTypeCode, HireGroupDetailID, RecCreatedDate);
            RentalCharge tmp = objPS.CalculateRentalCharge(stDate, eDate, otStRate);

            // need to get RA vehicle as well for calculating Excess Mileage Charge for edit case
            this.TariffTypeCode = tmp.TariffTypeCode;
            this.RentalChargeStartDate = tmp.RentalChargeStartDate;
            this.RentalChargeEndDate = tmp.RentalChargeEndDate;
            this.StRate = tmp.StRate;
            this.TotalStandardCharge = tmp.TotalStandardCharge;
            //this.TotalExcMileageCharge = tmp.TotalExcMileageCharge;
            //this.TotalExcMileage = tmp.TotalExcMileage;
            this.DropOffCharge = tmp.DropOffCharge;
            this.AllowedMileage = tmp.AllowedMileage;
            this.ExcessMileageRt = tmp.ExcessMileageRt;
            this.GraceDay = tmp.GraceDay;
            this.GraceHour = tmp.GraceHour;
            this.GraceMinute = tmp.GraceMinute;
            this.ChargedDay = tmp.ChargedDay;
            this.ChargedHour = tmp.ChargedHour;
            this.ChargedMinute = tmp.ChargedMinute;

            this.TotalExcMileage = objPS.GetExcessMileage(OutOdometer, InOdometer, tmp.AllowedMileage);
            this.TotalExcMileageCharge = objPS.GetExcessMileageCharge(this.TotalExcMileage, tmp.ExcessMileageRt);



        }


    }
}
