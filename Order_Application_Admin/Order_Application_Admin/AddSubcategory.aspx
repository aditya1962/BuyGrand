<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSubcategory.aspx.cs" Inherits="Order_Application_Admin.Add_Subcategories" %>
<%@ Register TagPrefix="UserControl" TagName="NavigationVertical" Src="~/UserControls/VerticalNavigation.ascx" %>
<%@ Register TagPrefix="UserControl" TagName="NavigationHorizontal" Src="~/UserControls/Navigation.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Subcategory</title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css"/>
    <link href="Content/Site.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/Site.js"></script>
    <link rel="icon" href="images/logo.ico" />
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <style type="text/css">
        th
        {
            font-size:15px;
            border:1px solid #000000;
        }
        td
        {
           border:1px solid #000000;
           font-size:15px;
        }
        [type=button]
        {
            font-size:15px;
        }
        button, label, input[type=text]
        {
            font-size:15px;
        }
    </style>
</head>
<body>
    <form id="add_subcategory" runat="server">
        <div>
            <UserControl:NavigationHorizontal runat="server"></UserControl:NavigationHorizontal>
            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <UserControl:NavigationVertical runat="server"></UserControl:NavigationVertical>
                </div>
                <div class="col-md-9 col-lg-9">
                    <h3 style="font-size:25px;">Add Sub Category</h3>
                    <br />
                    <div class="card">
                        <div class="card-body">
                            <div class="row" style="padding:10px 0px;">
                                <div class="col-md-2 col-lg-2" style="text-align:center;">
                                    <label>Select Category</label>
                                </div>
                                <div class="col-md-4 col-lg-4">
                                    <asp:dropdownlist id="categorylist" name="category" class="form-control" style="font-size:15px;" runat="server">
                                    </asp:dropdownlist>
                                </div>
                            </div>
                            <br />
                            <div class="row" style="padding:10px 0px;">
                                <div class="col-md-2 col-lg-2" style="text-align:center;">
                                    <label>Sub Category</label>
                                </div>
                                <div class="col-md-4 col-lg-4">
                                    <asp:TextBox ID="subcategory" class="form-control" placeholder="Enter subcategory" style="font-size:15px;" runat="server"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="SubCategoryBlank" runat="server" ErrorMessage="Sub category cannot be blank" ControlToValidate="subcategory" ValidationGroup="AddSubcategory" Font-Size="15px"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="SubCategoryType" runat="server" ErrorMessage="Sub category cannot be a number" Display="Dynamic" ControlToValidate="subcategory" ValidationGroup="AddSubcategory" ValidationExpression="(?!^\d+$)^.+$" Font-Size="15px"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-md-3 col-lg-3">
                                   <asp:Button ID="addsubcategory" class="btn btn-primary" text="Add Sub Category" style="font-size:15px;" runat="server" OnClick="addsubcategory_Click" ValidationGroup="AddSubcategory"></asp:Button>
                               </div>
                                <asp:Label ID="AddStatus" runat="server" Text="" Visible="false" style="color:red; font-size:15px;"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <h3 style="font-size:25px;">Manage Sub Categories</h3> 
                    <br />
                    <div class="card">
                        <div class="card-body">
                            <asp:Label ID="SubcategoryUpdate" runat="server" Text="" style="font-size:15px;" visible="false"></asp:Label>
                            <div class="row" style="padding:10px 0px;">
                                <div class="col-md-2 col-lg-2" style="text-align:center;">
                                    <label>Select Category</label>
                                </div>
                                <div class="col-md-3 col-lg-3">
                                    <asp:dropdownlist id="categorylist2" name="category2" class="form-control" style="font-size:15px;" runat="server">
                                    </asp:dropdownlist>
                                </div>
                                <div class="col-md-2 col-lg-2">
                                    <asp:Button ID="categorysearch" class="btn btn-primary" text="Search" style="font-size:15px;" runat="server" OnClick="categorysearch_Click"></asp:Button>
                                </div>
                                <div class="col-md-1 col-lg-1 offset-md-1 offset-lg-1">
                                    <label>Filter </label>
                                </div>
                                <div class="col-md-2 col-lg-2">
                                    <asp:DropDownList runat="server" ID="Filter" CssClass="form-control" style="width:100%;font-size:15px;"></asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div id="manageSubCategoryHtml" runat="server"></div>
                            <div class="modal" id="editModal" tabindex="-1" role="dialog" aria-labelledby="editModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="editModalLabel" style="font-size:15px;">Edit Category</h5>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Sub Category Name</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="EditSubCategoryName" placeholder="Enter Sub category name" runat="server" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="EditNameBlank" runat="server" ErrorMessage="Subcategory cannot be blank" ControlToValidate="EditSubcategoryName" ValidationGroup="EditSubcategory" Font-Size="15px"></asp:RequiredFieldValidator>
                                                    <br />
                                                    <asp:RegularExpressionValidator ID="EditNameType" runat="server" ErrorMessage="Subcategory cannot be a number" ValidationExpression="(?!^\d+$)^.+$" ValidationGroup="EditSubcategory" Display="Dynamic" ControlToValidate="EditSubCategoryName" Font-Size="15px"></asp:RegularExpressionValidator>
                                                </div>                                   
                                                <br />
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter account username</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="EditUsername" placeholder="Enter account username" runat="server" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="EditUsernameBlank" runat="server" ErrorMessage="Username cannot be blank" ControlToValidate="EditUsername" ValidationGroup="EditSubcategory" Font-Size="15px"></asp:RequiredFieldValidator>
                                                    <br />
                                                    <asp:RegularExpressionValidator ID="EditUsernameType" runat="server" ErrorMessage="Username cannot be a number" Display="Dynamic" ControlToValidate="EditUsername" ValidationExpression="(?!^\d+$)^.+$" ValidationGroup="EditSubcategory" Font-Size="15px"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter account password</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="EditPassword" placeholder="Enter account password" type="password" runat="server" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="EditPasswordBlank" runat="server" ErrorMessage="Password cannot be blank" ControlToValidate="EditPassword" ValidationGroup="EditSubcategory" Font-Size="15px"></asp:RequiredFieldValidator>
                                                    <br />
                                                    <asp:RegularExpressionValidator ID="EditPasswordType" runat="server" ErrorMessage="Password cannot be a number" Display="Dynamic" ControlToValidate="EditPassword" ValidationExpression="(?!^\d+$)^.+$" ValidationGroup="EditSubcategory" Font-Size="15px"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <asp:Label ID="EditAccountInvalid" runat="server" Text="Username and/or Password incorrect" Style="font-size: 15px; color: red;" Visible="false"></asp:Label>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                            <asp:button type="button" class="btn btn-primary" runat="server" Text="Update" style="font-size:15px;" OnClick="Edit_Click" ValidationGroup="EditSubcategory"></asp:button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:HiddenField id="editValue" value="0" runat="server"></asp:HiddenField>
                            <div class="modal" id="deleteModal" tabindex="-1" role="dialog" aria-labelledby="deleteModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="deleteModalLabel" style="font-size:15px;">Delete Sub Category</h5>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                            <label>Are you sure you want to delete the sub category?</label>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter account username</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="DeleteUsername" placeholder="Enter account username" runat="server" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="DeleteUsernameBlank" runat="server" ErrorMessage="Username cannot be blank" ControlToValidate="DeleteUsername" ValidationGroup="DeleteSubCategory" Font-Size="15px"></asp:RequiredFieldValidator>
                                                    <br />
                                                    <asp:RegularExpressionValidator ID="DeleteUsernameType" runat="server" ErrorMessage="Username cannot be a number" Display="Dynamic" Font-Size="15px" ControlToValidate="DeleteUsername" ValidationExpression="(?!^\d+$)^.+$" ValidationGroup="DeleteSubCategory"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter account password</label>
                                                </div>
                                                <div class="col-md-7 col-lg-7">
                                                    <asp:TextBox ID="DeletePassword" placeholder="Enter account password" type="password" runat="server" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="DeletePasswordBlank" runat="server" ErrorMessage="Password cannot be blank" ControlToValidate="DeletePassword" Font-Size="15px" ValidationGroup="DeleteSubCategory"></asp:RequiredFieldValidator>
                                                    <br />
                                                    <asp:RegularExpressionValidator ID="DeletePasswordType" runat="server" ErrorMessage="Password cannot be a number" Display="Dynamic" Font-Size="15px" ControlToValidate="DeletePassword" ValidationExpression="(?!^\d+$)^.+$" ValidationGroup="DeleteSubCategory"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <asp:Label ID="DeleteAccountInvalid" runat="server" Text="Username and/or Password incorrect" Style="font-size: 15px; color: red;" Visible="false"></asp:Label>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                            <asp:button type="button" class="btn btn-primary" runat="server" Text="Delete" style="font-size:15px;" OnClick="Delete_Click" ValidationGroup="DeleteSubCategory"></asp:button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:HiddenField id="deleteValue" value="0" runat="server"></asp:HiddenField>
                        </div>
                    </div>
                </div>
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
    </script>
</body>
</html>
