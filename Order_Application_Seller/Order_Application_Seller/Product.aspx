<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Order_Application_Seller.Product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Product</title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <link href="Content/Site.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/jquery-3.4.1.js"></script>
    <script type="text/javascript" src="Scripts/Site.js"></script>
    <script type="text/javascript" src="Scripts/product.js"></script>
    <link rel="icon" href="images/logo.ico" />

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
                        <asp:HiddenField ID="ProductValue" ClientIDMode="Static" runat="server" />
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
                                            <asp:HyperLink ID="Category" runat="server"><%= productCategory %></asp:HyperLink>
                                            <asp:Label ID="Label1" runat="server" Text=">"></asp:Label>
                                            <asp:HyperLink ID="Subcategory" runat="server"><%=productSubcategory %></asp:HyperLink>
                                        </div>
                                        <div class="col-md-2 col-lg-2">
                                            <asp:Label ID="ItemPriceLbl" runat="server" Text="Price" Font-Bold="True"></asp:Label>
                                        </div>
                                        <div class="col-md-4 col-lg-4">
                                            <asp:Label ID="ItemPrice" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-md-2 col-lg-2">
                                            <asp:Label ID="ItemRatingLbl" runat="server" Text="Rating" Font-Bold="True"></asp:Label>
                                        </div>
                                        <div class="col-md-4 col-lg-4">
                                            <asp:Label ID="ItemRating" runat="server"></asp:Label>
                                        </div>
                                        <asp:Label ID="RatingError" runat="server" Text="" ForeColor="Red" Visible="False"></asp:Label>
                                        <br />
                                        <div class="col-md-2 col-lg-2">
                                            <asp:Label ID="ItemQuantityAvailable" runat="server" Text="Quantity Available" Font-Bold="True"></asp:Label>
                                        </div>
                                        <div class="col-md-4 col-lg-4">
                                            <asp:Label ID="Quantity" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-md-2 col-lg-2">
                                            <asp:Label ID="ItemOrderCount" runat="server" Text="Order Count" Font-Bold="True"></asp:Label>
                                        </div>
                                        <div class="col-md-4 col-lg-4">
                                            <asp:Label ID="OrderCount" runat="server"></asp:Label>
                                        </div>
                                        <br />
                                        <div class="col-md-2 col-lg-2">
                                            <asp:Label ID="ItemDiscountLbl" runat="server" Text="Discount" Font-Bold="True"></asp:Label>
                                        </div>
                                        <div class="col-md-10 col-lg-10">
                                            <asp:Label ID="ItemDiscount" runat="server"></asp:Label>
                                        </div>
                                        <br />
                                        <div id="ManageItem" runat="server">
                                            <button class="btn btn-success" style="margin-left: 0px;" type="button" data-toggle="modal" data-target="#editProductModal">Edit</button>
                                            <button class="btn btn-danger" data-toggle="modal" type="button" data-target="#deleteModal">Delete</button>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 col-lg-12">
                                    <asp:Label ID="DescriptionLabel" runat="server"></asp:Label>
                                </div>
                            </div>
                            <br />
                        </div>
                        <br />
                        <h2>Customer Feedbacks</h2>
                        <br />
                        <textarea id="Review" placeholder="Enter Review" class="form-control" rows="5"></textarea>
                        <br />
                        <button class="btn btn-primary" onclick="addReview()" type="button">Comment </button>
                        <br />
                        <div id="reviewDiv" runat="server">
                            <asp:PlaceHolder ID="ReviewsPlaceHolder" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal" id="editProductModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document" style="max-width:600px; font-size:15px;">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="editProductLabel">Edit Product</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div id="EditItemFormDiv" runat="server">
                            <div class="row">
                                <div class="col-md-2 col-lg-2">
                                    <asp:Label runat="server">Category</asp:Label>
                                </div>
                                <div class="col-md-8 col-lg-8">
                                    <asp:DropDownList ID="CategoryDropdown" CssClass="form-control" runat="server" OnSelectedIndexChanged="CategorySelected" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-2 col-lg-2">
                                    <asp:Label runat="server">Sub Category</asp:Label>
                                </div>
                                <div class="col-md-8 col-lg-8">
                                    <asp:DropDownList ID="SubcategoryDropdown" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-2 col-lg-2">
                                    <asp:Label runat="server">Name</asp:Label>
                                </div>
                                <div class="col-md-8 col-lg-8">
                                    <asp:TextBox ID="EditName" placeholder="Enter name" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="NameValidate" runat="server" ErrorMessage="Name cannot be empty" ControlToValidate="EditName" ForeColor="Red" ValidationGroup="AddItemValidate"></asp:RequiredFieldValidator><br />
                                    <asp:RegularExpressionValidator ID="NameNum" runat="server" ErrorMessage="Name cannot be a number" ControlToValidate="EditName" ForeColor="Red" ValidationExpression="(?!^\d+$)^.+$" ValidationGroup="AddItemValidate"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-2 col-lg-2">
                                    <asp:Label runat="server">Description</asp:Label>
                                </div>
                                <div class="col-md-8 col-lg-8">
                                    <asp:TextBox ID="EditDescription" placeholder="Enter description" CssClass="form-control" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="DescriptionValidate" runat="server" ErrorMessage="Description cannot be empty" ControlToValidate="EditDescription" ForeColor="Red" ValidationGroup="AddItemValidate"></asp:RequiredFieldValidator><br />
                                    <asp:RegularExpressionValidator ID="DescriptionNum" runat="server" ErrorMessage="Description cannot be a number" ControlToValidate="EditDescription" ForeColor="Red" ValidationExpression="(?!^\d+$)^.+$" ValidationGroup="AddItemValidate"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-2 col-lg-2">
                                    <asp:Label runat="server">Price</asp:Label>
                                </div>
                                <div class="col-md-8 col-lg-8">
                                    <asp:TextBox ID="EditPrice" placeholder="Enter price" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PriceValidate" runat="server" ErrorMessage="Price cannot be empty" ControlToValidate="EditPrice" ForeColor="Red" ValidationGroup="AddItemValidate"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-2 col-lg-2">
                                    <asp:Label runat="server">Quantity</asp:Label>
                                </div>
                                <div class="col-md-8 col-lg-8">
                                    <asp:TextBox ID="EditQuantity" placeholder="Enter quantity" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="QuantityValidate" runat="server" ErrorMessage="Quantity cannot be empty" ControlToValidate="EditQuantity" ForeColor="Red" ValidationGroup="AddItemValidate"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-2 col-lg-2">
                                    <asp:Label runat="server">Image</asp:Label>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <asp:FileUpload ID="ImageFile" CssClass="form-control" runat="server" Style="height: 35px;" />
                                    <asp:Label ID="FileError" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-md-4 col-lg-4">
                                    <asp:Image ID="Image" runat="server" Width="200px" />
                                </div>
                            </div>
                            <br />
                            <br />
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal" style="font-size:15px;">Close</button>
                        <button type="button" class="btn btn-primary" style="font-size:15px;">Update</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal" id="deleteModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="deleteProductLabel">Delete Product</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="Label2" runat="server" Text="Are you sure you want to delete the product?" Font-Size="15px"></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal" style="font-size:15px;">Close</button>
                        <button type="button" class="btn btn-primary" style="font-size:15px;">Delete</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript" src="Scripts/bootstrap.js"></script> 
</body>
</html>
