using System.Collections.Generic;
using System.Linq;
using Cares.Interfaces.IReportServices;
using Cares.Models.DomainModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models.ReportModels;
using Cares.WebBase.UnityConfiguration;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;
using System;

namespace Cares.Web.Reports
{
    public partial class RentalAgreementReport : System.Web.UI.Page
    {
        private IRentalAgreementReportService rentalAgreementReportService;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rentalAgreementReportService = UnityWebActivator.Container.Resolve<IRentalAgreementReportService>();
                RaMain rentalAgreementReportDetail = rentalAgreementReportService.GetRentalAgreementReportDetail(int.Parse(Request.QueryString["id"]));
                RentalAgreementDetailResponse detailResponse = rentalAgreementReportDetail != null ? rentalAgreementReportDetail.CreteFrom() : new RentalAgreementDetailResponse();
                rentalAgreementReportViewer.ProcessingMode = ProcessingMode.Local;
                rentalAgreementReportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/RentalAgreement.rdlc");
                var rentalAgreementDataSource = new ReportDataSource
                {
                    Name = "RentalAgreement",
                    Value = detailResponse.RentalAgreementDetail == null ? new List<RentalAgreementDetail>() : detailResponse.RentalAgreementDetail.ToList()
                };
                var customerInfoDataSource = new ReportDataSource
                {
                    Name = "CustomerInfo",
                    Value = detailResponse.RaCustomerInfo == null ? new List<RaCustomerInfo>() : detailResponse.RaCustomerInfo.ToList()
                };
                var vehicleInfoDataSource = new ReportDataSource
                {
                    Name = "VehicleInfo",
                    Value = detailResponse.RaVehicleInfos == null ? new List<RaVehicleInfo>() : detailResponse.RaVehicleInfos.ToList()
                };
                var serviceItemInfoDataSource = new ReportDataSource
                {
                    Name = "ServiceItemInfo",
                    Value = detailResponse.RaAdditionaItemInfos == null ? new List<RaAdditionaItemInfo>() : detailResponse.RaAdditionaItemInfos.ToList()
                };
                var driverDataSource = new ReportDataSource
                {
                    Name = "DriverInfo",
                    Value = detailResponse.RaDriverInfo == null ? new List<Models.RaDriver>() : detailResponse.RaDriverInfo.ToList()
                };
                var additionChargeDataSource = new ReportDataSource
                {
                    Name = "AdditionalChargeInfo",
                    Value = detailResponse.RaAdditionalChargeInfos == null ? new List<RaAdditionalChargeInfo>() : detailResponse.RaAdditionalChargeInfos.ToList()
                };
                var hiregGroupInsurenceDataSet = new ReportDataSource
                {
                    Name = "InsuranceInfos",
                    Value = detailResponse.RaHireGroupInsuranceInfos == null ? new List<Models.RaDriver>() : detailResponse.RaDriverInfo.ToList()
                };
                rentalAgreementReportViewer.LocalReport.EnableExternalImages = true;
                rentalAgreementReportViewer.LocalReport.EnableHyperlinks = true;
                rentalAgreementReportViewer.HyperlinkTarget = "_blank";
                rentalAgreementReportViewer.LinkActiveColor = System.Drawing.Color.Blue;
                rentalAgreementReportViewer.LocalReport.DataSources.Clear();
                rentalAgreementReportViewer.LocalReport.DataSources.Add(rentalAgreementDataSource);
                rentalAgreementReportViewer.LocalReport.DataSources.Add(customerInfoDataSource);
                rentalAgreementReportViewer.LocalReport.DataSources.Add(vehicleInfoDataSource);
                rentalAgreementReportViewer.LocalReport.DataSources.Add(serviceItemInfoDataSource);
                rentalAgreementReportViewer.LocalReport.DataSources.Add(driverDataSource);
                rentalAgreementReportViewer.LocalReport.DataSources.Add(additionChargeDataSource);
                rentalAgreementReportViewer.LocalReport.DataSources.Add(hiregGroupInsurenceDataSet);
            }
        }
    }
}