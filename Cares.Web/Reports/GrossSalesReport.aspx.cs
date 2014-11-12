using System.Linq;
using Cares.Implementation.ReportServices;
using Cares.Interfaces.IReportServices;
using Cares.Models.ReportModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models.ReportModels;
using Cares.WebBase.UnityConfiguration;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using GrossSalesReportResponse = Cares.Models.ReportModels.GrossSalesReportResponse;

namespace Cares.Web.Reports
{
    public partial class GrossSalesReport : System.Web.UI.Page
    {
        private IGrossSalesService grossSalesService;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grossSalesService = UnityWebActivator.Container.Resolve<IGrossSalesService>();
                IEnumerable<Models.ReportModels.GrossSalesReportResponse> grossSalesReportResponses = 
                    grossSalesService.LoadGrossSalesReport().Select( grossSales => grossSales.CreateGrossSalesDataFrom());
                grossSalesReport.ProcessingMode = ProcessingMode.Local;
                grossSalesReport.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/GrossSales.rdlc");
                var reportDataSource = new ReportDataSource
                {
                    Name = "GrossSalesDS",
                    Value = grossSalesReportResponses
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