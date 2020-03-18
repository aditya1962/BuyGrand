<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSales.aspx.cs" Inherits="Order_Application_Admin.ViewSales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Sales</title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <link rel="icon" href="images/logo.ico" />
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
</head>
<body>
    <form id="view_sales" runat="server">
        <div>
            <!--Header Row -->
            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <!-- Vertical nav bar -->
                </div>
                <div class="col-md-10 col-lg-10">
                    <h3 style="font-size:25px;">View Sales</h3>
                    <br />
                    <div class="card">
                        <div class="card-body">
                           <div class="row">
                               <div class="col-md-2 col-lg-2">
                                   <label style="font-size:15px;">Start Date</label>
                               </div>
                               <div class="col-md-2 col-lg-2"> 
                                   <input type="date" class="form-control" name="startdate" style="font-size:15px;"/>
                               </div>
                               <div class="col-md-2 col-lg-2 offset-md-1 offset-lg-1">
                                   <label style="font-size:15px;">End Date</label>
                                   <br />
                                   <label style="color:red;display:none;">Pick a date after the start date</label>
                               </div>
                               <div class="col-md-2 col-lg-2">
                                   <input type="date" class="form-control" name="enddate" style="font-size:15px;"/>
                               </div>
                               <div class="col-md-3 col-lg-3">
                                   <asp:Button ID="View" class="btn btn-primary" text="View" style="font-size:15px;" runat="server" onclick="View_Click"></asp:Button>
                               </div>
                           </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--Footer-->
            <div class="footer">

            </div>
        </div>
    </form>
</body>
</html>
