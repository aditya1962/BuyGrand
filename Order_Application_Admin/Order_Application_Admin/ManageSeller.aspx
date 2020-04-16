<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageSeller.aspx.cs" Inherits="Order_Application_Admin.ManagerSeller" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Seller</title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
    <link rel="icon" href="images/logo.ico" />
    <script src="Scripts/jquery-3.4.1.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <style type="text/css">
        th
        {
            font-size:15px;
            border:1px solid #000000;
        }
        td
        {
            border:1px solid #000000;
            font-size:15px;
        }
        [type=button],label
        {
            font-size:15px;
        }
    </style>
</head>
<body>
    <form id="managerSeller" runat="server">
        <div>
            <!--Header Row -->
            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <!-- Vertical nav bar -->
                </div>
                <div class="col-md-10 col-lg-10">
                    <h3 style="font-size:25px;">Manage Sellers</h3>
                    <br />
                    <div class="card">
                        <div class="card-body">
                            <asp:Label ID="deleteSuccess" runat="server" Text="" Visible="false"></asp:Label>
                           <div id="manageSellerHtml" runat="server"></div>
                            <input type="hidden" id="deleteValue" value="" runat="server" />
                            <input type="hidden" id="sendMessageVal" value="" runat="server" />
                            <div class="modal" id="deleteModal" tabindex="-1" role="dialog" aria-labelledby="deleteModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="deleteModalLabel" style="font-size:15px;">Delete Seller</h5>
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
                                                    <asp:TextBox ID="DeleteUsername" placeholder="Enter account username" runat="server" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:Label ID="DeleteUsernameBlank" runat="server" Text="Username cannot be blank" style="font-size:15px;color:red;" Visible="false"></asp:Label>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter account password</label>
                                                </div>
                                                <div class="col-md-5 col-lg-5">
                                                    <asp:TextBox ID="DeletePassword" placeholder="Enter account password" type="password" runat="server" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                </div>
                                                <asp:Label ID="DeletePasswordBlank" runat="server" Text="Password cannot be blank" Style="font-size: 15px; color: red;" Visible="false"></asp:Label>
                                            </div>
                                            <asp:Label ID="DeleteAccountInvalid" runat="server" Text="Username and/or Password incorrect" Style="font-size: 15px; color: red;" Visible="false"></asp:Label>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                            <asp:button type="button" class="btn btn-primary" runat="server" Text="Delete" style="font-size:15px;" OnClick="Delete_Click"></asp:button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                             <div class="modal" id="sendMessageModal" tabindex="-1" role="dialog" aria-labelledby="sendMessageModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="sendMessageModalLabel" style="font-size:15px;">Send Message</h5>
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
                                                    <asp:TextBox ID="Subject" class="form-control" placeholder="Enter subject" style="font-size:15px;" runat="server"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:Label ID="SubjectBlank" runat="server" Text="Subject cannot be blank" style="color:red;" Visible="false"></asp:Label>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter Message</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="Message" class="form-control" placeholder="Enter message" textmode="MultiLine" Rows="5" Columns="30" style="font-size:15px;" runat="server"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:Label ID="MessageBlank" runat="server" Text="Message cannot be blank" style="color:red;" Visible="false"></asp:Label>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter account username</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="Username" placeholder="Enter account username" runat="server" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:Label ID="UsernameBlank" runat="server" Text="Username cannot be blank" style="font-size:15px;color:red;" Visible="false"></asp:Label>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter account password</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="Password" placeholder="Enter account password" type="password" runat="server" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                </div>
                                                <asp:Label ID="PasswordBlank" runat="server" Text="Password cannot be blank" Style="font-size: 15px; color: red;" Visible="false"></asp:Label>
                                            </div>
                                            <asp:Label ID="AccountInvalid" runat="server" Text="Username and/or Password incorrect" Style="font-size: 15px; color: red;" Visible="false"></asp:Label>
                                        <br />
                                        <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter email account username</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="EmailUsername" placeholder="Enter email account username" runat="server" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:Label ID="EmailUsernameBlank" runat="server" Text="Email Username cannot be blank" style="font-size:15px;color:red;" Visible="false"></asp:Label>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter email account password</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="EmailPassword" placeholder="Enter email account password" type="password" runat="server" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                </div>
                                                <asp:Label ID="EmailPasswordBlank" runat="server" Text="Email Password cannot be blank" Style="font-size: 15px; color: red;" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                            <asp:button type="button" class="btn btn-primary" runat="server" Text="Send" style="font-size:15px;" OnClick="Send_Click"></asp:button>
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
