create database BuyGrand;

use BuyGrand;

create table dbo.loggedUser
(
	username nvarchar(15) primary key,
	firstName nvarchar(100) not null,
	lastName nvarchar(100) not null,
	address nvarchar(150) not null,
	phoneNumber nvarchar(15) not null,
	emailAddress nvarchar(50) not null,
	gender nvarchar(8) not null,
	country nvarchar(50) not null
);

create table dbo.login
(
	username nvarchar(15) primary key constraint username_loggedUser_login references dbo.loggedUser(username)
		on delete cascade on update cascade,
	password nvarchar(120) not null,
	secretQuestion nvarchar(150) not null,
	answer nvarchar(100) not null,
	role nvarchar(15) not null,
	activated bit not null,
	loginTime datetime not null,
	loginCount int not null
);

create table dbo.itemCategory
(
	categoryID int identity(1,1) primary key,
	category nvarchar(15) not null,
	subcategory nvarchar(15) not null
);

create table dbo.item
(
	itemID int identity(1,1) primary key,
	description nvarchar(200) not null,
	name nvarchar(50) not null,
	price numeric(5,2) not null,
	imagePath nvarchar(100) not null,
	discount numeric(7,2) default 0,
	rating numeric(3,2) default 0,
	ratingCount int default 0,
	available bit,
	orderCount int default 0,
	categoryID int constraint categoryID_item_category references dbo.itemCategory(categoryID)
		on delete cascade on update cascade
);

create table dbo.userCart
(
	cartID int identity(1,1) primary key,
	username nvarchar(15) constraint username_userCart_loggedUser references dbo.loggedUser(username),
	itemID int not null constraint itemID_userCart_item references dbo.item(itemID)
		on delete cascade on update cascade,
	quantity int not null,
	dateAdded datetime not null,
	totalPrice numeric(7,2) not null
);

create table dbo.feedback
(
	feedbackID int identity(1,1) primary key,
	originalFeedbackID int not null,
	username nvarchar(15) not null constraint username_feedback_loggedUser references dbo.loggedUser(username)
		on delete cascade on update cascade,
	message nvarchar(max) not null,
	submittedDate datetime not null
);

create table dbo.productReview
(
	reviewID int identity(1,1) primary key,
	originalReviewID int not null,
	username nvarchar(15) not null constraint username_review_loggedUser references dbo.loggedUser(username)
		on delete cascade on update cascade,
	message nvarchar(max) not null,
	submittedDate datetime not null
);

create table dbo.itemReport
(
	reportID int identity(1,1) primary key,
	username nvarchar(15) not null constraint username_itemReport_loggedUser references dbo.loggedUser(username)
		on delete cascade on update cascade,
	generatedTime datetime not null
);