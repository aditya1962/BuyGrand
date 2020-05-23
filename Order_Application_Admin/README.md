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
This is the administrator view of the system. The administrator view is used by the admin to manage sellers, product categories and subcategories, and view sales. This view is a microlithic 2-tier application. Other than authentication at Login all other database calls are made through ASP.NET web services. For more details see <a href="#system-architecture"> System Architecture </a>.


<h2 id="features">Features</h2>
<ol>
    <li>Dashboard</li>
    <li>Add Category </li>
    <li>Add Sub Category </li>
    <li>Approve Seller </li>
    <li>View Feedbacks </li>
    <li>Login </li>
    <li>Manage Sellers </li>
    <li>Add Category </li>
    <li>View Sales </li>
</ol>


<h2 id="technologies"> Technologies used </h2>

-  ASP.NET 4.7 - Web forms were used in the classic web application project type for UI and backend contectivity.
-  MSSQL (SQL Server 2019) - Two databases were used (one for read-optimized operations (a Read-Replica) and another for all other operations). Additionally, databases were tuned for optimal performance using indexing and related operations using execution plans.
- ASP.NET Web Services - Web Services were used to provide connectivity between the core application and the database. 
- RDLC Reporting - Report Definition Language Client Side was used to generate sales reports given the time range.
- Other ASP.NET web components 
    - Charts - Charts were used as graphical illustrations to view sales in the dashboard.
    - Web User Controls - Web user controls were used as templates for the header and footer sections for a logged in user.
- Other web technologies
    - Vanilla JavaScript, jQuery and AJAX
    - Bootstrap 4.0
    - JSON
    
<a href="#user-content--table-of-contents-">Back to contents </a>

<h2 id="installation"> Installation </h2>

<h3 id="prerequisites"> Prerequisites </h3>

Make sure your .NET runtime environment is version 4.0 and SQL Server 2012 or above is installed. This is required as the .NET application was development using version 4.0 and in SQL databases some queries were created specifically for versions 2012 and above.

<h3 id="database-installation">Database installation </h3>
<ol>
<li> Open SQL Server Management Studio (SSMS), Login using <b>SQL Authentication</b></li>
<li> Create the Administrator Database, Indexes and Stored Procedures</li>
    - Locate the creation script at /Database Files/BuyGrandAdministrator Create Script.sql (or get the code <a href="https://github.com/aditya1962/BuyGrand/blob/master/Database%20Files/BuyGrandAdministrator%20Create%20Script.sql"> here </a>)<br/>
    - Open the file located in the step above<br/>
    - Execute the file (or click F5 in your keyboard)
    
<li> Create the Administrator Read Replica Database, Indexes and Stored Procedures</li>
    - Locate the creation script at /Database Files/BuyGrandAdministrator Create Script.sql (or get the code <a href="https://github.com/aditya1962/BuyGrand/blob/master/Database%20Files/BuyGrandAdministrator%20Create%20Script.sql"> here </a>)<br/>
    - Open the file located in the step above<br/>
    - Execute the file (or click F5 in your keyboard)
</ol>
<a href="#user-content--table-of-contents-">Back to contents </a>

<h3 id="website-installation">Website Installation </h3>
Website installation includes pointing the application to the database. To do this, go to /Order_Application_Admin/Order_Application_Admin/Web.Config and locate the following code in this file.
<br/>

```
<configuration>
  <connectionStrings>
    <add name="SqlConnectionString" connectionString="Data Source=ADITYA_PC;Initial Catalog=BuyGrandAdministrator;Persist Security Info=True;User ID=sa;Password=password@123" providerName="System.Data.SqlClient"/>
    <add name="SqlReadReplicaConnectionString" connectionString="Data Source=ADITYA_PC;Initial Catalog=BuyGrandAdministratorReadReplica;Persist Security Info=True;User ID=sa;Password=password@123" providerName="System.Data.SqlClient"/>
  </connectionStrings>
...
```

In the connectionString in both SqlConnectionString and SqlReadReplicaConnectionString nodes change the Data Source (in the above snippet "ADITYA_PC") to the server name of your SQL Server, User ID to the username and the password to the password of the SQL Server Authentication account of the SQL Server.

<a href="#user-content--table-of-contents-">Back to contents </a>

<h2 id="system-architecture"> System Architecture</h2>
<br>

<div align="center"><img src="https://raw.githubusercontent.com/aditya1962/BuyGrand/master/System%20Architecture.png" alt="System Architecture"></div>

<a href="#user-content--table-of-contents-">Back to contents </a>