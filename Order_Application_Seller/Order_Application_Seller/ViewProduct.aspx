<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="Order_Application_Seller.ViewProduct" %>

<%@ Register Src="~/Item.ascx" TagPrefix="UserControl" TagName="Item" %>
<%@ Register Src="~/UserControls/VerticalNavigation.ascx" TagPrefix="UserControl" TagName="VerticalNavigation" %>
<%@ Register Src="~/UserControls/Navigation.ascx" TagPrefix="UserControl" TagName="Navigation" %>
<%@ Register Src="~/UserControls/Footer.ascx" TagPrefix="UserControl" TagName="Footer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Products</title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <link href="Content/Site.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/Site.js"></script>
    <link rel="icon" href="images/logo.ico" />
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
</head>
<body>
    <form id="ViewItemForm" runat="server">
        <div>
            <UserControl:Navigation runat="server" ID="Navigation" />
            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <UserControl:VerticalNavigation runat="server" ID="VerticalNavigation" />
                </div>
                <div class="col-md-9 col-lg-9 viewItemCard">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12 col-lg-12">
                                    <h1>View Products</h1>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-1 col-lg-1 offset-md-8 offset-lg-8">
                                    <label for="FilterList">Filter</label>
                                </div>
                                <div class="col-md-2 col-lg-2">
                                    <asp:DropDownList ID="FilterList" runat="server" CssClass="form-control" OnSelectedIndexChanged="FilterList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div id="itemsListDiv" runat="server">
                                <asp:PlaceHolder ID="ItemsHolder" runat="server"></asp:PlaceHolder>
                            </div>
                            <div class="row">
                                <div id="pagesDiv" runat="server"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="footer">
                <UserControl:Footer runat="server" id="Footer" />
            </div>
        </div>
    </form>
</body>
</html>
