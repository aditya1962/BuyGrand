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
                            <div class="row" id="ValidateAccount" runat="server">
                                <div class="col-md-6 col-lg-6">
                                    <label style="font-size:15px;">Validate before continuing with approving sellers</label>
                                </div>
                                <div class="col-md-2 col-lg-2">
                                    <button class="btn btn-primary" type="button" data-toggle="modal" data-target="#approveModal">Validate</button>
                                </div>
                            </div>
                            <br />
                            <asp:Label ID="ValidateUser" runat="server" Text="" style="font-size:15px;" Visible="false"></asp:Label>
                            <br />
                           <div id="approveSellerHtml" runat="server"></div>
                            <div class="modal" id="approveModal" tabindex="-1" role="dialog" aria-labelledby="approveModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document" style=""max-width:75%;">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="approveModalLabel" style="font-size:15px;">Validate your account</h5>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label style="font-size:15px;">Enter account username</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="Username" placeholder="Enter account username" runat="server" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="UsernameBlank" runat="server" ErrorMessage="Username cannot be blank" ControlToValidate="Username" Font-Size="15px" ValidationGroup="ApproveSeller"></asp:RequiredFieldValidator>
                                                    <br />
                                                    <asp:RegularExpressionValidator ID="UsernameType" runat="server" ErrorMessage="Username cannot be a number" Display="Dynamic" Font-Size="15px" ControlToValidate="Username" ValidationExpression="(?!^\d+$)^.+$" ValidationGroup="SendFeedback"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label style="font-size:15px;">Enter account password</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="Password" placeholder="Enter account password" type="password" runat="server" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="PasswordBlank" runat="server" ErrorMessage="Password cannot be blank" Font-Size="15px" ControlToValidate="Password" ValidationGroup="ApproveSeller"></asp:RequiredFieldValidator>
                                                    <br />
                                                    <asp:RegularExpressionValidator ID="PasswordType" runat="server" ErrorMessage="Password cannot be a number" Display="Dynamic" Font-Size="15px" ControlToValidate="Password" ValidationExpression="(?!^\d+$)^.+$" ValidationGroup="SendFeedback"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <asp:Label ID="AccountInvalid" runat="server" Text="Username and/or Password incorrect" Style="font-size: 15px; color: red;" Visible="false"></asp:Label>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                            <asp:button type="button" class="btn btn-primary" runat="server" Text="Validate" style="font-size:15px;" OnClick="Validate_Click" ValidationGroup="ApproveSeller"></asp:button>
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
        function approveClick(id) {
            $.ajax({
                url: 'Data/ApproveUser.aspx',
                data: {userid:id},
                dataType: "json",
                method: "get",
                contentType: "application/json",
                success: function (data) {
                    if (data > 0) {
                        $("#UpdateValue").text("User with username " + id + " approved");
                        $("#UpdateValue").show();
                        $("#"+id).text("Approved");
                    }
                    else {
                        $("#UpdateValue").text("Could not approve user with username " + id);
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
