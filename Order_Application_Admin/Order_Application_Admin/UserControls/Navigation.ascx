<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navigation.ascx.cs" Inherits="Order_Application_Admin.UserControls.Navigation" %>
<div class="navigation-horizontal">
    <div class="row">
        <div class="col-md-2 col-lg-2 logo-image">
            <img src="../images/Logo.png" alt="Logo" style="width: 50px;" />
        </div>
        <div class="col-md-3 col-lg-3 offset-md-7 offset-md-7">
            <div>
                <div class="user-div" style="display: flex;">
                    <div>
                        <label style="font-size:15px;">Hi, <%= user %></label></div>
                    <div style="margin: 0% 1%; flex: 25%;">
                        <button type="button" class="user-icon">
                            <img src="" alt="user" /></button>
                    </div>
                </div>
                <div class="navigation-dropdown">
                    <div class="card">
                        <div class="card-body">
                            <a href="../SignOut.aspx">Sign Out</a>
                            <hr />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
