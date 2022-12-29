create database oganishopdb
go

use oganishopdb 
go

create table AccountAvatar
(
	Id int identity(1,1) primary key,
	AccountId int,
	ImagePath nvarchar(200),
	CreateDate datetime,
	UpdateDate datetime,
	FilePath nvarchar(200),
	FileType varchar(50),
	FileFormat varchar(50),
	FileId int,
	Status int,
	IsDeleted bit
)

create table Account
(
	AccId int identity(1,1) primary key,
	Username nvarchar(200),
	Password varchar(200),
	ReturnURL varchar(200),
	RetypedPassword varchar(200),
	Avatar nvarchar(200),
	CartValue decimal,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Country nvarchar(50),
	Address nvarchar(200),
	Postcode varchar(20),
	Phone varchar(20),
	Email varchar(200),
	OrderNotes nvarchar(max)
)

create table Banner
(
	Id int identity(1,1) primary key,
	CreateDate datetime,
	UpdateDate datetime,
	CreatedBy nvarchar(200),
	UpdatedBy nvarchar(200),
	Status int,
	IsDeleted bit,
	Title nvarchar(200),
	Content nvarchar(200),
	ImagePath nvarchar(200),
	Slug nvarchar(200),
	BigImage bit,
	ToCategoryId int
)

create table BannerImage
(
	Id int identity(1,1) primary key,
	CreateDate datetime,
	UpdateDate datetime,
	CreatedBy nvarchar(200),
	UpdatedBy nvarchar(200),
	Status int,
	IsDeleted bit,
	BannerId int,
	Name nvarchar(200),
	FilePath nvarchar(200),
	FileType varchar(50),
	FileFormat varchar(50),
	FileId int
)

create table BlogCategory 
(
	Id int identity(1,1) primary key,
	CreateDate datetime,
	UpdateDate datetime,
	CreatedBy nvarchar(200),
	UpdatedBy nvarchar(200),
	Status int,
	IsDeleted bit,
	Name nvarchar(200),
	Slug varchar(200),
	NumberOfPost int
)

create table Blog
(
	Id int identity(1,1) primary key,
	CreateDate datetime,
	UpdateDate datetime,
	CreatedBy nvarchar(200),
	UpdatedBy nvarchar(200),
	Status int,
	IsDeleted bit,
	ImagePath nvarchar(200),
	Title nvarchar(200),
	Slug varchar(200),
	Summary nvarchar(max),
	Content nvarchar(max),
	Comments int,
	BlogCategoryId int,
	AuthorImagePath nvarchar(200),
	TagsName nvarchar(max)
)

create table BlogTags
(
	Id int identity(1,1) primary key,
	CreateDate datetime,
	UpdateDate datetime,
	CreatedBy nvarchar(200),
	UpdatedBy nvarchar(200),
	Status int,
	IsDeleted bit,
	Name nvarchar(50),
	Slug varchar(50)
)

create table Cart
(
	Id int identity(1,1) primary key,
	Username nvarchar(200),
	ProductId int,
	Quantity int,
	SubTotal decimal
)

create table Category
(
	Id int identity(1,1) primary key,
	CreateDate datetime,
	UpdateDate datetime,
	CreatedBy nvarchar(200),
	UpdatedBy nvarchar(200),
	Status int,
	IsDeleted bit,
	Name nvarchar(200),
	Slug varchar(200),
	Description nvarchar(max),
	ImagePath nvarchar(200)
)

create table CategoryImage
(
	Id int identity(1,1) primary key,
	CreateDate datetime,
	UpdateDate datetime,
	CreatedBy nvarchar(200),
	UpdatedBy nvarchar(200),
	Status int,
	IsDeleted bit,
	Name nvarchar(200),
	FilePath nvarchar(200),
	FileType varchar(50),
	FileFormat varchar(50),
	FileId int,
	CategoryId int,
	IsAvatar bit
)

create table ContactMessage
(
	Id int identity(1,1) primary key,
	Name nvarchar(200),
	Email varchar(200),
	Message nvarchar(max)
)

create table DiscountCode
(
	Id int identity(1,1) primary key,
	ReducedAmount decimal,
	UsedBy nvarchar(200),
	Name nvarchar(200),
	IsDeleted bit
)

create table Discount
(
	Id int identity(1,1) primary key,
	ProductId int,
	DiscountPercent decimal,
	CreateDate datetime,
	OutOfDate datetime,
	CreatedBy nvarchar(200),
	Status int,
	IsDeleted bit
)

create table FileManage
(
	Id int identity(1,1) primary key,
	CreateDate datetime,
	UpdateDate datetime,
	CreatedBy nvarchar(200),
	UpdatedBy nvarchar(200),
	Status int,
	IsDeleted bit,
	Name nvarchar(200),
	FilePath nvarchar(200),
	FileType varchar(50),
	FileFormat varchar(50)
)

create table Product
(
	Id int identity(1,1) primary key,
	CreateDate datetime,
	UpdateDate datetime,
	CreatedBy nvarchar(200),
	UpdatedBy nvarchar(200),
	Status int,
	IsDeleted bit,
	Name nvarchar(200),
	Slug varchar(200),
	Price decimal,
	OldPrice decimal,
	Description nvarchar(max),
	SummaryContent nvarchar(max),
	Quantity int,
	Weight float,
	Unit varchar(20),
	CategoryId int,
	ImagePath nvarchar(200),
	IsDiscount bit
)

create table ProductImage
(
	Id int identity(1,1) primary key,
	CreateDate datetime,
	UpdateDate datetime,
	CreatedBy nvarchar(200),
	UpdatedBy nvarchar(200),
	Status int,
	IsDeleted bit,
	Name nvarchar(200),
	FilePath nvarchar(200),
	FileType varchar(50),
	FileFormat varchar(50),
	FileId int,
	ProductId int,
	IsAvatar bit
)

create table SalesReceiptDetail
(
	Id int identity(1,1) primary key,
	SalesReceiptId int,
	SellQuantity int,
	ProductId int
)

create table SalesReceipt
(
	Id int identity(1,1) primary key,
	CreateDate datetime,
	CustomerId int,
	Discount decimal
)

create table TypedDiscount
(
	Id int identity(1,1) primary key,
	Username nvarchar(200),
	Name nvarchar(200)
)

create table UsedDiscountCode
(
	Id int identity(1,1) primary key,
	Username nvarchar(200),
	Name nvarchar(200)
)