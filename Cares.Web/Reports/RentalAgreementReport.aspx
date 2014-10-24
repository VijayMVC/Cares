<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RentalAgreementReport.aspx.cs" Inherits="Cares.Web.Reports.RentalAgreementReport" MasterPageFile="~/Views/Shared/Reports.Master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <rsweb:ReportViewer ID="rentalAgreementReportViewer" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="600px"></rsweb:ReportViewer>    
 <asp:ScriptManager ID="ScriptManagerrentalAgreementReportViewer" runat="server" ></asp:ScriptManager>                       
</asp:Content>