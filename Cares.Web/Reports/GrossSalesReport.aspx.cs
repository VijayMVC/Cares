using Cares.Interfaces.IReportServices;
using Cares.Models.ReportModels;
using Cares.Web.ModelMappers;
using Cares.WebBase.UnityConfiguration;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cares.Web.Reports
{
    public partial class GrossSalesReport : System.Web.UI.Page
    {
        IStandardRateReportService standardRateReportService;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                standardRateReportService = UnityWebActivator.Container.Resolve<IStandardRateReportService>();
                IEnumerable<StandardRateReportResponse> standardRateReportResponses = standardRateReportService.LoadStandardrateDetail().Select(standardRate => standardRate.CreateStandardRateReportResponse()); ;
                grossSalesReport.ProcessingMode = ProcessingMode.Local;
                grossSalesReport.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/GrossSalesReport");
                var reportDataSource = new ReportDataSource
                {
                    Name = "GrossSalesDS",
                    Value = standardRateReportResponses
                };
                grossSalesReport.LocalReport.EnableExternalImages = true;
                grossSalesReport.LocalReport.EnableHyperlinks = true;
                grossSalesReport.HyperlinkTarget = "_blank";
                grossSalesReport.LinkActiveColor = System.Drawing.Color.Blue;
                grossSalesReport.LocalReport.DataSources.Clear();
                grossSalesReport.LocalReport.DataSources.Add(reportDataSource);
            }
        }
    }
}