<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewFeedbacks.aspx.cs" Inherits="Order_Application_Seller.ViewFeedbacks" %>

<%@ Register Src="~/UserControls/VerticalNavigation.ascx" TagPrefix="uc1" TagName="VerticalNavigation" %>
<%@ Register Src="~/UserControls/Navigation.ascx" TagPrefix="uc1" TagName="Navigation" %>
<%@ Register Src="~/UserControls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Feedbacks</title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <link href="Content/Site.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/jquery-3.4.1.js"></script>
    <script type="text/javascript" src="Scripts/Site.js"></script>
    <script type="text/javascript" src="Scripts/product.js"></script>
    <link rel="icon" href="images/logo.ico" />
</head>
<body>
    <form id="ViewFeedbacks" runat="server">
        <div>
            <uc1:Navigation runat="server" ID="Navigation" />
            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <uc1:VerticalNavigation runat="server" ID="VerticalNavigation" />
                </div>
                <div class="col-md-9 col-lg-9 viewFeedbacksCard">
                    <div class="card product">
                        <div class="card-body">
                            <div id="feedbackDiv" runat="server"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="footer">
                <uc1:Footer runat="server" ID="Footer" />
            </div>
        </div>
    </form>
</body>
</html>
