<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsuranceRateReport.aspx.cs" Inherits="Cares.Web.Reports.InsuranceRateReport" MasterPageFile="~/Views/Shared/Reports.Master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <rsweb:ReportViewer ID="InsRateReport" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="600px"></rsweb:ReportViewer>    
 <asp:ScriptManager ID="InsRateReportScriptManager" runat="server" ></asp:ScriptManager>                       
</asp:Content>