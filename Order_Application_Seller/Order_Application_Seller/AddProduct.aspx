<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Order_Application_Seller.AddProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Product</title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <link href="Content/Site.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/Site.js"></script>
    <link rel="icon" href="images/logo.ico" />
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
</head>
<body>
    <form id="AddItemForm" runat="server">
        <!-- Menu bar -->
        <div class="row">
            <div class="col-md-2 col-lg-2">
                <!-- Navigation-->
            </div>
            <div class="col-md-9 col-lg-9 addItemCard">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12 col-lg-12">
                                <h1>Add Product</h1>
                                <br />
                                <asp:Label ID="FormLoadError" runat="server" Text="" Visible="false"></asp:Label>
                                <div id="addItem">                                    
                                    <div class="row">
                                        <div class="col-md-2 col-lg-2">
                                            <asp:Label runat="server">Category</asp:Label>
                                        </div>
                                        <div class="col-md-4 col-lg-4">
                                            <asp:DropDownList ID="CategoryList" CssClass="form-control" runat="server" OnSelectedIndexChanged="CategorySelected" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-2 col-lg-2">
                                            <asp:Label runat="server">Sub Category</asp:Label>
                                        </div>
                                        <div class="col-md-4 col-lg-4">
                                            <asp:DropDownList ID="SubCategoryList" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-2 col-lg-2">
                                            <asp:Label runat="server">Name</asp:Label>
                                        </div>
                                        <div class="col-md-8 col-lg-8">
                                            <asp:TextBox ID="Name" placeholder="Enter name" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-2 col-lg-2">
                                            <asp:Label runat="server">Description</asp:Label>
                                        </div>
                                        <div class="col-md-8 col-lg-8">
                                            <asp:TextBox ID="Description" placeholder="Enter description" CssClass="form-control" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-2 col-lg-2">
                                            <asp:Label runat="server">Price</asp:Label>
                                        </div>
                                        <div class="col-md-8 col-lg-8">
                                            <asp:TextBox ID="Price" placeholder="Enter price" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-2 col-lg-2">
                                            <asp:Label runat="server">Quantity</asp:Label>
                                        </div>
                                        <div class="col-md-8 col-lg-8">
                                            <asp:TextBox ID="Quantity" placeholder="Enter quantity" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-2 col-lg-2">
                                            <asp:Label runat="server">Image</asp:Label>
                                        </div>
                                        <div class="col-md-4 col-lg-4">
                                            <asp:FileUpload ID="ImageFile" CssClass="form-control" runat="server" Style="height: 35px;" />
                                        </div>
                                        <div class="col-md-4 col-lg-4">
                                            <asp:Image ID="Image" Visible="false" runat="server" />
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-2 col-lg-2 offset-md-2 offset-lg-2">
                                            <asp:Button ID="AddItemBtn" runat="server" CssClass="btn btn-primary" Text="Add Item" />
                                            <br />
                                            <asp:Label ID="AddItemStatus" runat="server" Text="" Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
