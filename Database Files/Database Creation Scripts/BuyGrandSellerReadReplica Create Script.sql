create database BuyGrandSellerReadReplica;

use BuyGrandSellerReadReplica;

create table dbo.login
(
	username varchar(15) primary key,
	password varchar(250) not null,
	secretQuestion varchar(150) not null,
	answer varchar(100) not null,
	role varchar(15) not null,
	activated int not null,
	loginTime datetime not null,
	loginCount int not null,
	initialLoginEncrypted varchar(150) not null
);

create table dbo.loggedUser
(
	username varchar(15) primary key constraint username_loggedUser_login references dbo.login(username) 
		on delete cascade on update cascade,
	firstName varchar(100) not null,
	lastName varchar(100) not null,
	address varchar(500) not null,
	phoneNumber varchar(15) not null,
	emailAddress varchar(50) not null,
	gender varchar(8) not null,
	country varchar(40) not null
);

create table dbo.feedback
(
	feedbackID int identity(1,1) primary key,
	originalFeedbackID int not null,
	username varchar(15) not null constraint username_feedback_login references dbo.login(username)
		on delete cascade on update cascade,
	message varchar(max) not null,
	submittedDate datetime not null
);

create table dbo.itemCategory
(
	categoryID int identity(1,1) primary key,
	category varchar(100) not null,
	subcategory varchar(100) not null
);

create table dbo.item
(
	itemID int identity(1,1) primary key,
	description varchar(500) not null,
	name varchar(90) not null,
	price numeric(10,2) not null,
	imagePath varchar(200) not null,
	discount numeric(5,2) default 0,
	rating int default 0,
	quantityAvailable int,
	orderCount int default 0,
	categoryID int constraint categoryID_item_category references dbo.itemCategory(categoryID)
		on delete cascade on update cascade
);

create table dbo.review
(
	reviewID int identity(1,1) primary key,
	itemID int not null constraint itemID_review_item references dbo.item(itemID),
	originalReviewID int not null,
	username varchar(15) not null constraint username_review_login references dbo.login(username)
		on delete cascade on update cascade,
	message varchar(max) not null,
	submittedDate datetime not null
);

create table dbo.sales
(
	salesID int identity(1,1) primary key,
	itemID int not null constraint itemID_sales_item references dbo.item(itemID),
	username varchar(15) not null constraint username_sales_login references dbo.login(username)
		on delete cascade on update cascade,
	numberOfItems int not null,
	totalPrice numeric(10,2) not null,
	submittedDate datetime not null 
);
