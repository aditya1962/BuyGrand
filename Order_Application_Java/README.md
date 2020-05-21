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
    - <a href="#python"> Installing dependencies - Python </a>
    - <a href="#java"> Installing dependencies  - Java </a>
- <a href="#system-architecture"> System Architecture </a>

<h2 id="overview"> Overview </h2>

This is the customer view of the system. This view is used by customers to buy products and place orders. Each customer needs to be a registered user before using the system and once logged in they can purchase products and create an invoice for the order.

<h2 id="features">Features</h2>
<ol>
<li>Login</li> 
<li>Register</li> 
<li>Forgot Password</li> 
<li>View categories and subcategories</li> 
<li>View products</li> 
<li>Change account settings</li> 
<li>Add to cart</li> 
<li>View cart and print invoice</li> 
</ol>


<h2 id="technologies"> Technologies used </h2>

-  Java - For front-end GUI display using JFrame and File writing during invoice generation 
-  Python  - For face detection during the invoice generation process 
-  MSSQL - As the relational database management system 
-  OpenCV - For opening and capturing video streams using the web camera 

<a href="#user-content--table-of-contents-">Back to contents </a>

<h2 id="installation"> Installation </h2>

<h3 id="prerequisites"> Prerequisites </h3>
<br/>
<p>Make sure Java and Python 3.0+ are installed and class path set. Also Git Bash should be installed to clone and perform git related operations
<br/><br/>
The latest version of BuyGrand can be cloned using

```git
git clone https://github.com/aditya1962/BuyGrand.git 
```
Then navigate to BuyGrand Folder

```cmd
cd BuyGrand
```
Then open project (Order_Application_Java) using your favorite Java IDE or editor

<a href="#user-content--table-of-contents-">Back to contents </a>

<h3 id="python"> Installing dependencies - Python </h3>

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

<a href="#user-content--table-of-contents-">Back to contents </a>

<h3 id="java"> Installing dependencies  - Java </h3>

Java dependencies include iText PDF libraries. These are packaged in the project and can be found at BuyGrand\Order_Application_Java\dist\lib

In your favorite IDE click on libraries and right click and select Add JAR. (Note that this option may be different for different IDEs. In that case select an alternative approach to install JAR files in the Java project) Then navigate to 

<i>Project path</i>\dist\lib\ and select the JAR files one by one.

If any project errors occur due to missing libraries follow the same procedure in Resolve Project Problems.
</p>

<a href="#user-content--table-of-contents-">Back to contents </a>

<h2 id="system-architecture"> System Architecture</h2>
<br>

<div align="center"><img src="https://raw.githubusercontent.com/aditya1962/BuyGrand/master/System%20Architecture.png" alt="System Architecture"></div>

<a href="#user-content--table-of-contents-">Back to contents </a>
