<p align="center"><img src="https://github.com/aditya1962/BuyGrand/blob/master/Order_Application_Java/Logo.png" alt="logo"></p>

[![GitHub issues](https://img.shields.io/github/issues/aditya1962/BuyGrand)](https://github.com/aditya1962/BuyGrand/issues)
[![GitHub stars](https://img.shields.io/github/stars/aditya1962/BuyGrand)](https://github.com/aditya1962/BuyGrand/stargazers)
[![GitHub license](https://img.shields.io/github/license/aditya1962/BuyGrand)](https://github.com/aditya1962/BuyGrand/blob/master/LICENSE)

:star: Star BuyGrand on Github. It helps a lot.

## Technologies used

### Customer view
<ul>
  <li> Java - For front-end GUI display using JFrame and File writing during invoice generation </li>
  <li> Python  - For face detection during the invoice generation process </li>
  <li> MSSQL - As the relational database management system </li>
  <li> OpenCV - For opening and capturing video streams using the web camera </li>
</ul>

### Admin view
<ul>
  <li> ASP.NET - For UI and back-end connections  </li>
  <li> MSSQL - As the relational database management system </li>
  <li> RDLC - Report Definition Language Client-side was used for reports in the application </li>
  <li> Web Services - Asp.net web services were used to connect the core application with the MSSQL database </li>
  <li> ASP.NET Charts - Charts were used as a visual display in the admin dashboard </li>
  <li> Web related technologies used - JavaScript, jQuery, Bootstrap 4.0, AJAX </li>
</ul>

## Main Dependencies 

<ul>
  <li> DLib (Python dependency)- Machine learning platform for face detection using Convolutional Neural Network and prediction using an existing trained model </li>
  <li> iText PDF and its packages  - For PDF generation using Java application </li>
</ul>

## Basic Overview

<a href="https://github.com/aditya1962/BuyGrand/">BuyGrand </a>is a Java based shopping cart (desktop) application where registered users could buy products. The  uses <a href="https://www.java.com/">Java </a>as the UI render and <a href="https://www.microsoft.com/en-us/sql-server/sql-server-2019">MSSQL </a> as the database model. The invoice generation process includes digital authentication which is performed using <a href="https://www.python.org/">Python</a> (using a Convolutional Neural Network) with a web camera stream using <a href="https://opencv.org/">OpenCV</a>. 

## Table of Contents

<ol>
  <li> <a href="#installation">Installation </a></li>
  <li> <a href="#system-architecture">System Architecture</a></li>
  <li> <a href="#license">License</a></li>
</ol>


<h3 id="installation">Installation</h3>
<br/>
<b> Prerequisites </b>
<br/>
<p>Make sure Java and Python (version 3.0 upwards) are installed and class path set. Also Git Bash should be installed to clone and perform git related operations
<br/><br/>
The latest version of BuyGrand can be cloned using

```git
git clone https://github.com/aditya1962/BuyGrand.git 
```
Then navigate to BuyGrand Folder

```cmd
cd BuyGrand
```
Then open project using your favorite Java IDE or editor

<b> Installing dependencies - Python </b>

The python script uses following dependencies: dlib, numpy, cv2, imageio, PIL and CMake. (Please note: Additional dependencies for the aforementioned dependencies may have to be installed based on the python configuration of the machine in which it will be installed. For more clarifications watch for any warning or error messages while installing the above packages)

These can be installed by first navigating to the python configuration in the git bash

```git
which python
```
Then copy the path up to the last slash (excluding the "python" name at the end of the path) and navigating to 

```
cd path/Scripts/
```
(replace the "path" with the path where your python is installed as obtained by the git command above)

Then install dependencies using "pip install"

```python
pip install dlib, numpy, cv2, imageio, PIL, CMake
```

<b> Installing dependencies  - Java </b>

Java dependencies include iText PDF libraries. These are packaged in the project and can be found at BuyGrand\Order_Application_Java\dist\lib

In your favorite IDE click on libraries and right click and select Add JAR. (Note that this option may be different for different IDEs. In that case select an alternative approach to install JAR files in the Java project) Then navigate to 

<i>Project path</i>\dist\lib\ and select the JAR files one by one.

If any project errors occur due to missing libraries follow the same procedure in Resolve Project Problems.
</p>
<h3 id="system-architecture">System Architecture</h3>

<div align="center"><img src="https://raw.githubusercontent.com/aditya1962/BuyGrand/master/System%20Architecture.png" alt="System Architecture"></div>

<h3 id="license">License</h3>

<p>The <a href="https://github.com/aditya1962/BuyGrand">repository </a> is licensed under MIT license </p>
