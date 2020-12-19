<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Order_Application_Seller.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Register</title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <link href="Content/Site.css" rel="stylesheet" />
    <link rel="icon" href="images/logo.ico" />
    <script type="text/javascript" src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/Site.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
</head>
<body style="height:460px;">
    <form id="form1" runat="server">
        <div style="background-image:url(images/Background-Large.jpg);background-size:100%;
                    background-repeat:no-repeat; min-height:460px;">
            <div class="card register-card">
                <div class="card-body">
                    <div class="row">
                        <asp:Image ID="Logo" ImageUrl="~/images/Logo.png" AlternateText="Logo" runat="server" />
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3 col-lg-3">
                            <label style="font-size:15px;">Firstname</label>
                        </div>
                        <div class="col-md-9 col-lg-9">
                            <asp:TextBox ID="Firstname" CssClass="form-control" placeholder="Enter firstname" runat="server" style="font-size:15px;"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ID="FirstnameBlank" runat="server" ErrorMessage="Firstname cannot be blank" ControlToValidate="Firstname" ValidationGroup="UserValidationGroup" Font-Size="15px" BackColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="FirstnameType" runat="server" ErrorMessage="Firstname cannot be a number" Display="Dynamic" Font-Size="15px" ControlToValidate="Firstname" ValidationGroup="UserValidationGroup" ValidationExpression="(?!^\d+$)^.+$" BackColor="Red"></asp:RegularExpressionValidator>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3 col-lg-3">
                            <label style="font-size:15px;">Lastname</label>
                        </div>
                        <div class="col-md-9 col-lg-9">
                            <asp:TextBox ID="Lastname" CssClass="form-control" placeholder="Enter lastname" runat="server" style="font-size:15px;"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ID="LastnameBlank" runat="server" ErrorMessage="Lastname cannot be blank" ControlToValidate="Lastname" ValidationGroup="UserValidationGroup" Font-Size="15px" BackColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="LastnameType" runat="server" ErrorMessage="Lastname cannot be a number" Display="Dynamic" Font-Size="15px" ControlToValidate="Lastname" ValidationGroup="UserValidationGroup" ValidationExpression="(?!^\d+$)^.+$" BackColor="Red"></asp:RegularExpressionValidator>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3 col-lg-3">
                            <label style="font-size:15px;">Address</label>
                        </div>
                        <div class="col-md-9 col-lg-9">
                            <asp:TextBox ID="Address" CssClass="form-control" placeholder="Enter address" runat="server" style="font-size:15px;"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ID="AddressBlank" runat="server" ErrorMessage="Address cannot be blank" ControlToValidate="Address" ValidationGroup="UserValidationGroup" Font-Size="15px" BackColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="AddressType" runat="server" ErrorMessage="Address cannot be a number" Display="Dynamic" Font-Size="15px" ControlToValidate="Address" ValidationGroup="UserValidationGroup" ValidationExpression="(?!^\d+$)^.+$" BackColor="Red"></asp:RegularExpressionValidator>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3 col-lg-3">
                            <label style="font-size:15px;">Email Address</label>
                        </div>
                        <div class="col-md-9 col-lg-9">
                            <asp:TextBox ID="EmailAddress" CssClass="form-control" placeholder="Enter email address" runat="server" style="font-size:15px;"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ID="EmailAddressBlank" runat="server" ErrorMessage="Email Address cannot be blank" ControlToValidate="EmailAddress" ValidationGroup="UserValidationGroup" Font-Size="15px" BackColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="EmailAddressType" runat="server" ErrorMessage="Not a valid email address " Display="Dynamic" Font-Size="15px" ControlToValidate="EmailAddress" ValidationGroup="UserValidationGroup" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" BackColor="Red"></asp:RegularExpressionValidator>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3 col-lg-3">
                            <label style="font-size:15px;">Phone Number</label>
                        </div>
                        <div class="col-md-9 col-lg-9">
                            <asp:TextBox ID="PhoneNumber" CssClass="form-control" placeholder="Enter phone number" runat="server" style="font-size:15px;"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ID="PhoneNumberBlank" runat="server" ErrorMessage="Phone number cannot be blank" ControlToValidate="PhoneNumber" ValidationGroup="UserValidationGroup" Font-Size="15px" BackColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="PhoneNumberType" runat="server" ErrorMessage="Phone number cannot be text" Display="Dynamic" Font-Size="15px" ControlToValidate="PhoneNumber" ValidationGroup="UserValidationGroup" ValidationExpression="^[0-9]*$" BackColor="Red"></asp:RegularExpressionValidator>
                    </div>
                    <br />
                    <div class="row" style="padding:3% 0%;">
                        <div class="col-md-3 col-lg-3">
                            <label style="font-size:15px;">Gender</label>
                        </div>
                        <div class="col-md-9 col-lg-9">
                            <asp:RadioButtonList ID="GenderList" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Male" style="margin:0% 2%;">Male</asp:ListItem>
                                <asp:ListItem Value="Female" style="margin:0% 2%;">Female</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <br />
                    </div>
                    <br />
                    <div class="row" style="padding:3% 0%;">
                        <div class="col-md-3 col-lg-3">
                            <label style="font-size:15px;">Country</label>
                        </div>
                        <div class="col-md-9 col-lg-9">
                            <asp:DropDownList ID="Country" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                        </div>
                        <br />
                    </div>
                    <br />
                    <hr />
                     <div class="row">
                        <div class="col-md-3 col-lg-3">
                            <label style="font-size:15px;">Username</label>
                        </div>
                        <div class="col-md-9 col-lg-9">
                            <asp:TextBox ID="Username" CssClass="form-control" placeholder="Enter username" runat="server" style="font-size:15px;"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ID="UsernameBlank" runat="server" ErrorMessage="Username cannot be blank" ControlToValidate="Username" ValidationGroup="UserValidationGroup" Font-Size="15px" BackColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="UsernameType" runat="server" ErrorMessage="Username cannot be a number" Display="Dynamic" Font-Size="15px" ControlToValidate="Username" ValidationGroup="UserValidationGroup" ValidationExpression="(?!^\d+$)^.+$" BackColor="Red"></asp:RegularExpressionValidator>
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
                        <asp:RequiredFieldValidator ID="PasswordBlank" runat="server" ErrorMessage="Password cannot be blank" ControlToValidate="Password" ValidationGroup="UserValidationGroup" Font-Size="15px" BackColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="PasswordType" runat="server" ErrorMessage="Password cannot be a number" Display="Dynamic" Font-Size="15px" ControlToValidate="Password" ValidationGroup="UserValidationGroup" ValidationExpression="(?!^\d+$)^.+$" BackColor="Red"></asp:RegularExpressionValidator>
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
                        <asp:RequiredFieldValidator ID="ConfirmPasswordBlank" runat="server" ErrorMessage="Confirm password cannot be blank" ControlToValidate="ConfirmPassword" ValidationGroup="UserValidationGroup" Font-Size="15px" BackColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="ConfirmPasswordType" runat="server" ErrorMessage="Confirm password cannot be a number" Display="Dynamic" Font-Size="15px" ControlToValidate="ConfirmPassword" ValidationGroup="UserValidationGroup" ValidationExpression="(?!^\d+$)^.+$" BackColor="Red"></asp:RegularExpressionValidator>
                        <br />
                        <asp:CompareValidator ID="ConfirmPasswordEqual" runat="server" ErrorMessage="Password and confirm password must be equal" ControlToCompare="Password" ControlToValidate="ConfirmPassword" ValidationGroup="UserValidationGroup" BackColor="Red"></asp:CompareValidator>
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
                        <asp:RequiredFieldValidator ID="SecretAnswerBlank" runat="server" ErrorMessage="Secret answer cannot be blank" ControlToValidate="SecretAnswer" ValidationGroup="UserValidationGroup" Font-Size="15px" BackColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="SecretAnswerType" runat="server" ErrorMessage="Password cannot be a number" Display="Dynamic" Font-Size="15px" ControlToValidate="SecretAnswer" ValidationGroup="UserValidationGroup" ValidationExpression="(?!^\d+$)^.+$" BackColor="Red"></asp:RegularExpressionValidator>
                    </div>
                    <br />
                    <div class="row" style="margin:0% 45%;">
                        <asp:Button ID="RegisterButton" runat="server" Text="Register" CssClass="btn btn-primary" style="font-size:15px;"  ValidationGroup="UserValidationGroup" OnClick="RegisterButton_Click" />
                    </div>
                    <br />
                    <asp:Label ID="ValidationError" runat="server" Text="Username/Password already exists" Visible="false"></asp:Label>
					<asp:Label ID="RegisterStatus" runat="server" Text="" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
