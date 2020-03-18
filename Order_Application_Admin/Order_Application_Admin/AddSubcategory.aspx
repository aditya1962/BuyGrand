<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSubcategory.aspx.cs" Inherits="Order_Application_Admin.Add_Subcategories" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Subcategory</title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css"/>
    <link rel="icon" href="images/logo.ico" />
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <style type="text/css">
        th
        {
            font-size:15px;
            border:1px solid #000000;
        }
    </style>
</head>
<body>
    <form id="add_subcategory" runat="server">
        <div>
            <!--Header Row-->
            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <!--Vertical Menu -->
                </div>
                <div class="col-md-10 col-lg-10">
                    <h3 style="font-size:25px;">Add Sub Category</h3>
                    <br />
                    <div class="card">
                        <div class="card-body">
                            <div class="row" style="padding:10px 0px;">
                                <div class="col-md-2 col-lg-2" style="text-align:center;">
                                    <label style="font-size:17px;">Select Category</label>
                                </div>
                                <div class="col-md-4 col-lg-4">
                                    <asp:dropdownlist id="categorylist" name="category" class="form-control" style="font-size:15px;" runat="server">
                                    </asp:dropdownlist>
                                </div>
                            </div>
                            <br />
                            <div class="row" style="padding:10px 0px;">
                                <div class="col-md-2 col-lg-2" style="text-align:center;">
                                    <label style="font-size:17px;">Sub Category</label>
                                </div>
                                <div class="col-md-4 col-lg-4">
                                    <input type="text" name="subcategory" class="form-control" placeholder="Enter subcategory" style="font-size:15px;" />
                                </div>
                                <div class="col-md-3 col-lg-3">
                                   <asp:Button ID="addsubcategory" class="btn btn-primary" text="Add Sub Category" style="font-size:15px;" runat="server"></asp:Button>
                               </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <h3 style="font-size:25px;">Manage Sub Categories</h3> 
                    <br />
                    <div class="card">
                        <div class="card-body">
                            <div class="row" style="padding:10px 0px;">
                                <div class="col-md-2 col-lg-2" style="text-align:center;">
                                    <label style="font-size:17px;">Select Category</label>
                                </div>
                                <div class="col-md-4 col-lg-4">
                                    <asp:dropdownlist id="categorylist2" name="category2" class="form-control" style="font-size:15px;" runat="server">
                                    </asp:dropdownlist>
                                </div>
                                <div class="col-md-3 col-lg-3">
                                    <asp:Button ID="categorysearch" class="btn btn-primary" text="Search" style="font-size:15px;" runat="server"></asp:Button>
                                </div>
                            </div>
                            <br />
                            <div id="manageSubCategoryHtml" runat="server"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
