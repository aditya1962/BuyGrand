<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Item.ascx.cs" Inherits="Order_Application_Seller.Item" %>
<div class="col-md-3 col-lg-3">
    <asp:Image ImageUrl="<%= imagePath %>" ID="" AlternateText="ItemImage" runat="server" Height="100px"/>
    <br />
    <asp:Label Text="<%= name %>" runat="server" />
    <br />
    <asp:Label Text="<%= price %>" runat="server" />
</div>
