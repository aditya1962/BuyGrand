<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageSeller.aspx.cs" Inherits="Order_Application_Admin.ManagerSeller" Async="true" %>

<%@ Register TagPrefix="UserControl" TagName="NavigationVertical" Src="~/UserControls/VerticalNavigation.ascx" %>
<%@ Register TagPrefix="UserControl" TagName="NavigationHorizontal" Src="~/UserControls/Navigation.ascx" %>
<%@ Register Src="~/UserControls/Footer.ascx" TagPrefix="UserControl" TagName="Footer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Seller</title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <link href="Content/Site.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/Site.js"></script>
    <link rel="icon" href="images/logo.ico" />
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <style type="text/css">
        #pagination td {
            border: 0px;
            padding: 0% 3%;
        }

        #pagination a {
            font-size: 15px;
        }
    </style>
</head>
<body>
    <form id="managerSeller" runat="server">
        <div>
            <UserControl:NavigationHorizontal runat="server"></UserControl:NavigationHorizontal>
            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <UserControl:NavigationVertical runat="server"></UserControl:NavigationVertical>
                </div>
                <div class="col-md-9 col-lg-9 content">
                    <h3 style="font-size: 25px;">Manage Sellers</h3>
                    <br />
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-1 col-lg-1 offset-md-9 offset-lg-9">
                                    <asp:Label runat="server">Filter </asp:Label>
                                </div>
                                <div class="col-md-2 col-lg-2">
                                    <asp:DropDownList ID="FilterValues" class="form-control" runat="server" Style="font-size: 15px;" OnSelectedIndexChanged="ValueFiltered" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <asp:Label ID="deleteSuccess" runat="server" Text="" Visible="false"></asp:Label>
                            <div id="manageSellerHtml" runat="server"></div>
                            <br />
                            <br />
                            <div id="pagination" runat="server"></div>
                            <input type="hidden" id="deleteValue" value="" runat="server" />
                            <input type="hidden" id="sendMessageVal" value="" runat="server" />
                            <div class="modal" id="deleteModal" tabindex="-1" role="dialog" aria-labelledby="deleteModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="deleteModalLabel" style="font-size: 15px;">Delete Seller</h5>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                            <label>Are you sure you want to delete this seller?</label>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter account username</label>
                                                </div>
                                                <div class="col-md-5 col-lg-5">
                                                    <asp:TextBox ID="DeleteUsername" placeholder="Enter account username" runat="server" class="form-control" Style="font-size: 15px;" MaxLength="15"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:RegularExpressionValidator ID="DeleteUsernameType" runat="server" ErrorMessage="Username cannot be an integer" Display="Dynamic" ControlToValidate="DeleteUsername" ValidationGroup="DeleteModal" ValidationExpression="(?!^\d+$)^.+$"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="DeleteUsernameValidate" runat="server" ErrorMessage="Username cannot be blank" Font-Size="15px" ControlToValidate="DeleteUsername" ValidationGroup="DeleteModal"></asp:RequiredFieldValidator>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter account password</label>
                                                </div>
                                                <div class="col-md-5 col-lg-5">
                                                    <asp:TextBox ID="DeletePassword" placeholder="Enter account password" type="password" runat="server" class="form-control" Style="font-size: 15px;" MaxLength="250"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:RegularExpressionValidator ID="DeletePasswordType" runat="server" ErrorMessage="Password cannot be an integer" Display="Dynamic" ControlToValidate="DeletePassword" ValidationGroup="DeleteModal" ValidationExpression="(?!^\d+$)^.+$"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="DeletePasswordValidate" runat="server" ErrorMessage="Password cannot be blank" Font-Size="15px" ControlToValidate="DeletePassword" ValidationGroup="DeleteModal"></asp:RequiredFieldValidator>
                                            </div>
                                            <asp:Label ID="DeleteAccountInvalid" runat="server" Text="Username and/or Password incorrect" Style="font-size: 15px; color: red;" Visible="false"></asp:Label>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                            <asp:Button type="button" class="btn btn-primary" runat="server" Text="Delete" Style="font-size: 15px;" OnClick="Delete_Click" ValidationGroup="DeleteModal"></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal" id="sendMessageModal" tabindex="-1" role="dialog" aria-labelledby="sendMessageModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="sendMessageModalLabel" style="font-size: 15px;">Send Message</h5>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter Subject</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="Subject" class="form-control" placeholder="Enter subject" Style="font-size: 15px;" runat="server"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:RegularExpressionValidator ID="SubjectValidateType" runat="server" ErrorMessage="Subject cannot be an integer" Display="Dynamic" ControlToValidate="Subject" ValidationGroup="SendMessageModal" ValidationExpression="(?!^\d+$)^.+$"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="SubjectValidate" runat="server" ErrorMessage="Subject cannot be blank" Font-Size="15px" ControlToValidate="Subject" ValidationGroup="SendMessageModal"></asp:RequiredFieldValidator>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter Message</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="Message" class="form-control" placeholder="Enter message" TextMode="MultiLine" Rows="5" Columns="30" Style="font-size: 15px;" runat="server"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:RegularExpressionValidator ID="MessageValidateType" runat="server" ErrorMessage="Message cannot be an integer" Display="Dynamic" ControlToValidate="Message" ValidationGroup="SendMessageModal" ValidationExpression="(?!^\d+$)^.+$"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="MessageValidate" runat="server" ErrorMessage="Message cannot blank" Font-Size="15px" ControlToValidate="Message" ValidationGroup="SendMessageModal"></asp:RequiredFieldValidator>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter account username</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="Username" placeholder="Enter account username" runat="server" class="form-control" Style="font-size: 15px;" MaxLength="15"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:RegularExpressionValidator ID="UsernameValidateType" runat="server" ErrorMessage="Username cannot be an integer" Display="Dynamic" ControlToValidate="Username" ValidationGroup="SendMessageModal" ValidationExpression="(?!^\d+$)^.+$"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="UsernameValidate" runat="server" ErrorMessage="Username cannot be blank" ControlToValidate="Username" Font-Size="15px" ValidationGroup="SendMessageModal"></asp:RequiredFieldValidator>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter account password</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="Password" placeholder="Enter account password" type="password" runat="server" class="form-control" Style="font-size: 15px;" MaxLength="250"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:RegularExpressionValidator ID="PasswordValidateType" runat="server" ErrorMessage="Password cannot be an integer" Display="Dynamic" ControlToValidate="Password" ValidationGroup="SendMessageModal" ValidationExpression="(?!^\d+$)^.+$"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="PasswordValidate" runat="server" ErrorMessage="Password cannot be blank" Font-Size="15px" ControlToValidate="Password" ValidationGroup="SendMessageModal"></asp:RequiredFieldValidator>
                                            </div>
                                            <asp:Label ID="AccountInvalid" runat="server" Text="Username and/or Password incorrect" Style="font-size: 15px; color: red;" Visible="false"></asp:Label>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter email account username</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="EmailUsername" placeholder="Enter email account username" runat="server" class="form-control" Style="font-size: 15px;"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:RegularExpressionValidator ID="EmailValidate" runat="server" ErrorMessage="Not a valid email address" ValidationGroup="SendMessageModal" ControlToValidate="EmailUsername" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="EmailUsernameValidate" runat="server" ErrorMessage="Email username cannot be blank" Font-Size="15px" ControlToValidate="EmailUsername" ValidationGroup="SendMessageModal"></asp:RequiredFieldValidator>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter email account password</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="EmailPassword" placeholder="Enter email account password" type="password" runat="server" class="form-control" Style="font-size: 15px;"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:RegularExpressionValidator ID="EmailPasswordValidateType" runat="server" ErrorMessage="Email password cannot be an integer" Display="Dynamic" ControlToValidate="EmailPassword" ValidationGroup="SendMessageModal" ValidationExpression="(?!^\d+$)^.+$"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="EmailPasswordValidate" runat="server" ErrorMessage="Email Password cannot be blank" Font-Size="15px" ControlToValidate="EmailPassword" ValidationGroup="SendMessageModal"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                            <asp:Button type="button" class="btn btn-primary" runat="server" Text="Send" Style="font-size: 15px;" OnClick="Send_Click" ValidationGroup="SendMessageModal"></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="paginationDiv">
                    </div>
                </div>
            </div>
            <!--Footer-->
            <div class="footer">
                <UserControl:Footer runat="server" ID="Footer" />
            </div>
        </div>
    </form>
    <script type="text/javascript">
        function deleteClick(id) {
            var user = id.slice(id.lastIndexOf('_') + 1);
            $("#deleteValue").val(user);
        }
        function sendMessage(id) {
            var user = id.slice(id.lastIndexOf('_') + 1);
            $("#sendMessageVal").val(user);
        }
    </script>
</body>
</html>
