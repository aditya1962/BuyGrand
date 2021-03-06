﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="Order_Application_Admin.AddCategory" %>
<%@ Register TagPrefix="UserControl" TagName="NavigationVertical" Src="~/UserControls/VerticalNavigation.ascx" %>
<%@ Register TagPrefix="UserControl" TagName="NavigationHorizontal" Src="~/UserControls/Navigation.ascx" %>
<%@ Register Src="~/UserControls/Footer.ascx" TagPrefix="UserControl" TagName="Footer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Category</title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <link href="Content/Site.css" rel="stylesheet" />
    <link rel="icon" href="images/logo.ico" />
    <script type="text/javascript" src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/Site.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <style type="text/css">       
        .category-values
        {
            font-size: 15px;
            border: 1px solid #000000;
        }

        #manageCategoryHtml td input[type=button]
        {
                font-size: 15px;
        }
    </style>
</head>
<body>
    <form id="add_category" runat="server">
        <div>
            <UserControl:NavigationHorizontal runat="server"></UserControl:NavigationHorizontal>
            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <UserControl:NavigationVertical runat="server"></UserControl:NavigationVertical>
                </div>
                <div class="col-md-9 col-lg-9 content">
                    <h3 style="font-size: 25px;">Add Category</h3>
                    <br />
                    <div class="card">
                        <div class="card-body">
                            <div class="row" style="padding: 10px 0px;">
                                <div class="col-md-2 col-lg-2" style="padding:0% 2%;">
                                    <label style="font-size: 17px;">Category</label>
                                </div>
                                <div class="col-md-4 col-lg-4">
                                    <asp:TextBox ID="category" class="form-control" placeholder="Enter category name" Style="font-size: 15px;" runat="server" MaxLength="100"></asp:TextBox>
                                </div>
                                <div class="col-md-5 col-lg-5 offset-md-1 offset-lg-1">
                                    <asp:RequiredFieldValidator ID="CategoryBlank" runat="server" ErrorMessage="Category cannot be blank" ValidationGroup="AddCategory" ControlToValidate="category"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="CategoryType" runat="server" ErrorMessage="Category cannot be a number" ControlToValidate="category" ValidationGroup="AddCategory" ValidationExpression="(?!^\d+$)^.+$" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <br />
                            <div class="row" style="padding: 10px 0px;">
                                <div class="col-md-2 col-lg-2" style="padding:0% 2%;">
                                    <label style="font-size: 17px; ">Sub Category</label>
                                </div>
                                <div class="col-md-4 col-lg-4">
                                    <asp:TextBox ID="subcategory" class="form-control" placeholder="Enter subcategory name" Style="font-size: 15px;" runat="server" MaxLength="100"></asp:TextBox>
                                </div>
                                <div class="col-md-5 col-lg-5 offset-md-1 offset-lg-1">
                                    <asp:RequiredFieldValidator ID="SubCategoryBlank" runat="server" ErrorMessage="Sub category cannot be blank" ControlToValidate="subcategory" ValidationGroup="AddCategory"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="SubCategoryType" runat="server" ErrorMessage="Sub category cannot be a number" Display="Dynamic" ControlToValidate="subcategory" ValidationExpression="(?!^\d+$)^.+$" ValidationGroup="AddCategory"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-3 col-lg-3 offset-md-2 offset-lg-2">
                                    <asp:Button ID="addcategory" class="btn btn-primary" type="Button" Text="Add Category" Style="font-size: 15px;" runat="server" OnClick="addcategory_Click" ValidationGroup="AddCategory"></asp:Button>
                                </div>
                            </div>
                            <div class="row">
                                <asp:Label ID="AddMessage" runat="server" Text="Label" Style="font-size: 15px; color: red; padding: 0% 3%;" Visible="false"></asp:Label>
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
                                <div class="col-md-1 offset-md-9 col-lg-1 offset-lg-9">
                                    <asp:Label Text="Filter" Style="font-size: 15px;" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-2 col-lg-2">
                                    <asp:DropDownList ID="FilterResults" Style="font-size: 15px;" class="form-control" runat="server" OnSelectedIndexChanged="FilterResults_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <asp:Label ID="UpdateSuccess" runat="server" Text="Updated Successfully" Visible="false"></asp:Label>
                            <br />
                            <div id="manageCategoryHtml" style="margin: 2% 0%;" runat="server"></div>
                            <br />
                            <div id="paginationDiv" runat="server"></div>
                            <div class="modal" id="editModal" tabindex="-1" role="dialog" aria-labelledby="editModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content" id="EditCategory">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="editModalLabel" style="font-size:15px;">Edit Category</h5>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Category Name</label>
                                                </div>
                                                <div class="col-md-5 col-lg-5">
                                                    <asp:TextBox ID="EditCategoryName" placeholder="Enter category name" runat="server" class="form-control" style="font-size:15px;" MaxLength="100"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:RequiredFieldValidator ID="EditCategoryBlank" runat="server" ErrorMessage="Category name cannot be blank" ControlToValidate="EditCategoryName" ValidationGroup="EditCategory"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RegularExpressionValidator ID="EditCategoryType" runat="server" ErrorMessage="Category name cannot be a number" ControlToValidate="EditCategoryName" Display="Dynamic" ValidationGroup="EditCategory" ValidationExpression="(?!^\d+$)^.+$"></asp:RegularExpressionValidator>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter account username</label>
                                                </div>
                                                <div class="col-md-5 col-lg-5">
                                                    <asp:TextBox ID="EditUsername" placeholder="Enter account username" runat="server" class="form-control" style="font-size:15px;" MaxLength="15"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:RequiredFieldValidator ID="EditUsernameBlank" runat="server" ErrorMessage="Username cannot be blank" ControlToValidate="EditUsername" ValidationGroup="EditCategory"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RegularExpressionValidator ID="EditUsernameType" runat="server" ErrorMessage="Username cannot be a number" Display="Dynamic" ControlToValidate="EditUsername" ValidationGroup="EditCategory" ValidationExpression="(?!^\d+$)^.+$"></asp:RegularExpressionValidator>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter account password</label>
                                                </div>
                                                <div class="col-md-5 col-lg-5">
                                                    <asp:TextBox ID="EditPassword" placeholder="Enter account password" type="password" runat="server" class="form-control" style="font-size:15px;" MaxLength="250"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:RequiredFieldValidator ID="EditPasswordBlank" runat="server" ErrorMessage="Password cannot be blank" ControlToValidate="EditPassword" ValidationGroup="EditCategory"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RegularExpressionValidator ID="EditPasswordType" runat="server" ErrorMessage="Password cannot be a number" Display="Dynamic" ControlToValidate="EditPassword" ValidationExpression="(?!^\d+$)^.+$" ValidationGroup="EditCategory"></asp:RegularExpressionValidator>
                                            </div>
                                            <asp:Label ID="EditAccountInvalid" runat="server" Text="Username and/or Password incorrect" Style="font-size: 15px; color: red;" Visible="false"></asp:Label>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                            <asp:button type="button" class="btn btn-primary" runat="server" Text="Update" style="font-size:15px;" OnClick="Edit_Click" ValidationGroup="EditCategory"></asp:button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:HiddenField id="editValue" value="0" runat="server"></asp:HiddenField>
                            <div class="modal" id="deleteModal" tabindex="-1" role="dialog" aria-labelledby="deleteModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="deleteModalLabel" style="font-size:15px;">Delete Category</h5>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                            <label>Are you sure you want to delete the category?</label>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter account username</label>
                                                </div>
                                                <div class="col-md-5 col-lg-5">
                                                    <asp:TextBox ID="DeleteUsername" placeholder="Enter account username" runat="server" class="form-control" style="font-size:15px;" MaxLength="15"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:RequiredFieldValidator ID="DeleteUsernameBlank" runat="server" ErrorMessage="Username cannot be blank" ControlToValidate="DeleteUsername" ValidationGroup="DeleteCategory"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RegularExpressionValidator ID="DeleteUsernameType" runat="server" ErrorMessage="Username cannot be a number" ControlToValidate="DeleteUsername" ValidationGroup="DeleteCategory" ValidationExpression="(?!^\d+$)^.+$" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter account password</label>
                                                </div>
                                                <div class="col-md-5 col-lg-5">
                                                    <asp:TextBox ID="DeletePassword" placeholder="Enter account password" type="password" runat="server" class="form-control" style="font-size:15px;" MaxLength="250"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:RequiredFieldValidator ID="DeletePasswordBlank" runat="server" ErrorMessage="Password cannot be blank" ControlToValidate="DeletePassword" ValidationGroup="DeleteCategory"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RegularExpressionValidator ID="DeletePasswordType" runat="server" ErrorMessage="Password cannot be a number" ControlToValidate="DeletePassword" Display="Dynamic" ValidationExpression="(?!^\d+$)^.+$" ValidationGroup="DeleteCategory"></asp:RegularExpressionValidator>
                                            </div>
                                            <asp:Label ID="DeleteAccountInvalid" runat="server" Text="Username and/or Password incorrect" Style="font-size: 15px; color: red;" Visible="false"></asp:Label>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                            <asp:button type="button" class="btn btn-primary" runat="server" Text="Delete" style="font-size:15px;" OnClick="Delete_Click" ValidationGroup="DeleteCategory"></asp:button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:HiddenField id="deleteValue" value="0" runat="server"></asp:HiddenField>
                            <div class="modal" id="subcategoryModal" tabindex="-1" role="dialog" aria-labelledby="subcategoryModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="subcategoryModalLabel" style="font-size:15px;">Subcategories</h5>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                            <p id="subcategoryList"></p>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:HiddenField id="subcategoryValue" value="0" runat="server"></asp:HiddenField>
                        </div>
                    </div>
                </div>
            </div>
            <!--Footer-->
            <div class="footer">
                <UserControl:Footer runat="server" id="Footer" />
            </div>
        </div>
    </form>
    <script type="text/javascript">
        function editClick(id) {
            var categoryID = id.slice(id.lastIndexOf('_') + 1);
            $("#editValue").val(categoryID);
        }
        function deleteClick(id) {
            var categoryID = id.slice(id.lastIndexOf('_') + 1);
            $("#deleteValue").val(categoryID);
        }
        function subcategoryClick(category) {
            $.ajax({
                url: "Data/ViewSubcategories.aspx",
                dataType: "json",
                data: {categoryName:category},
                method: "get",
                contentType: "application/json",                
                success: function (data) {
                    let subcategories = "<ul>";
                    data.forEach(function (item) {
                        subcategories += "<li> " + item + "</li>";
                    })
                    subcategories += "</ul>";
                    $("#subcategoryList").html(subcategories);
                },
                error: function (err) {
                    console.log(err.responseText);
                }
            })
        }
    </script>
</body>
</html>
