<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Order_Application_Admin.Index" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register TagPrefix="UserControl" TagName="NavigationVertical" Src="~/UserControls/VerticalNavigation.ascx" %>
<%@ Register TagPrefix="UserControl" TagName="NavigationHorizontal" Src="~/UserControls/Navigation.ascx" %>
<%@ Register Src="~/UserControls/Footer.ascx" TagPrefix="UserControl" TagName="Footer" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <link href="Content/Site.css" rel="stylesheet" />
    <link rel="icon" href="images/logo.ico" />
    <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/Site.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <style type="text/css">
        .content
        {
            background-color:#e4e1e4;
        }
    </style>
</head>
<body>
    <form id="index" runat="server">
        <div>
            <UserControl:NavigationHorizontal runat="server"></UserControl:NavigationHorizontal>
            <div class="row">
                <div class="col-md-2 col-lg-2" style="padding:0px 0px 0px 15px;">
                    <UserControl:NavigationVertical runat="server"></UserControl:NavigationVertical>
                </div>
                <div class="col-md-10 col-lg-10 content">
                    <div class="row" style="margin:0% 3%;">
                        <div class="dashboard-Div col-md-2 col-lg-2">
                             <div class="dashboard-icon"><img src="images/icons/users.png" alt="users" /></div>
                             <div class="dashboard-div-content">
                                 <h3>Users</h3>
                                 <br />
                                 <h3><%= users %></h3>
                             </div>
                        </div>
                        <div class="dashboard-Div col-md-2 col-lg-2">
                             <div class="dashboard-icon"><img src="images/icons/sellers.png" alt="sellers" /></div>
                             <div class="dashboard-div-content">
                                 <h3>Sellers</h3>
                                 <br />
                                 <h3><%= sellers %></h3>
                             </div>                   
                        </div>
                        <div class="dashboard-Div col-md-2 col-lg-2">
                             <div class="dashboard-icon"><img src="images/icons/items.png" alt="items" /></div>
                             <div class="dashboard-div-content">
                                 <h3>Items</h3>
                                 <br />
                                 <h3><%= items %></h3>
                             </div>                   
                        </div>
                        <div class="dashboard-Div col-md-2 col-lg-2">
                             <div class="dashboard-icon"><img src="images/icons/addcategory.png" alt="categories" /></div>
                             <div class="dashboard-div-content">
                                 <h3>Categories</h3>
                                 <br />
                                 <h3><%= categories %></h3>
                             </div>                   
                        </div>
                    </div>
                    <br />
                     <div class="row" style="margin:0% 3%;">
                        <div class="dashboard-Div col-md-2 col-lg-2">
                             <div class="dashboard-icon"><img src="images/icons/addsubcategory.png" alt="subcategories" /></div>
                             <div class="dashboard-div-content">
                                 <h3>Subcategories</h3>
                                 <br />
                                 <h3><%= subcategories %></h3>
                             </div>
                        </div>
                        <div class="dashboard-Div col-md-2 col-lg-2">
                             <div class="dashboard-icon"><img src="images/icons/orders.png" alt="orders" /></div>
                             <div class="dashboard-div-content">
                                 <h3>Orders</h3>
                                 <br />
                                 <h3><%= orders %></h3>
                             </div>                   
                        </div>
                        <div class="dashboard-Div col-md-2 col-lg-2">
                             <div class="dashboard-icon"><img src="images/icons/viewsales.png" alt="sales" /></div>
                             <div class="dashboard-div-content">
                                 <h3>Sales</h3>
                                 <br />
                                 <h3><%= sales %></h3>
                             </div>                   
                        </div>
                    </div>
                    <br />
                    <h2 style="margin:0% 6%;">Sales</h2>
                    <br />
                    <asp:Chart ID="SalesChart" runat="server" style="margin:0% 5% 0% 6%; width:40%;height:500px;">
                        <Titles>
                            <asp:Title Text="Sales Data"></asp:Title>
                        </Titles> 
                        <Series><asp:Series Name="SalesSeries" ChartType="Line" ChartArea="ChartArea1" Color="Green"></asp:Series></Series>
                        <chartareas><asp:ChartArea Name="ChartArea1"></asp:ChartArea></chartareas>
                    </asp:Chart>
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
