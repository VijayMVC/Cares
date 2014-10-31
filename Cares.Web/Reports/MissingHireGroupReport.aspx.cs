using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cares.Interfaces.IReportServices;
using Cares.Models.ReportModels;
using Cares.WebBase.UnityConfiguration;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;

namespace Cares.Web.Reports
{
    public partial class MissingHireGroupReport : System.Web.UI.Page
    {
        private IMissingHireGroupService missingHireGroupService;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                missingHireGroupService = UnityWebActivator.Container.Resolve<IMissingHireGroupService>();
                IList<MissingHireGroupResponse> missingHireGroupResponses =
                    missingHireGroupService.LoadMissingHireGroups();
                MissingHireGroup.ProcessingMode = ProcessingMode.Local;
                MissingHireGroup.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/MissingHireGroup.rdlc");
                ReportDataSource reportDataSource = new ReportDataSource
                {
                    Name = "MissingHireGroupDS",
                    Value = missingHireGroupResponses
                };
                MissingHireGroup.LocalReport.EnableExternalImages = true;
                MissingHireGroup.LocalReport.EnableHyperlinks = true;
                MissingHireGroup.HyperlinkTarget = "_blank";
                MissingHireGroup.LinkActiveColor = System.Drawing.Color.Blue;
                MissingHireGroup.LocalReport.DataSources.Clear();
                MissingHireGroup.LocalReport.DataSources.Add(reportDataSource);
            }
        }
    }
}