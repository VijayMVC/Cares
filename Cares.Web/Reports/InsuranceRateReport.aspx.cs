using System.Linq;
using Cares.Implementation.ReportServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models.ReportModels;
using Cares.WebBase.UnityConfiguration;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;

namespace Cares.Web.Reports
{
    public partial class InsuranceRateReport : System.Web.UI.Page
    {
        private InsuranceRateReportService insuranceRateReportService;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                insuranceRateReportService = UnityWebActivator.Container.Resolve<InsuranceRateReportService>();
                IEnumerable<InsuranceRateReportResponse> insuranceRates = 
                insuranceRateReportService.LoadInsuranceRateReport().Select(insuranceRate => insuranceRate.CreateReportFrom());
                InsRateReport.ProcessingMode = ProcessingMode.Local;
                InsRateReport.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/InsuranceRate.rdlc");
                var reportDataSource = new ReportDataSource
                {
                    Name = "InsuranceRateDS",
                    Value = insuranceRates
                };
                InsRateReport.LocalReport.EnableExternalImages = true;
                InsRateReport.LocalReport.EnableHyperlinks = true;
                InsRateReport.HyperlinkTarget = "_blank";
                InsRateReport.LinkActiveColor = System.Drawing.Color.Blue;
                InsRateReport.LocalReport.DataSources.Clear();
                InsRateReport.LocalReport.DataSources.Add(reportDataSource);
            }
        }
    }
}