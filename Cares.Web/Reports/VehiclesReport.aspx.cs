using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cares.Interfaces.IReportServices;
using Cares.Interfaces.IServices;
using Cares.Models.DomainModels;
using Cares.Models.ReportModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using Cares.WebBase.UnityConfiguration;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;

namespace Cares.Web.Reports
{
    public partial class VehiclesReport : Page
    {
        private IFleetReportService fleetReportService;

        //public VehiclesReport(IVehicleService vehicleService)
        //{
        //    this.vehicleService = vehicleService;
        //}


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