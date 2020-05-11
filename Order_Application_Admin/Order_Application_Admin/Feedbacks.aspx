<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Feedbacks.aspx.cs" Inherits="Order_Application_Admin.Feedbacks" %>
<%@ Register TagPrefix="UserControl" TagName="NavigationVertical" Src="~/UserControls/VerticalNavigation.ascx" %>
<%@ Register TagPrefix="UserControl" TagName="NavigationHorizontal" Src="~/UserControls/Navigation.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Feedbacks</title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <link href="Content/Site.css" rel="stylesheet" />
    <link rel="icon" href="images/logo.ico" />
    <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/Site.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <style type="text/css">
        th {
            font-size: 15px;
            border: 1px solid #000000;
        }

        td {
            border: 1px solid #000000;
            font-size: 15px;
        }

        [type=button] {
            font-size: 15px;
        }

        label {
            font-size: 15px;
        }

        #paginationHtml td
        {
            border:0px;
        }

        #paginationHtml a
        {
            color:white;
            text-decoration:none;
            font-size:15px;
        }
    </style>
</head>
<body>
    <form id="feedbacks" runat="server">
        <div>
            <UserControl:NavigationHorizontal runat="server"></UserControl:NavigationHorizontal>
            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <UserControl:NavigationVertical runat="server"></UserControl:NavigationVertical>
                </div>
                <div class="col-md-9 col-lg-9">
                    <h3 style="font-size: 25px;">Feedbacks</h3>
                    <br />
                    <br />
                    <div class="card">
                        <div class="card-body">
                            <asp:Label ID="FeedbackAdded" runat="server" Text="" Visible="false" style="font-size:15px;"></asp:Label>
                            <div class="row">
                                <div class="col-md-1 col-lg-1 offset-md-8 offset-lg-8">
                                    <label style="font-size:15px;">Filter</label>
                                </div>
                                <div class="col-md-3 col-lg-3">
                                    <asp:DropDownList ID="FilterValues" style="font-size:15px;" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div id="feedbacksHtml" runat="server"></div>
                            <br />
                            <div id="paginationHtml" runat="server"></div>
                            <input type="hidden" id="feedbackUser" value="" runat="server" />
                            <div class="modal" id="feedbackModal" tabindex="-1" role="dialog" aria-labelledby="feedbackModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document" style=""max-width:75%;">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="feedbackModalLabel" style="font-size:15px;">Send Feedback</h5>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Feedback</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="feedback" placeholder="Enter feedback" runat="server" TextMode="MultiLine" Columns="20" Rows="5" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="FeedbackBlank" runat="server" ErrorMessage="Feedback cannot be blank" ControlToValidate="feedback" ValidationGroup="SendFeedback" Font-Size="15px"></asp:RequiredFieldValidator>
                                                    <br />
                                                    <asp:RegularExpressionValidator ID="FeedbackType" runat="server" ErrorMessage="Feedback cannot be a number" Display="Dynamic" Font-Size="15px" ControlToValidate="feedback" ValidationGroup="SendFeedback" ValidationExpression="(?!^\d+$)^.+$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter account username</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="Username" placeholder="Enter account username" runat="server" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="UsernameBlank" runat="server" ErrorMessage="Username cannot be blank" ControlToValidate="Username" Font-Size="15px" ValidationGroup="SendFeedback"></asp:RequiredFieldValidator>
                                                    <br />
                                                    <asp:RegularExpressionValidator ID="UsernameType" runat="server" ErrorMessage="Username cannot be a number" Display="Dynamic" Font-Size="15px" ControlToValidate="Username" ValidationExpression="(?!^\d+$)^.+$" ValidationGroup="SendFeedback"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter account password</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="Password" placeholder="Enter account password" type="password" runat="server" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="PasswordBlank" runat="server" ErrorMessage="Password cannot be blank" Font-Size="15px" ControlToValidate="Password" ValidationGroup="SendFeedback"></asp:RequiredFieldValidator>
                                                    <br />
                                                    <asp:RegularExpressionValidator ID="PasswordType" runat="server" ErrorMessage="Password cannot be a number" Display="Dynamic" Font-Size="15px" ControlToValidate="Password" ValidationExpression="(?!^\d+$)^.+$" ValidationGroup="SendFeedback"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <asp:Label ID="AccountInvalid" runat="server" Text="Username and/or Password incorrect" Style="font-size: 15px; color: red;" Visible="false"></asp:Label>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                            <asp:button type="button" class="btn btn-primary" runat="server" Text="Send" style="font-size:15px;" OnClick="Feedback_Click" ValidationGroup="SendFeedback"></asp:button>
                                        </div>
                                    </div>
                                </div>
                            </div>
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
        function sendFeedback(id) {
            var feedbackID = id.slice(id.lastIndexOf('_') + 1);
            $("#feedbackUser").val(feedbackID);
        }
    </script>
</body>
</html>
