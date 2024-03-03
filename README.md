<p align="center"><img src="https://github.com/aditya1962/BuyGrand/blob/master/Order_Application_Java/Logo.png" alt="logo"></p>

<div align="center">

[![GitHub issues](https://img.shields.io/github/issues/aditya1962/BuyGrand)](https://github.com/aditya1962/BuyGrand/issues)
[![GitHub stars](https://img.shields.io/github/stars/aditya1962/BuyGrand)](https://github.com/aditya1962/BuyGrand/stargazers)
[![GitHub license](https://img.shields.io/github/license/aditya1962/BuyGrand)](https://github.com/aditya1962/BuyGrand/blob/master/LICENSE)

</div>

<h2 id="basic-overview"> Basic Overview </h2>

BuyGrand is a shopping cart application where registered users could buy products, admin can administrator sellers, manage product categories and view sales reports,  and sellers can sell their products. 

There are three views in this project: 

1. <a href="https://github.com/aditya1962/BuyGrand/tree/master/Order_Application_Java">Customer view</a>  - This uses <a href="https://www.java.com/">Java</a> as the UI render and <a href="https://www.microsoft.com/en-us/sql-server/sql-server-2019">MSSQL</a> as the database model. The invoice generation process includes digital authentication which is performed using <a href="https://www.python.org/">Python</a> (using a Convolutional Neural Network) with a web camera stream using <a href="https://opencv.org/">OpenCV</a>. You can read more <a href="https://github.com/aditya1962/BuyGrand/blob/master/Order_Application_Java/README.md">here</a>.
2. <a href="https://github.com/aditya1962/BuyGrand/tree/master/Order_Application_Admin">Admin view</a> - This uses <a href="https://www.asp.net/">ASP.NET</a> as the UI render and <a href="https://www.microsoft.com/en-us/sql-server/sql-server-2019">MSSQL</a> as the database model. Reports are created using RDLC. You can read more <a href="https://github.com/aditya1962/BuyGrand/blob/master/Order_Application_Admin/README.md">here</a>.
3. <a href="https://github.com/aditya1962/BuyGrand/tree/master/Order_Application_Seller">Seller view</a> - This uses <a href="https://www.asp.net/">ASP.NET</a> as the UI render and <a href="https://www.microsoft.com/en-us/sql-server/sql-server-2019">MSSQL</a> as the database model. Reports are created using RDLC. You can read more <a href="https://github.com/aditya1962/BuyGrand/blob/master/Order_Application_Seller/README.md">here</a>. 

<h2 id="technologies">Technologies used</h2>

<h3 id="customer-view">Customer view</h3>

-  Java - For front-end GUI display using JFrame and File writing during invoice generation 
-  Python  - For face detection during the invoice generation process 
-  MSSQL - As the relational database management system 
-  OpenCV - For opening and capturing video streams using the web camera 

For more details <a href="https://github.com/aditya1962/BuyGrand/tree/master/Order_Application_Java#technologies">see here</a>

<h3 id="admin-view">Admin view</h3>

- ASP.NET - For UI and back-end connections 
- MSSQL - As the relational database management system
- RDLC - Report Definition Language Client-side was used for reports in the application
- Web Services - Asp.net web services were used to connect the core application with the MSSQL database
- ASP.NET Charts - Charts were used as a visual display in the admin dashboard
- Web related technologies used - JavaScript, jQuery, Bootstrap 4.0, AJAX and JSON

For more details <a href="https://github.com/aditya1962/BuyGrand/tree/master/Order_Application_Admin#technologies">see here</a>

<h3 id="seller-view">Seller view</h3>

- ASP.NET - For UI and back-end connections 
- MSSQL - As the relational database management system
- RDLC - Report Definition Language Client-side was used for reports in the application
- Web Services - Asp.net web services were used to connect the core application with the MSSQL database
- ASP.NET Charts - Charts were used as a visual display in the admin dashboard
- Web related technologies used - JavaScript, jQuery, Bootstrap 4.0, AJAX and JSON

For more details <a href="https://github.com/aditya1962/BuyGrand/tree/master/Order_Application_Seller#technologies">see here</a>

<h2 id="main-dependencies">Main Dependencies</h2>

- DLib (Python dependency)- Machine learning platform for face detection using Convolutional Neural Network and prediction using an existing trained model
- iText PDF and its packages  - For PDF generation using Java application
- Microsoft Report Viewer - For report generation using RDLC

<h2 id="system-architecture">System Architecture</h2>

The system architecture of the overall system is three microlithic sub systems composed of the customer system, the admin system and the seller system. 

<div align="center"><img src="https://github.com/aditya1962/BuyGrand/blob/master/assets/images/Overall%20System%20Architecture.png" alt="System Architecture"></div>

<br/>
For more details on the system architecture of the customer view <a href="https://github.com/aditya1962/BuyGrand/tree/master/Order_Application_Java#-system-architecture">see here</a>.
<br/>
For more details on the system architecture of the admin view <a href="https://github.com/aditya1962/BuyGrand/tree/master/Order_Application_Admin#system-architecture">see here</a>.
<br/>
For more details on the system architecture of the seller view <a href="https://github.com/aditya1962/BuyGrand/tree/master/Order_Application_Seller#system-architecture">see here</a>.

<h2 id="license">License</h2>

<p>The repository is licensed under MIT license </p>
