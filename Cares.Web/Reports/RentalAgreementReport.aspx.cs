using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cares.Interfaces.IReportServices;
using Cares.Interfaces.IServices;
using Cares.Models.DomainModels;
using Cares.Models.ReportModels;
using Cares.Web.ModelMappers;
using Cares.WebBase.UnityConfiguration;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;

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


                List<RaMain> rentalAgreementReportDetail = rentalAgreementReportService.GetRentalAgreementReportDetail();


                RentalAgreementDetailResponse detailResponse = rentalAgreementReportDetail.CreteFrom();

               rentalAgreementReportViewer.ProcessingMode = ProcessingMode.Local;
                rentalAgreementReportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/RentalAgreement.rdlc");
                ReportDataSource reportDataSource1 = new ReportDataSource
                {
                    Name = "RentalAgreementDS",
                    Value = detailResponse.RaVehicleInfo
                };

                ReportDataSource reportDataSource2 = new ReportDataSource
                {
                    Name = "RACustomerDS",
                    Value = detailResponse.RaCustomerInfo
                };
                rentalAgreementReportViewer.LocalReport.EnableExternalImages = true;
                rentalAgreementReportViewer.LocalReport.EnableHyperlinks = true;
                rentalAgreementReportViewer.HyperlinkTarget = "_blank";
                rentalAgreementReportViewer.LinkActiveColor = System.Drawing.Color.Blue;
                rentalAgreementReportViewer.LocalReport.DataSources.Clear();
                rentalAgreementReportViewer.LocalReport.DataSources.Add(reportDataSource1);
                rentalAgreementReportViewer.LocalReport.DataSources.Add(reportDataSource2);
            }
        }
    }
}