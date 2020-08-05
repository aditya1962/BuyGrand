create database BuyGrandAdministrator;

use BuyGrandAdministrator;

create table dbo.login
(
	username varchar(15) primary key,
	password varchar(250) not null,
	secretQuestion varchar(150) not null,
	answer varchar(100) not null,
	role varchar(15) not null,
	activated int not null,
	loginTime datetime not null,
	loginCount int not null
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
	available int default 0,
	orderCount int default 0,
	categoryID int constraint cateogryID_item_category references dbo.itemCategory(categoryID)
		on delete cascade on update cascade
);

create table dbo.viewFeedback
(
	feedbackID int identity(1,1) primary key,
	originalFeedbackID int not null,
	username varchar(15) not null constraint username_viewFeedback_login references dbo.login(username)
		on delete cascade on update cascade,
	message varchar(max) not null,
	submittedDate datetime not null
);

create table dbo.userReport
(
	rowID int identity(1,1) primary key,
	username varchar(15) not null constraint username_userReport_login references dbo.login(username)
		on delete cascade on update cascade,
	numberOfItems int not null,
	totalPrice numeric(10,2) not null,
	submittedDate datetime not null 
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