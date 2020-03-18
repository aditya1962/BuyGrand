<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Feedbacks.aspx.cs" Inherits="Order_Application_Admin.Feedbacks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Feedbacks</title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <link rel="icon" href="images/logo.ico" />
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <style type="text/css">
        th {
            font-size: 15px;
            border: 1px solid #000000;
        }
    </style>
</head>
<body>
    <form id="feedbacks" runat="server">
        <div>
            <!--Header Row -->
            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <!-- Vertical nav bar -->
                </div>
                <div class="col-md-10 col-lg-10">
                    <h3 style="font-size: 25px;">Feedbacks</h3>
                    <br />
                    <br />
                    <div class="card">
                        <div class="card-body">
                            <div id="feedbacksHtml" runat="server"></div>
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
