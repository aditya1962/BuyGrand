create database BuyGrandReadReplica;

use BuyGrandReadReplica;

create table dbo.loggedUser
(
	username varchar(15) primary key,
	firstName varchar(100) not null,
	lastName varchar(100) not null,
	address varchar(150) not null,
	phoneNumber varchar(15) not null,
	emailAddress varchar(50) not null,
	gender varchar(8) not null,
	country varchar(50) not null
);

create table dbo.login
(
	username varchar(15) primary key constraint username_loggedUser_login references dbo.loggedUser(username)
		on delete cascade on update cascade,
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
	categoryID int identity(1,1) primary key,
	category varchar(15) not null,
	subcategory varchar(15) not null
);

create table dbo.item
(
	itemID int identity(1,1) primary key,
	description varchar(200) not null,
	name varchar(50) not null,
	price numeric(5,2) not null,
	imagePath varchar(100) not null,
	discount numeric(5,2) default 0,
	rating int default 0,
	available bit,
	orderCount int default 0,
	categoryID int constraint categoryID_item_category references dbo.itemCategory(categoryID)
		on delete cascade on update cascade
);

create table dbo.userCart
(
	cartID int identity(1,1) primary key,
	username varchar(15) constraint username_userCart_loggedUser references dbo.loggedUser(username),
	itemID int not null constraint itemID_userCart_item references dbo.item(itemID)
		on delete cascade on update cascade,
	quantity int not null,
	dateAdded datetime not null,
	totalPrice numeric(5,2) not null
);

create table dbo.feedback
(
	feedbackID int identity(1,1) primary key,
	originalFeedbackID int not null,
	username varchar(15) not null constraint username_feedback_loggedUser references dbo.loggedUser(username)
		on delete cascade on update cascade,
	message varchar(max) not null,
	submittedDate datetime not null
);

create table dbo.productReview
(
	reviewID int identity(1,1) primary key,
	originalReviewID int not null,
	username varchar(15) not null constraint username_review_loggedUser references dbo.loggedUser(username)
		on delete cascade on update cascade,
	message varchar(max) not null,
	submittedDate datetime not null
);

create table dbo.itemReport
(
	reportID int identity(1,1) primary key,
	username varchar(15) not null constraint username_itemReport_loggedUser references dbo.loggedUser(username)
		on delete cascade on update cascade,
	generatedTime datetime not null
);