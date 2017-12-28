use master
go

create database glabsiennsoftdb
go

use glabsiennsoftdb
go

drop index IX_products_codeType on products
drop index IX_products_codeUnit on products
drop table productcategories
drop table products
drop table types
drop table categories
drop table units

create table units
                (
	                code uniqueidentifier not null primary key,
	                description nvarchar(max) not null
                )

create table categories
                (
	                code uniqueidentifier not null primary key,
	                description nvarchar(max) not null
                )

create table types
                (
	                code uniqueidentifier not null primary key,
	                description nvarchar(max) not null
                )

create table products
(
	code uniqueidentifier not null primary key,
	description nvarchar(max) not null,
	isAvailable bit not null default 0,
	deliveryDate datetime2,
	codeType uniqueidentifier not null,
	codeUnit uniqueidentifier not null,
	constraint FK_products_types foreign key (codeType) references types(code),
	constraint FK_products_units foreign key (codeUnit) references units(code)
)

create table productcategories
(
	codeProduct uniqueidentifier not null,
	codeCategory uniqueidentifier not null,
	constraint PK_productcategories primary key (codeProduct, codeCategory),
	constraint FK_product_categories foreign key (codeProduct) references categories(code) on delete cascade,
	constraint FK_category_products foreign key (codeCategory) references products(code) on delete cascade
)

create index IX_products_codeType on products (codeType)
create index IX_products_codeUnit on products (codeUnit)
