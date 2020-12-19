<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Order_Application_Seller.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Forgot Password</title>
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
        <div style="background-image:url(images/Background-Large.jpg);background-size:100%;
                    background-repeat:no-repeat; min-height:460px;">
            <div class="card forgot-card">
                <div class="card-body">
                    <div class="row">
                        <asp:Image ID="Logo" ImageUrl="~/images/Logo.png" AlternateText="Logo" runat="server" />
                    </div>
                    <br />                    
                     <div class="row">
                        <div class="col-md-3 col-lg-3">
                            <label style="font-size:15px;">Username</label>
                        </div>
                        <div class="col-md-9 col-lg-9">
                            <asp:TextBox ID="Username" CssClass="form-control" placeholder="Enter username" runat="server" style="font-size:15px;"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ID="UsernameBlank" runat="server" ErrorMessage="Username cannot be blank" ControlToValidate="Username" ValidationGroup="UserValidationGroup" Font-Size="15px"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="UsernameType" runat="server" ErrorMessage="Username cannot be a number" Display="Dynamic" Font-Size="15px" ControlToValidate="Username" ValidationGroup="UserValidationGroup" ValidationExpression="(?!^\d+$)^.+$"></asp:RegularExpressionValidator>
                    </div>
                    <br />
                    <div class="row" style="padding:3% 0%;">
                        <div class="col-md-3 col-lg-3">
                            <label style="font-size:15px;">Password</label>
                        </div>
                        <div class="col-md-9 col-lg-9">
                            <asp:TextBox ID="Password" CssClass="form-control" type="Password" placeholder="Enter password" runat="server" style="font-size:15px;"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ID="PasswordBlank" runat="server" ErrorMessage="Password cannot be blank" ControlToValidate="Password" ValidationGroup="UserValidationGroup" Font-Size="15px"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="PasswordType" runat="server" ErrorMessage="Password cannot be a number" Display="Dynamic" Font-Size="15px" ControlToValidate="Password" ValidationGroup="UserValidationGroup" ValidationExpression="(?!^\d+$)^.+$"></asp:RegularExpressionValidator>
                    </div>
                    <br />
                    <div class="row" style="padding:3% 0%;">
                        <div class="col-md-3 col-lg-3">
                            <label style="font-size:15px;">Confirm Password</label>
                        </div>
                        <div class="col-md-9 col-lg-9">
                            <asp:TextBox ID="ConfirmPassword" CssClass="form-control" type="Password" placeholder="Confirm password" runat="server" style="font-size:15px;"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ID="ConfirmPasswordBlank" runat="server" ErrorMessage="Confirm password cannot be blank" ControlToValidate="ConfirmPassword" ValidationGroup="UserValidationGroup" Font-Size="15px"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="ConfirmPasswordType" runat="server" ErrorMessage="Confirm password cannot be a number" Display="Dynamic" Font-Size="15px" ControlToValidate="ConfirmPassword" ValidationGroup="UserValidationGroup" ValidationExpression="(?!^\d+$)^.+$"></asp:RegularExpressionValidator>
                        <br />
                        <asp:CompareValidator ID="ConfirmPasswordEqual" runat="server" ErrorMessage="Password and confirm password must be equal" ControlToCompare="Password" ControlToValidate="ConfirmPassword" ValidationGroup="UserValidationGroup"></asp:CompareValidator>
                    </div>
                    <br />
                    <div class="row" style="padding:3% 0%;">
                        <div class="col-md-3 col-lg-3">
                            <label style="font-size:15px;">Secret Question</label>
                        </div>
                        <div class="col-md-9 col-lg-9">
                            <asp:DropDownList ID="SecretQuestion" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                        </div>
                        <br />
                    </div>
                    <br />
                    <div class="row" style="padding:3% 0%;">
                        <div class="col-md-3 col-lg-3">
                            <label style="font-size:15px;">Secret Answer</label>
                        </div>
                        <div class="col-md-9 col-lg-9">
                            <asp:TextBox ID="SecretAnswer" CssClass="form-control" placeholder="Enter secret answer" runat="server" style="font-size:15px;"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ID="SecretAnswerBlank" runat="server" ErrorMessage="Secret answer cannot be blank" ControlToValidate="SecretAnswer" ValidationGroup="UserValidationGroup" Font-Size="15px"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="SecretAnswerType" runat="server" ErrorMessage="Password cannot be a number" Display="Dynamic" Font-Size="15px" ControlToValidate="SecretAnswer" ValidationGroup="UserValidationGroup" ValidationExpression="(?!^\d+$)^.+$"></asp:RegularExpressionValidator>
                    </div>
                    <br />
                    <div class="row" style="margin:0% 45%;">
                        <asp:Button ID="ForgotPasswordButton" runat="server" Text="Update" CssClass="btn btn-primary" style="font-size:15px;"  ValidationGroup="UserValidationGroup" OnClick="ForgotButton_Click" />
                    </div>
                    <br />
                    <asp:Label ID="ValidationError" runat="server" Text="Username/Password does not exists" Visible="false"></asp:Label>
					<asp:Label ID="ForgotStatus" runat="server" Text="" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

