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
    <script type="text/javascript" src="Scripts/feedbacks.js"></script>
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
                            <label id="ReplyStatus" style="visibility:hidden;"></label>
                            <div id="feedbackDiv" runat="server">
                                <asp:Label ID="NoFeedbacks" runat="server" Text="There are no feedbacks to be displayed" Visible="false"></asp:Label>                                
                            </div>
                            <input id="FeedbackID" value="" type="hidden" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal" id="replyFeedback" tabindex="-1" role="dialog" aria-labelledby="replyFeedbackLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="replyFeedbackLabel" style="font-size: 15px;">Reply Feedback</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <textarea id="Reply" rows="5" placeholder="Enter Reply" class="form-control" style="width:100%;"></textarea>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal" style="font-size: 15px;">Close</button>
                            <button type="button" class="btn btn-primary" style="font-size: 15px;" onclick="reply()">Reply</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="footer">
                <uc1:Footer runat="server" ID="Footer" />
            </div>
        </div>
    </form>
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
</body>
</html>
