create database BuyGrandAdministrator;

use BuyGrandAdministrator;

create table dbo.login
(
	username nvarchar(15) primary key,
	password nvarchar(250) not null,
	secretQuestion nvarchar(150) not null,
	answer nvarchar(100) not null,
	role nvarchar(15) not null,
	activated int not null,
	loginTime datetime not null,
	loginCount int not null
);

create table dbo.itemCategory
(
	categoryID int identity(1,1) primary key,
	category nvarchar(100) not null,
	subcategory nvarchar(100) not null
);

create table dbo.item
(
	itemID int identity(1,1) primary key,
	description nvarchar(500) not null,
	name nvarchar(90) not null,
	price numeric(10,2) not null,
	imagePath nvarchar(200) not null,
	discount numeric(7,2) default 0,
	rating numeric(3,2) default 0,
	ratingCount int default 0,
	available int default 0,
	orderCount int default 0,
	categoryID int constraint cateogryID_item_category references dbo.itemCategory(categoryID)
		on delete cascade on update cascade
);

create table dbo.viewFeedback
(
	feedbackID int identity(1,1) primary key,
	originalFeedbackID int not null,
	username nvarchar(15) not null constraint username_viewFeedback_login references dbo.login(username)
		on delete cascade on update cascade,
	message nvarchar(max) not null,
	submittedDate datetime not null
);

create table dbo.userReport
(
	rowID int identity(1,1) primary key,
	username nvarchar(15) not null constraint username_userReport_login references dbo.login(username)
		on delete cascade on update cascade,
	numberOfItems int not null,
	totalPrice numeric(12,2) not null,
	submittedDate datetime not null 
);

create table dbo.loggedUser
(
	username nvarchar(15) primary key constraint username_loggedUser_login references dbo.login(username)
		on delete cascade on update cascade,
	firstName nvarchar(100) not null,
	lastName nvarchar(100) not null,
	address nvarchar(500) not null,
	phoneNumber nvarchar(15) not null,
	emailAddress nvarchar(50) not null,
	gender nvarchar(8) not null,
	country nvarchar(40) not null
);