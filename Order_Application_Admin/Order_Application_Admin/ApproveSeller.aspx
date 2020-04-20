<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApproveSeller.aspx.cs" Inherits="Order_Application_Admin.ApproveSeller" %>
<%@ Register TagPrefix="UserControl" TagName="NavigationVertical" Src="~/UserControls/VerticalNavigation.ascx" %>
<%@ Register TagPrefix="UserControl" TagName="NavigationHorizontal" Src="~/UserControls/Navigation.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Approve Seller</title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css"/>
    <link href="Content/Site.css" rel="stylesheet" />
    <link rel="icon" href="images/logo.ico" />
    <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/Site.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <style type="text/css">
        th
        {
            font-size:15px;
            border:1px solid #000000;
        }
        td
        {
            border: 1px solid #000000;
            font-size:15px;
        }
        [type=button]
        {
            font-size:15px;
        }
    </style>
</head>
<body>
    <form id="approve_seller" runat="server">
        <div>
            <UserControl:NavigationHorizontal runat="server"></UserControl:NavigationHorizontal>
            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <UserControl:NavigationVertical runat="server"></UserControl:NavigationVertical>
                </div>
                <div class="col-md-9 col-lg-9">
                    <h3 style="font-size:25px;">Approve Sellers</h3>
                    <br />
                    <div class="card">
                        <div class="card-body">
                           <asp:Label ID="UpdateValue" runat="server" Text="" style="font-size:15px;display:none;"></asp:Label>
                           <div id="approveSellerHtml" runat="server"></div>
                        </div>
                    </div>
                </div>
            </div>
            <!--Footer-->
            <div class="footer">

            </div>
        </div>
    </form>
    <script type="text/javascript">
        function approveClick(id) {
            $.ajax({
                url: 'Data/ApproveUser.aspx',
                data: {userid:id},
                dataType: "json",
                method: "get",
                contentType: "application/json",
                success: function (data) {
                    if (data > 0) {
                        $("#UpdateValue").text("User updated successfully");
                        $("#UpdateValue").show();
                    }
                    else {
                        $("#UpdateValue").text("Could not update user");
                        $("#UpdateValue").show();
                    }
                },
                error: function(err) {
                    console.log(err.responseText);
                }
            })
        }
    </script>
</body>
</html>
