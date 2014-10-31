using Cares.Interfaces.IReportServices;
using Cares.Models.ReportModels;
using Cares.WebBase.UnityConfiguration;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Cares.Web.Reports
{
    public partial class VehiclesReport : Page
    {
        private IFleetReportService fleetReportService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fleetReportService = UnityWebActivator.Container.Resolve<IFleetReportService>();


                IList<RptFleetHireGroupDetail> loadFleets = fleetReportService.LoadFleetHireGroupDetail();

                VehicleReport.ProcessingMode = ProcessingMode.Local;
                VehicleReport.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/Vehicle.rdlc");
                ReportDataSource reportDataSource = new ReportDataSource
                {
                    Name = "FleetDS",
                    Value = loadFleets
                };
                VehicleReport.LocalReport.EnableExternalImages = true;
                VehicleReport.LocalReport.EnableHyperlinks = true;
                VehicleReport.HyperlinkTarget = "_blank";
                VehicleReport.LinkActiveColor = System.Drawing.Color.Blue;
                VehicleReport.LocalReport.DataSources.Clear();
                VehicleReport.LocalReport.DataSources.Add(reportDataSource);
            }
        }
    }
}