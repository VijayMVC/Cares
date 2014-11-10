using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Cares.Interfaces.IReportServices;
using System;
using Cares.Models.DomainModels;
using Cares.Models.ReportModels;
using Cares.Web.ModelMappers;
using Cares.WebBase.UnityConfiguration;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;

namespace Cares.Web.Reports
{
    public partial class DailyActionReport : Page
    {
        private IDailyActionService dailyActionService;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dailyActionService = UnityWebActivator.Container.Resolve<IDailyActionService>();
                IEnumerable<RaHireGroup> loadDailyActionReportDetail = dailyActionService.LoadDailyActionReportDetail();

                IEnumerable<DailyActionReportResponse> dailyActionReportResponses = loadDailyActionReportDetail.Select(raHireGroup => raHireGroup.CreateReportDataFrom()).OrderBy(rahireGroup => rahireGroup.RaNumber);
                dailyActionReport.ProcessingMode = ProcessingMode.Local;
                dailyActionReport.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/DailyAction.rdlc");
                var reportDataSource = new ReportDataSource
                {
                    Name = "ReportDS",
                    Value = dailyActionReportResponses
                };
                dailyActionReport.LocalReport.EnableExternalImages = true;
                dailyActionReport.LocalReport.EnableHyperlinks = true;
                dailyActionReport.HyperlinkTarget = "_blank";
                dailyActionReport.LinkActiveColor = System.Drawing.Color.Blue;
                dailyActionReport.LocalReport.DataSources.Clear();
                dailyActionReport.LocalReport.DataSources.Add(reportDataSource);
            }
        }
    }
}