<p align="center"><img src="https://github.com/aditya1962/BuyGrand/blob/master/Order_Application_Java/Logo.png" alt="logo"></p>

[![GitHub issues](https://img.shields.io/github/issues/aditya1962/BuyGrand)](https://github.com/aditya1962/BuyGrand/issues)
[![GitHub stars](https://img.shields.io/github/stars/aditya1962/BuyGrand)](https://github.com/aditya1962/BuyGrand/stargazers)
[![GitHub license](https://img.shields.io/github/license/aditya1962/BuyGrand)](https://github.com/aditya1962/BuyGrand/blob/master/LICENSE)

:star: Star BuyGrand on Github. It helps a lot.

## Basic Overview

<a href="https://github.com/aditya1962/BuyGrand/">BuyGrand </a>is a shopping cart application where registered users could buy products, admin can administrator sellers, manage product categories and view sales reports,  and sellers can sell their products. 

There are three systems in this project : 

1. <a href="https://github.com/aditya1962/BuyGrand/tree/master/Order_Application_Java">Customer view</a>  - This uses <a href="https://www.java.com/">Java </a>as the UI render and <a href="https://www.microsoft.com/en-us/sql-server/sql-server-2019">MSSQL </a> as the database model. The invoice generation process includes digital authentication which is performed using <a href="https://www.python.org/">Python</a> (using a Convolutional Neural Network) with a web camera stream using <a href="https://opencv.org/">OpenCV</a>. You can read more <a href="https://github.com/aditya1962/BuyGrand/blob/master/Order_Application_Java/README.md"> here </a>.
2. <a href="https://github.com/aditya1962/BuyGrand/tree/master/Order_Application_Admin">Admin view</a> - This uses <a href="https://www.asp.net/">ASP.NET</a> as the UI render and <a href="https://www.microsoft.com/en-us/sql-server/sql-server-2019">MSSQL </a> as the database model. Reports are created using RDLC.
3. Seller view 

## Technologies used

### Customer view

-  Java - For front-end GUI display using JFrame and File writing during invoice generation 
-  Python  - For face detection during the invoice generation process 
-  MSSQL - As the relational database management system 
-  OpenCV - For opening and capturing video streams using the web camera 

### Admin view

- ASP.NET - For UI and back-end connections 
- MSSQL - As the relational database management system
- RDLC - Report Definition Language Client-side was used for reports in the application
- Web Services - Asp.net web services were used to connect the core application with the MSSQL database
- ASP.NET Charts - Charts were used as a visual display in the admin dashboard
- Web related technologies used - JavaScript, jQuery, Bootstrap 4.0, AJAX and JSON


## Main Dependencies 

- DLib (Python dependency)- Machine learning platform for face detection using Convolutional Neural Network and prediction using an existing trained model
- iText PDF and its packages  - For PDF generation using Java application
- Microsoft Report Viewer - For report generation using RDLC

##  System Architecture

<div align="center"><img src="https://raw.githubusercontent.com/aditya1962/BuyGrand/master/System%20Architecture.png" alt="System Architecture"></div>

## License

<p>The <a href="https://github.com/aditya1962/BuyGrand">repository </a> is licensed under MIT license </p>
