<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navigation.ascx.cs" Inherits="Order_Application_Admin.UserControls.Navigation" %>
<noscript>
    <div class="noscriptdiv">
        <p> JavaScript must be enabled to make the site work properly</p>
    </div>
</noscript>
<script src="https://kit.fontawesome.com/06a6b398d6.js" crossorigin="anonymous"></script>
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.13.0/css/all.css" integrity="sha384-Bfad6CLCknfcloXFOyFnlgtENryhrpZCe29RTifKEixXQZ38WheV+i/6YWSzkz3V" crossorigin="anonymous">
<div class="navigation-horizontal">
    <div class="row">
        <div class="col-md-2 col-lg-2 logo-image">
            <a href="../Index.aspx"><img src="../images/Logo.png" alt="Logo" style="width: 90px;padding:3% 0% 0% 0%;" /></a>
        </div>
        <div class="col-md-3 col-lg-3 offset-md-7 offset-md-7">
            <div>
                <div class="user-div" style="display: flex;">
                    <div>
                        <label style="font-size:15px;">Hi, <%= user %></label></div>
                    <div style="margin: 0% 1%; flex: 25%;">
                        <button type="button" class="user-icon">
                            <i class="fa fa-caret-square-o-down" aria-hidden="true"></i></button>
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
