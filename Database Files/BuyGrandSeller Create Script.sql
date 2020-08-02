create database BuyGrandSeller;

use BuyGrandSeller;

create table dbo.login
(
	username varchar(15) primary key,
	password varchar(120) not null,
	secretQuestion varchar(150) not null,
	answer varchar(100) not null,
	role varchar(15) not null,
	activated int not null,
	loginTime datetime not null,
	loginCount int not null,
	initialLoginEncrypted varchar(100) not null
);

create table dbo.loggedUser
(
	username varchar(15) primary key constraint username_loggedUser_login references dbo.login(username),
	firstName varchar(100),
	lastName varchar(100),
	address varchar(150),
	phoneNumber varchar(15),
	emailAddress varchar(50),
	gender varchar(8),
	country varchar(50)
);

create table dbo.feedback
(
	feedbackID varchar(15) primary key,
	originalFeedbackID varchar(15) not null,
	username varchar(15) not null constraint username_feedback_login references dbo.login(username),
	message varchar(250) not null,
	submittedDate datetime not null
);

create table dbo.itemCategory
(
	categoryID varchar(10) primary key,
	category varchar(15) not null,
	subcategory varchar(15) not null
);

create table dbo.item
(
	itemID varchar(10) primary key,
	description varchar(200) not null,
	name varchar(50) not null,
	price numeric(5,2) not null,
	imagePath varchar(100) not null,
	discount numeric(5,2) default 0,
	rating int default 0,
	quantityAvailable int,
	orderCount int default 0,
	categoryID varchar(10) constraint categoryID_item_category references dbo.itemCategory(categoryID)
);

create table dbo.review
(
	reviewID varchar(15) primary key,
	itemID varchar(10) not null constraint itemID_review_item references dbo.item(itemID),
	originalReviewID varchar(15) not null,
	username varchar(15) not null constraint username_review_login references dbo.login(username),
	message varchar(250) not null,
	submittedDate datetime not null
);

create table dbo.sales
(
	salesID varchar(15) primary key,
	itemID varchar(10) not null constraint itemID_sales_item references dbo.item(itemID),
	username varchar(15) not null constraint username_sales_login references dbo.login(username),
	numberOfItems int not null,
	totalPrice numeric(10,2) not null,
	submittedDate datetime not null 
);
