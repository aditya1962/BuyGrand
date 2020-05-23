<p align="center"><img src="https://github.com/aditya1962/BuyGrand/blob/master/Order_Application_Java/Logo.png" alt="logo"></p>

[![GitHub issues](https://img.shields.io/github/issues/aditya1962/BuyGrand)](https://github.com/aditya1962/BuyGrand/issues)
[![GitHub stars](https://img.shields.io/github/stars/aditya1962/BuyGrand)](https://github.com/aditya1962/BuyGrand/stargazers)
[![GitHub license](https://img.shields.io/github/license/aditya1962/BuyGrand)](https://github.com/aditya1962/BuyGrand/blob/master/LICENSE)

:star: Star BuyGrand on Github. It helps a lot.

## Table of Contents

- <a href="#basic-overview">Basic Overview</a>
- <a href="#technologies">Technologies</a>
    - <a href="#customer-view">Customer View</a>
    - <a href="#admin-view">Admin View</a>
- <a href="#main-dependencies">Main Dependencies</a>
- <a href="#system-architecture">System Architecture</a>
- <a href="#license">License</a>

<h2 id="basic-overview"> Basic Overview </h2>

<a href="https://github.com/aditya1962/BuyGrand/">BuyGrand </a>is a shopping cart application where registered users could buy products, admin can administrator sellers, manage product categories and view sales reports,  and sellers can sell their products. 

There are three systems in this project : 

1. <a href="https://github.com/aditya1962/BuyGrand/tree/master/Order_Application_Java">Customer view</a>  - This uses <a href="https://www.java.com/">Java </a>as the UI render and <a href="https://www.microsoft.com/en-us/sql-server/sql-server-2019">MSSQL </a> as the database model. The invoice generation process includes digital authentication which is performed using <a href="https://www.python.org/">Python</a> (using a Convolutional Neural Network) with a web camera stream using <a href="https://opencv.org/">OpenCV</a>. You can read more <a href="https://github.com/aditya1962/BuyGrand/blob/master/Order_Application_Java/README.md"> here </a>.
2. <a href="https://github.com/aditya1962/BuyGrand/tree/master/Order_Application_Admin">Admin view</a> - This uses <a href="https://www.asp.net/">ASP.NET</a> as the UI render and <a href="https://www.microsoft.com/en-us/sql-server/sql-server-2019">MSSQL </a> as the database model. Reports are created using RDLC. You can read more <a href="https://github.com/aditya1962/BuyGrand/blob/master/Order_Application_Admin/README.md"> here </a>.
3. Seller view 

<h2 id="technologies">Technologies used</h2>

<h3 id="customer-view">Customer view</h3>

-  Java - For front-end GUI display using JFrame and File writing during invoice generation 
-  Python  - For face detection during the invoice generation process 
-  MSSQL - As the relational database management system 
-  OpenCV - For opening and capturing video streams using the web camera 

For more details <a href="https://github.com/aditya1962/BuyGrand/tree/master/Order_Application_Java#technologies">see here </a>

<h3 id="admin-view">Admin view</h3>

- ASP.NET - For UI and back-end connections 
- MSSQL - As the relational database management system
- RDLC - Report Definition Language Client-side was used for reports in the application
- Web Services - Asp.net web services were used to connect the core application with the MSSQL database
- ASP.NET Charts - Charts were used as a visual display in the admin dashboard
- Web related technologies used - JavaScript, jQuery, Bootstrap 4.0, AJAX and JSON

For more details <a href="https://github.com/aditya1962/BuyGrand/tree/master/Order_Application_Admin#technologies">see here </a>

<a href="#user-content-table-of-contents"> Back to Top </a>

<h2 id="main-dependencies">Main Dependencies</h2>

- DLib (Python dependency)- Machine learning platform for face detection using Convolutional Neural Network and prediction using an existing trained model
- iText PDF and its packages  - For PDF generation using Java application
- Microsoft Report Viewer - For report generation using RDLC

<a href="#user-content-table-of-contents"> Back to Top </a>

<h2 id="system-architecture">System Architecture</h2>

The system architecture of the overall system is three microlithic sub systems composed of the customer system, the admin system and the seller system. 

<div align="center"><img src="https://github.com/aditya1962/BuyGrand/blob/master/assets/images/Overall%20System%20Architecture.png" alt="System Architecture"></div>

<br/>
For more details on the system architecture of the customer system <a href="https://github.com/aditya1962/BuyGrand/tree/master/Order_Application_Java#-system-architecture"> see here </a>.
<br/>
For more details on the system architecture of the admin system <a href="https://github.com/aditya1962/BuyGrand/tree/master/Order_Application_Admin#system-architecture"> see here </a>.

<a href="#user-content-table-of-contents"> Back to Top </a>

<h2 id="license">License</h2>

<p>The <a href="https://github.com/aditya1962/BuyGrand">repository </a> is licensed under MIT license </p>

<a href="#user-content-table-of-contents"> Back to Top </a>
