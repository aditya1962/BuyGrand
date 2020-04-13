create database BuyGrandAdministratorReadReplica;

use BuyGrandAdministratorReadReplica;

create table dbo.login
(
	username varchar(15) primary key,
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

create table dbo.viewFeedback
(
	feedbackID varchar(15) primary key,
	username varchar(15) not null,
	message varchar(250) not null,
	submittedDate datetime not null
);

create table dbo.userReport
(
	rowID varchar(15) primary key,
	username varchar(15) not null,
	numberOfItems int not null,
	totalPrice numeric(5,2) not null
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

create table dbo.feedbackAdmin
(
	feedbackID varchar(15) primary key,
	username varchar(15) not null constraint username_feedbackAdmin_login references dbo.login(username),
	message varchar(250) not null,
	submittedDate datetime not null
);