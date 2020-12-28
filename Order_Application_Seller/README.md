<p align="center"><img src="https://github.com/aditya1962/BuyGrand/blob/master/Order_Application_Java/Logo.png" alt="logo"></p>

[![GitHub issues](https://img.shields.io/github/issues/aditya1962/BuyGrand)](https://github.com/aditya1962/BuyGrand/issues)
[![GitHub stars](https://img.shields.io/github/stars/aditya1962/BuyGrand)](https://github.com/aditya1962/BuyGrand/stargazers)
[![GitHub license](https://img.shields.io/github/license/aditya1962/BuyGrand)](https://github.com/aditya1962/BuyGrand/blob/master/LICENSE)

:star: Star BuyGrand on Github. It helps a lot.

<h2> Table of Contents </h2>

- <a href="#overview"> Overview </a>
- <a href="#features"> Features </a>
- <a href="#technologies"> Technologies used </a>
- <a href="#installation"> Installation </a>
    - <a href="#prerequisites"> Prerequisites </a>
    - <a href="#database-installation"> Database installation </a>
    - <a href="#website-installation"> Website installation </a>
- <a href="#system-architecture"> System Architecture </a>

<h2 id="overview"> Overview </h2>
This is the seller view of the system. The seller view is used by a seller to add products, view products, view and reply for user reviews, manage products, and view sales. This view is a microlithic 2-tier application. Other than authentication at Login all other database calls are made through ASP.NET web services. For more details see <a href="#system-architecture"> System Architecture </a>.


<h2 id="features">Features</h2>
<ol>
    <li><a href="https://github.com/aditya1962/BuyGrand/wiki/Admin-View-Dashboard-(Index-page)">Dashboard</a></li>
    <li><a href="https://github.com/aditya1962/BuyGrand/wiki/Admin-View---Add-Category">Add Category</a> </li>
    <li><a href="https://github.com/aditya1962/BuyGrand/wiki/Admin-View---Add-Sub-Category">Add Sub Category</a> </li>
    <li><a href="https://github.com/aditya1962/BuyGrand/wiki/Admin-View---Approve-Seller">Approve Seller </li>
    <li><a href="https://github.com/aditya1962/BuyGrand/wiki/Admin-View-Feedbacks">View Feedbacks</a> </li>
    <li>Login </li>
    <li><a href="https://github.com/aditya1962/BuyGrand/wiki/Admin-View-Manage-Seller">Manage Sellers</a> </li>
    <li><a href="https://github.com/aditya1962/BuyGrand/wiki/Admin-View-View-Sales">View Sales</a> </li>
</ol>


<h2 id="technologies"> Technologies used </h2>

-  ASP.NET 4.7 - Web forms were used in the classic web application project type for UI and backend contectivity.
-  MSSQL (SQL Server 2019) - Two databases were used (one for read-optimized operations (a Read-Replica) and another for all other operations). Additionally, databases were tuned for optimal performance using indexing and related operations using execution plans.
- ASP.NET Web Services - Web Services were used to provide connectivity between the core application and the database. 
- RDLC Reporting - Report Definition Language Client Side was used to generate sales reports given the time range.
- Other ASP.NET web components 
    - Charts - Charts were used as graphical illustrations to view sales in the dashboard.
    - Web User Controls - Web user controls were used as templates for the header and footer sections for a logged in user and as templates for loading products and reviews.
- Other web technologies
    - Vanilla JavaScript, jQuery and AJAX
    - Bootstrap 4.0
    - JSON
    
<a href="#user-content--table-of-contents-">Back to contents </a>

<h2 id="installation"> Installation </h2>

<h3 id="prerequisites"> Prerequisites </h3>

Make sure your .NET runtime environment is version 4.0 and SQL Server 2012 or above is installed. This is required as the .NET application was development using version 4.7 and in SQL databases some queries were created specifically for versions 2012 and above.

<h3 id="database-installation">Database installation </h3>
<ol>
<li> Open SQL Server Management Studio (SSMS), Login using <b>SQL Authentication</b></li>
<li> Create the Seller Database, Indexes and Stored Procedures</li>
    - Locate the creation script at /Database Files/Database Creation Scripts/BuyGrandSeller Create Script.sql (or get the code <a href="https://github.com/aditya1962/BuyGrand/blob/master/Database%20Files/Database%20Creation%20Scripts/BuyGrandSeller%20Create%20Script.sql"> here </a>)<br/>
    - Open the file located in the step above<br/>
    - Execute the file (or click F5 in your keyboard)
    
<li> Create the Seller Read Replica Database, Indexes and Stored Procedures</li>
    - Locate the creation script at /Database Files/Database Creation Scripts/BuyGrandSellerReadReplica Create Script.sql
    (or get the code <a href="https://github.com/aditya1962/BuyGrand/blob/master/Database%20Files/Database%20Creation%20Scripts/BuyGrandSellerReadReplica%20Create%20Script.sql"> here </a>)<br/>
    - Open the file located in the step above<br/>
    - Execute the file (or click F5 in your keyboard)
</ol>
<a href="#user-content--table-of-contents-">Back to contents </a>

<h3 id="website-installation">Website Installation </h3>
Website installation includes pointing the application to the database. To do this, go to /Order_Application_Seller/Order_Application_Seller/Web.Config and locate the following code in this file.



```
<configuration>
  <connectionStrings>
    <add name="SellerConnectionString" connectionString="Data Source=.....;Initial Catalog=BuyGrandSeller;Persist Security Info=True;User ID=sa;Password=....." providerName="System.Data.SqlClient"/>
    <add name="SellerReadReplicaConnectionString" connectionString="Data Source=.....;Initial Catalog=BuyGrandSellerReadReplica;Persist Security Info=True;User ID=sa;Password=....." providerName="System.Data.SqlClient"/>
  </connectionStrings>
...
```

In the connectionString in both SellerConnectionString and SellerReadReplicaConnectionString nodes change the Data Source (in the above snippet ".....") to the server name of your SQL Server, User ID to the username (in the above snippet "sa") and the password to the password (in the above snippet ".....") of the SQL Server Authentication account of the SQL Server.

<a href="#user-content--table-of-contents-">Back to contents </a>

<h2 id="system-architecture"> System Architecture</h2>
<br>

<p align="center"><img src="https://github.com/aditya1962/BuyGrand/blob/master/assets/images/Admin%20System%20Architecture.png" alt="System Architecture" Width="50%"></p>

<a href="#user-content--table-of-contents-">Back to contents </a>

