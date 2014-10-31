using Cares.Interfaces.IServices;
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
                RaMain rentalAgreementReportDetail = rentalAgreementReportService.GetRentalAgreementReportDetail(1);
                RentalAgreementDetailResponse detailResponse = rentalAgreementReportDetail.CreteFrom();
                rentalAgreementReportViewer.ProcessingMode = ProcessingMode.Local;
                rentalAgreementReportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/RentalAgreement.rdlc");

                var rentalAgreementDataSource = new ReportDataSource
                {
                    Name = "RentalAgreement",
                    Value = detailResponse.RentalAgreementDetail
                };
                var customerInfoDataSource = new ReportDataSource
                {
                    Name = "CustomerInfo",
                    Value = detailResponse.RaCustomerInfo
                };
                var vehicleInfoDataSource = new ReportDataSource
                {
                    Name = "VehicleInfo",
                    Value = detailResponse.RaVehicleInfos
                };
                var serviceItemInfoDataSource = new ReportDataSource
                {
                    Name = "ServiceItemInfo",
                    Value = detailResponse.RaAdditionaItemInfos 
                };
                var driverDataSource = new ReportDataSource
                {
                    Name = "DriverInfo",
                    Value = detailResponse.RaDriverInfo
                };
                var additionChargeDataSource = new ReportDataSource
                {
                    Name = "AdditionalChargeInfo",
                    Value = detailResponse.RaAdditionalChargeInfos
                };
                var hiregGroupInsurenceDataSet = new ReportDataSource
                {
                    Name = "InsuranceInfos",
                    Value = detailResponse.RaHireGroupInsuranceInfos
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