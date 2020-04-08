﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSubcategory.aspx.cs" Inherits="Order_Application_Admin.Add_Subcategories" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Subcategory</title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css"/>
    <script src="Scripts/jquery-3.4.1.js"></script>
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
                                    <asp:TextBox ID="subcategory" class="form-control" placeholder="Enter subcategory" style="font-size:15px;" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-3 col-lg-3">
                                   <asp:Button ID="addsubcategory" class="btn btn-primary" text="Add Sub Category" style="font-size:15px;" runat="server" OnClick="addsubcategory_Click"></asp:Button>
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
                                    <label style="font-size:17px;">Select Category</label>
                                </div>
                                <div class="col-md-4 col-lg-4">
                                    <asp:dropdownlist id="categorylist2" name="category2" class="form-control" style="font-size:15px;" runat="server">
                                    </asp:dropdownlist>
                                </div>
                                <div class="col-md-3 col-lg-3">
                                    <asp:Button ID="categorysearch" class="btn btn-primary" text="Search" style="font-size:15px;" runat="server" OnClick="categorysearch_Click"></asp:Button>
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
                                                <div class="col-md-5 col-lg-5">
                                                    <asp:TextBox ID="EditSubCategoryName" placeholder="Enter Sub category name" runat="server" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:Label ID="SubCategoryBlank" runat="server" Text="Sub Category cannot be blank" style="font-size:15px;color:red;" Visible="false"></asp:Label>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter account username</label>
                                                </div>
                                                <div class="col-md-5 col-lg-5">
                                                    <asp:TextBox ID="EditUsername" placeholder="Enter account username" runat="server" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:Label ID="EditUsernameBlank" runat="server" Text="Username cannot be blank" style="font-size:15px;color:red;" Visible="false"></asp:Label>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter account password</label>
                                                </div>
                                                <div class="col-md-5 col-lg-5">
                                                    <asp:TextBox ID="EditPassword" placeholder="Enter account password" type="password" runat="server" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:Label ID="EditPasswordBlank" runat="server" Text="Password cannot be blank" style="font-size:15px;color:red;" Visible="false"></asp:Label>
                                            </div>
                                            <asp:Label ID="EditAccountInvalid" runat="server" Text="Username and/or Password incorrect" Style="font-size: 15px; color: red;" Visible="false"></asp:Label>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                            <asp:button type="button" class="btn btn-primary" runat="server" Text="Update" style="font-size:15px;" OnClick="Edit_Click"></asp:button>
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
                                                <div class="col-md-5 col-lg-5">
                                                    <asp:TextBox ID="DeleteUsername" placeholder="Enter account username" runat="server" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                </div>
                                                <br />
                                                <asp:Label ID="DeleteUsernameBlank" runat="server" Text="Username cannot be blank" style="font-size:15px;color:red;" Visible="false"></asp:Label>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5 col-lg-5">
                                                    <label>Enter account password</label>
                                                </div>
                                                <div class="col-md-5 col-lg-5">
                                                    <asp:TextBox ID="DeletePassword" placeholder="Enter account password" type="password" runat="server" class="form-control" style="font-size:15px;"></asp:TextBox>
                                                </div>
                                                <asp:Label ID="DeletePasswordBlank" runat="server" Text="Password cannot be blank" Style="font-size: 15px; color: red;" Visible="false"></asp:Label>
                                            </div>
                                            <asp:Label ID="DeleteAccountInvalid" runat="server" Text="Username and/or Password incorrect" Style="font-size: 15px; color: red;" Visible="false"></asp:Label>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                            <asp:button type="button" class="btn btn-primary" runat="server" Text="Delete" style="font-size:15px;" OnClick="Delete_Click"></asp:button>
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
