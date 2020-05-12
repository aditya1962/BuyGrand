<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSales.aspx.cs" Inherits="Order_Application_Admin.ViewSales" %>
<%@ Register TagPrefix="UserControl" TagName="NavigationVertical" Src="~/UserControls/VerticalNavigation.ascx" %>
<%@ Register TagPrefix="UserControl" TagName="NavigationHorizontal" Src="~/UserControls/Navigation.ascx" %>
<%@ Register Src="~/UserControls/Footer.ascx" TagPrefix="UserControl" TagName="Footer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Sales</title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <link href="Content/Site.css" rel="stylesheet" />
    <link rel="icon" href="images/logo.ico" />
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/Site.js"></script>
</head>
<body>
    <form id="view_sales" runat="server">
        <div>
            <UserControl:NavigationHorizontal runat="server"></UserControl:NavigationHorizontal>
            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <UserControl:NavigationVertical runat="server"></UserControl:NavigationVertical>
                </div>
                <div class="col-md-9 col-lg-9">
                    <h3 style="font-size:25px;">View Sales</h3>
                    <br />
                    <div class="card">
                        <div class="card-body">
                           <div class="row">
                               <div class="col-md-2 col-lg-2">
                                   <label style="font-size:15px;">Start Date</label>
                               </div>
                               <div class="col-md-2 col-lg-2"> 
                                   <asp:TextBox ID="startdate" type="date" class="form-control"  style="font-size:15px;" runat="server"></asp:TextBox>
                               </div>
                               <div class="col-md-2 col-lg-2 offset-md-1 offset-lg-1">
                                   <label style="font-size:15px;">End Date</label>
                                   <br />
                                   <asp:Label ID="dateErrorLabel" style="color:red;font-size:15px;" runat="server" Visible="false">Pick a date after the start date</asp:Label>
                               </div>
                               <div class="col-md-2 col-lg-2">
                                   <asp:TextBox ID="enddate" type="date" class="form-control"  style="font-size:15px;" runat="server"></asp:TextBox>
                               </div>
                               <div class="col-md-3 col-lg-3">
                                   <asp:Button ID="View" class="btn btn-primary" text="View" style="font-size:15px;" runat="server" onclick="View_Click"></asp:Button>
                               </div>
                               <asp:ScriptManager ID="ScriptManager1" runat="server">
                               </asp:ScriptManager>
                               <div class="row" style="margin:4% 0%;">
                                   <asp:Label ID="DateNull" Text="" runat="server" style="font-size:15px; margin:4%;" Visible="False"></asp:Label><br />
                                   <asp:Label ID="ReportDataNull" Text="" runat="server" style="font-size:15px; margin:0% 0% 4% 4%;" Visible="False"></asp:Label>
                                   <rsweb:reportviewer ID="SalesReport" runat="server" Style="width: 96%; margin-left:25px">                                      
                                   </rsweb:reportviewer>
                               </div>
                           </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--Footer-->
            <div class="footer">
                <UserControl:Footer runat="server" ID="Footer" />
            </div>
        </div>
    </form>
</body>
</html>
