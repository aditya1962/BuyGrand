create database BuyGrand;

use BuyGrand;

create table dbo.loggedUser
(
	username varchar(15) primary key,
	firstName varchar(100),
	lastName varchar(100),
	address varchar(150),
	phoneNumber varchar(15),
	emailAddress varchar(50),
	gender varchar(8),
	country varchar(50)
);

create table dbo.login
(
	username varchar(15) primary key constraint username_loggedUser_login references dbo.loggedUser(username),
	password varchar(120) not null,
	secretQuestion varchar(150) not null,
	answer varchar(100) not null,
	role varchar(15) not null,
	activated bit not null,
	loginTime datetime not null,
	loginCount int not null
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
	available bit,
	orderCount int default 0,
	categoryID varchar(10) constraint cateogryID_item_category references dbo.itemCategory(categoryID)
);


create table dbo.userCart
(
	username varchar(15) primary key constraint username_userCart_loggedUser references dbo.loggedUser(username),
	itemID varchar(10) not null constraint itemID_userCart_item references dbo.item(itemID),
	quantity int not null,
	dateAdded datetime not null,
	totalPrice numeric(5,2) not null
);

create table dbo.feedback
(
	feedbackID varchar(15) primary key,
	username varchar(15) not null constraint username_feedback_loggedUser references dbo.loggedUser(username),
	message varchar(250) not null,
	submittedDate datetime not null
);

create table dbo.itemReport
(
	reportID varchar(15) primary key,
	username varchar(15) not null constraint username_itemReport_loggedUser references dbo.loggedUser(username),
	generatedTime datetime not null
);

