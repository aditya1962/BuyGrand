<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserItem.ascx.cs" Inherits="Order_Application_Seller.UserItem" %>
<div class="col-md-3 col-lg-3">
    <asp:Image AlternateText="ItemImage" runat="server" Height="100px" ClientIDMode="AutoID" ID="ItemImage" />
    <br />
    <asp:Label ID="ItemName" runat="server" ClientIDMode="AutoID" />
    <br />
    <asp:Label runat="server" ClientIDMode="AutoID" ID="ItemPrice" />
</div>
