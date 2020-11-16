<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Review.ascx.cs" Inherits="Order_Application_Seller.Review" %>
<div class="productReview">
    <asp:HiddenField ID="ReviewID" runat="server" ClientIDMode="Static"/>
    <div class="row" style="display:flex;">
        <asp:Image ID="ProfileIcon" runat="server" ClientIDMode="AutoID" AlternateText="Profile" Width="40px" />
        <asp:Label ID="ProfileName" runat="server" ClientIDMode="AutoID" Text="Name" style="padding:0px 10px;"></asp:Label>
        <asp:Label ID="DateStamp" runat="server" ClientIDMode="AutoID" Text="Date"></asp:Label>
    </div>
    <div class="row">
        <asp:Label ID="ReviewDescription" runat="server" ClientIDMode="AutoID" Text="Review"></asp:Label>
    </div>
    <div class="row" style="display:flex;">
        <a ID="MoreReviews" runat="server" Visible="false" onclick="loadSubreviews(event)">View reviews</a>
        <button id="Reply" class='btn btn-primary' onclick='loadSubreviewComment(this)' type="button">Reply</button>
    </div>
    <div class="row">
        <div class="subreviews" style="visibility:hidden;">

        </div>
    </div>
</div>