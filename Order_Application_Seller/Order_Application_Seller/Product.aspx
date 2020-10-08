﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Order_Application_Seller.Product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Product</title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <link href="Content/Site.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/Site.js"></script>
    <link rel="icon" href="images/logo.ico" />
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
</head>
<body>
     <form id="ViewProductForm" runat="server">
        <!-- Menu bar -->
        <div class="row">
            <div class="col-md-2 col-lg-2">
                <!-- Navigation-->
            </div>
            <div class="col-md-9 col-lg-9 viewProductCard">
                <div class="card product">
                    <div class="card-body">                        
                        <div id="itemDiv" runat="server">
                            <div class="row">
                                <div class="col-md-4 col-lg-4">
                                    <asp:Image ID="ItemImage" AlternateText="Item Image" runat="server" Height="400px" />
                                </div>
                                <div class="col-md-7 col-lg-7 offset-md-1 offset-lg-1">
                                    <div class="row itemRows">
                                        <div class="col-md-12 col-lg-12">
                                            <asp:Label ID="ItemName" runat="server" Text="Item Name" Font-Bold="True"></asp:Label>
                                        </div>
                                        <br />
                                        <div class="col-md-12 col-lg-12 CategoryLink">
                                            <asp:HyperLink ID="Category" runat="server">Category</asp:HyperLink>
                                            <asp:Label ID="Label1" runat="server" Text=">"></asp:Label>
                                            <asp:HyperLink ID="Subcategory" runat="server">Sub Category</asp:HyperLink>
                                        </div>
                                        <div class="col-md-2 col-lg-2">
                                            <asp:Label ID="ItemPriceLbl" runat="server" Text="Price" Font-Bold="True"></asp:Label>
                                        </div>
                                        <div class="col-md-4 col-lg-4">
                                            <asp:Label ID="ItemPrice" runat="server" Text="Item Price"></asp:Label>
                                        </div>
                                        <div class="col-md-2 col-lg-2">
                                            <asp:Label ID="ItemRatingLbl" runat="server" Text="Rating" Font-Bold="True"></asp:Label>
                                        </div>
                                        <div class="col-md-4 col-lg-4">
                                            <asp:Label ID="ItemRating" runat="server" Text="Item Rating"></asp:Label>
                                        </div>
                                        <br />
                                        <div class="col-md-2 col-lg-2">
                                            <asp:Label ID="ItemQuantityAvailable" runat="server" Text="Quantity Available" Font-Bold="True"></asp:Label>
                                        </div>
                                        <div class="col-md-4 col-lg-4">
                                            <asp:Label ID="Quantity" runat="server" Text="Quantity"></asp:Label>
                                        </div>
                                        <div class="col-md-2 col-lg-2">
                                            <asp:Label ID="ItemOrderCount" runat="server" Text="Order Count" Font-Bold="True"></asp:Label>
                                        </div>
                                        <div class="col-md-4 col-lg-4">
                                            <asp:Label ID="OrderCount" runat="server" Text="Orders"></asp:Label>
                                        </div>
                                        <br />
                                        <div class="col-md-2 col-lg-2">
                                            <asp:Label ID="ItemDiscountLbl" runat="server" Text="Discount" Font-Bold="True"></asp:Label>
                                        </div>
                                        <div class="col-md-10 col-lg-10">
                                            <asp:Label ID="ItemDiscount" runat="server" Text="Item Discount"></asp:Label>
                                        </div>
                                        <br />
                                        <div id="ManageItem" runat="server">
                                            <button class="btn btn-success" style="margin-left:0px;">Edit</button>
                                            <button class="btn btn-danger">Delete</button>
                                        </div>
                                        <div class="col-md-12 col-lg-12">
                                            <asp:Label ID="Description" runat="server" Text="Description"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            
                        </div>  
                        <br />
                        <h2>Customer Feedbacks</h2>
                        <br />
                        <div id="reviewDiv" runat="server">

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>