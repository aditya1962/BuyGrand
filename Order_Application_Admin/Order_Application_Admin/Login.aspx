<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Order_Application_Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <link href="Content/Site.css" rel="stylesheet" />
    <link rel="icon" href="images/logo.ico" />
    <script type="text/javascript" src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/Site.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="card login-card">
                <div class="card-body">
                    <div class="row">
                        <asp:Image ID="Logo" ImageUrl="~/images/Logo.png" AlternateText="Logo" runat="server" />
                    </div>
                    <br />
                    <div class="row" style="margin:5% 0% 0% 0%;">
                        <div class="col-md-3 col-lg-3">
                            <label style="font-size:15px;">Username</label>
                        </div>
                        <div class="col-md-9 col-lg-9">
                            <asp:TextBox ID="Username" CssClass="form-control" placeholder="Enter username" runat="server" style="font-size:15px;"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ID="UsernameBlank" runat="server" ErrorMessage="Username cannot be blank" ControlToValidate="Username" ValidationGroup="LoginValidationGroup" Font-Size="15px"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="UsernameType" runat="server" ErrorMessage="Username cannot be a number" Display="Dynamic" Font-Size="15px" ControlToValidate="Username" ValidationGroup="LoginValidationGroup" ValidationExpression="(?!^\d+$)^.+$"></asp:RegularExpressionValidator>
                    </div>
                    <br />
                    <div class="row" style="padding:0% 3%;">
                        <div class="col-md-3 col-lg-3">
                            <label style="font-size:15px;">Password</label>
                        </div>
                        <div class="col-md-9 col-lg-9">
                            <asp:TextBox ID="Password" CssClass="form-control" type="Password" placeholder="Enter password" runat="server" style="font-size:15px;"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ID="PasswordBlank" runat="server" ErrorMessage="Password cannot be blank" ControlToValidate="Password" ValidationGroup="LoginValidationGroup" Font-Size="15px"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="PasswordType" runat="server" ErrorMessage="Password cannot be a number" Display="Dynamic" Font-Size="15px" ControlToValidate="Password" ValidationGroup="LoginValidationGroup" ValidationExpression="(?!^\d+$)^.+$"></asp:RegularExpressionValidator>
                    </div>
                    <br />
                    <div class="row" style="margin:0% 45%;">
                        <asp:Button ID="LoginButton" runat="server" Text="Login" CssClass="btn btn-primary" style="font-size:15px;"  ValidationGroup="LoginValidationGroup" OnClick="LoginButton_Click" />
                    </div>
                    <br />
                    <asp:Label ID="ValidationError" runat="server" Text="Username/Password is incorrect" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
