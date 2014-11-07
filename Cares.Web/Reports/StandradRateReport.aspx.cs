using System;
using System.Collections.Generic;
using System.Linq;
using Cares.Interfaces.IReportServices;
using Cares.Models.DomainModels;
using Cares.Models.ReportModels;
using Cares.Web.ModelMappers;
using Cares.WebBase.UnityConfiguration;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;

namespace Cares.Web.Reports
{
    public partial class StandradRateReport : System.Web.UI.Page
    {
        IStandardRateReportService standardRateReportService;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                standardRateReportService = UnityWebActivator.Container.Resolve<IStandardRateReportService>();
                IEnumerable<StandardRate> standardRates = standardRateReportService.LoadStandardrateDetail();
                IEnumerable<StandardRateReportResponse> standardRateReportResponses = standardRates.Select(standardRate => standardRate.CreateStandardRateReportResponse());
                StRateReport.ProcessingMode = ProcessingMode.Local;
                StRateReport.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/StandardRate.rdlc");
                var reportDataSource = new ReportDataSource
                {
                    Name = "StandradRate",
                    Value = standardRateReportResponses
                };
                StRateReport.LocalReport.EnableExternalImages = true;
                StRateReport.LocalReport.EnableHyperlinks = true;
                StRateReport.HyperlinkTarget = "_blank";
                StRateReport.LinkActiveColor = System.Drawing.Color.Blue;
                StRateReport.LocalReport.DataSources.Clear();
                StRateReport.LocalReport.DataSources.Add(reportDataSource);
            }
        }
    }
}