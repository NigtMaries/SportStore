create database [SportStore1]
go
use [SportStore1]
go
create table [Role]
(
	RoleId int primary key identity,
	Name nvarchar(100) not null
)
go
create table [User]
(
	UserId int primary key identity,
	Surname nvarchar(100) not null,
	Name nvarchar(100) not null,
	Patronymic nvarchar(100) not null,
	Login nvarchar(max) not null,
	Password nvarchar(max) not null,
	Role int foreign key references [Role](RoleId) not null
)
go
create table [Order]
(
	OrderId int primary key identity,
	Status nvarchar(max) not null,
	DeliveryDate date not null,
	PickupPoint nvarchar(max) not null
)
go
create table Product
(
    ProductId int primary key identity,
	ArticleNumber nvarchar(100) unique,
	Name nvarchar(max) not null,
	Description nvarchar(max) not null,
	Category nvarchar(max) not null,
	Photo varchar(max) not null,
	Manufacturer nvarchar(max) not null,
	Cost decimal(19,4) not null,
    DiscountAmount tinyint null,
	QuantityInStock int not null,
	Status nvarchar(max) not null,
)
go
create table [OrderProduct]
(
    OrderProductId int primary key identity,
	Order_Id int foreign key references [Order](OrderId) not null,
	Product_Id int foreign key references [Product](ProductId) not null,
)