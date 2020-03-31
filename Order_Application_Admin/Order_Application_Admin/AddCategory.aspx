﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="Order_Application_Admin.AddCategory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Category</title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <link rel="icon" href="images/logo.ico" />
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <style type="text/css">
        th {
            font-size: 15px;
            border: 1px solid #000000;
        }

        #manageCategoryHtml td {
            font-size: 15px;
            border: 1px solid #000000;
        }

            #manageCategoryHtml td input[type=button] {
                font-size: 15px;
            }
    </style>
</head>
<body>
    <form id="add_category" runat="server">
        <div>
            <!--Header Row -->
            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <!-- Vertical nav bar -->
                </div>
                <div class="col-md-10 col-lg-10">
                    <h3 style="font-size: 25px;">Add Category</h3>
                    <br />
                    <div class="card">
                        <div class="card-body">
                            <div class="row" style="padding: 10px 0px;">
                                <div class="col-md-2 col-lg-2" style="text-align: center;">
                                    <label style="font-size: 17px;">Category</label>
                                </div>
                                <div class="col-md-4 col-lg-4">
                                    <asp:TextBox ID="category" class="form-control" placeholder="Enter category name" Style="font-size: 15px;" runat="server"></asp:TextBox>
                                    <br />
                                    <label style="display: none; color: red; font-size: 15px;">Category name cannot be blank</label>
                                </div>
                            </div>
                            <div class="row" style="padding: 10px 0px;">
                                <div class="col-md-2 col-lg-2" style="text-align: center;">
                                    <label style="font-size: 17px;">Sub Category</label>
                                </div>
                                <div class="col-md-4 col-lg-4">
                                    <asp:TextBox ID="subcategory" class="form-control" placeholder="Enter subcategory name" Style="font-size: 15px;" runat="server"></asp:TextBox>
                                    <br />
                                    <label style="display: none; color: red; font-size: 15px;">Sub category name cannot be blank</label>
                                </div>
                                <div class="col-md-3 col-lg-3">
                                    <asp:Button ID="addcategory" class="btn btn-primary" type="Button" Text="Add Category" Style="font-size: 15px;" runat="server" OnClick="addcategory_Click"></asp:Button>
                                </div>
                            </div>
                            <div class="row">
                                <asp:Label ID="AddMessage" runat="server" Text="Label" style="font-size:15px;color:red;padding:0% 3%;" Visible="false"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <h3 style="font-size: 25px;">Manage Categories</h3>
                    <br />
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-1 offset-md-10 col-lg-1 offset-lg-10">
                                    <asp:Label Text="Filter" Style="font-size: 15px;" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-1 col-lg-1">
                                    <asp:DropDownList ID="FilterResults" Style="font-size: 15px;" class="form-control" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="manageCategoryHtml" style="margin: 4% 0%;" runat="server"></div>
                        </div>
                    </div>
                </div>
            </div>
            <!--Footer-->
            <div class="footer">
            </div>
        </div>
    </form>
</body>
</html>