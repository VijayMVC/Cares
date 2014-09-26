using Cares.Models.DomainModels;

namespace Cares.Models.Common
{
    /// <summary>
    /// Billing Summary 
    /// </summary>
    public class BillingSummary
    {
        private double _TotalVehicleCharge;
        private double _SeasonalDiscount;
        private double _VoucherDiscount;
        private double _SpecialDiscount;
        private double _NetBillAfterDiscount;
        private double _TotalDropOffCharge;
        private double _TotalExcessMileageCharge;

        private double _TotalServiceCharge;
        private double _TotalInsuranceCharge;
        private double _TotalDriverCharge;
        private double _TotalAdditionalCharge;
        private double _TotalOtherCharge;

        private double _AmountPaid;
        private double _StandardDiscount;
        private double _Balance;
        
        public double TotalVehicleCharge
        {
            get { return double.Parse(_TotalVehicleCharge.ToString("N0")); }
            set { _TotalVehicleCharge = value; }
        }
        public double SeasonalDiscount
        {
            get
            {
                if (double.Parse(_SeasonalDiscount.ToString("N0")) > 0)
                    return -1 * double.Parse(_SeasonalDiscount.ToString("N0"));
                return double.Parse(_SeasonalDiscount.ToString("N0"));
            }

            set { _SeasonalDiscount = value; }
        }
        public double VoucherDiscount
        {
            get { return double.Parse(_VoucherDiscount.ToString("N0")); }
            set { _VoucherDiscount = value; }
        }
        public double SpecialDiscount
        {
            get { return double.Parse(_SpecialDiscount.ToString("N0")); }
            set { _SpecialDiscount = value; }
        }
        public double NetBillAfterDiscount
        {
            get { return double.Parse(_NetBillAfterDiscount.ToString("N0")); }
            set { _NetBillAfterDiscount = value; }
        }
        public double TotalDropOffCharge
        {
            get { return double.Parse(_TotalDropOffCharge.ToString("N0")); }
            set { _TotalDropOffCharge = value; }
        }
        public double TotalExcessMileageCharge
        {
            get { return double.Parse(_TotalExcessMileageCharge.ToString("N0")); }
            set { _TotalExcessMileageCharge = value; }
        }

        public double TotalServiceCharge
        {
            get { return double.Parse(_TotalServiceCharge.ToString("N0")); }
            set { _TotalServiceCharge = value; }
        }
        public double TotalInsuranceCharge
        {
            get { return double.Parse(_TotalInsuranceCharge.ToString("N0")); }
            set { _TotalInsuranceCharge = value; }
        }
        public double TotalDriverCharge
        {
            get { return double.Parse(_TotalDriverCharge.ToString("N0")); }
            set { _TotalDriverCharge = value; }
        }
        public double TotalAdditionalCharge
        {
            get { return double.Parse(_TotalAdditionalCharge.ToString("N0")); }
            set { _TotalAdditionalCharge = value; }
        }
        public double TotalOtherCharge
        {
            get { return double.Parse(_TotalOtherCharge.ToString("N0")); }
            set { _TotalOtherCharge = value; }
        }

        public double AmountPaid
        {
            get { return double.Parse(_AmountPaid.ToString("N0")); }
            set { _AmountPaid = value; }
        }
        public double StandardDiscount
        {
            get
            {
                if (double.Parse(_StandardDiscount.ToString("N0")) > 0)
                    return -1 * double.Parse(_StandardDiscount.ToString("N0"));
                return float.Parse(_StandardDiscount.ToString("N0"));
            }
            set { _StandardDiscount = value; }
        }

        public double Balance
        {
            get { return double.Parse(_Balance.ToString("N0")); }
            set { _Balance = value; }
        }


        public void LoadBillSummary(RaMain oRow)
        {
            TotalVehicleCharge = oRow.TotalVehicleCharge;
            SeasonalDiscount = oRow.SeasonalDiscount;
            VoucherDiscount = oRow.VoucherDiscount;
            SpecialDiscount = oRow.SpecialDiscount;
            NetBillAfterDiscount = oRow.NetBillAfterDiscount;
            TotalDropOffCharge = oRow.TotalDropOffCharge;
            TotalExcessMileageCharge = oRow.TotalExcessMileageCharge;

            TotalServiceCharge = oRow.TotalServiceCharge;
            TotalInsuranceCharge = oRow.TotalInsuranceCharge;
            TotalDriverCharge = oRow.TotalDriverCharge;
            TotalAdditionalCharge = oRow.TotalAdditionalCharge;
            TotalOtherCharge = oRow.TotalOtherCharge ?? 0;

            AmountPaid = oRow.AmountPaid;
            Balance = oRow.Balance;
            StandardDiscount = oRow.StandardDiscount;
        }

        public void Reset()
        {
            _TotalVehicleCharge = 0;
            _SeasonalDiscount = 0;
            _StandardDiscount = 0;
            _VoucherDiscount = 0;
            _SpecialDiscount = 0;
            _NetBillAfterDiscount = 0;
            _TotalDropOffCharge = 0;
            _TotalExcessMileageCharge = 0;

            _TotalServiceCharge = 0;
            _TotalInsuranceCharge = 0;
            _TotalDriverCharge = 0;
            _TotalAdditionalCharge = 0;
            _TotalOtherCharge = 0;

            _AmountPaid = 0;
            _Balance = 0;
        }
    }
}
